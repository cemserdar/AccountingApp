using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using accountingWebSite.Models;
using Newtonsoft.Json;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Xml.Linq;
using NSoup;
using NSoup.Nodes;
using NSoup.Select;
using Document = NSoup.Nodes.Document;

namespace accountingWebSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public async Task<IActionResult> Index()
    {
        InformationModel model = new InformationModel();
        //----------------SGK----------------------------------
        SgkDuyuruModel sgkDuyuruModel = new SgkDuyuruModel();

        Document doc = NSoupClient.Connect("https://www.sgk.gov.tr/Duyuru").Get();
        Element div_news = doc.GetElementById("posts");
        Elements news = div_news.GetElementsByClass("entry");
        foreach (Element item in news)
        {
            //sgkDuyuruModel.SgkTitle.Add(item.Select("a").Text);
            //sgkDuyuruModel.SgkTitle.Add(item.Select("a").TagName("a").Text);
            sgkDuyuruModel.SgkTitle.Add(item.GetElementsByTag("a").Text);

            sgkDuyuruModel.SgkLink.Add(item.Select("a").Attr("href").Remove(0, 8));
            sgkDuyuruModel.SgkDate.Add(item.GetElementsByClass("sgkUnite").Text);
            
        }
        model.SgkDuyuruModel = sgkDuyuruModel;

        //---------------------------SGK---------------------------------

        //-------------------------GÝB------------------------------------
        GibDuyuruModel gibDuyuruModel = new GibDuyuruModel();
        Document gib = NSoupClient.Connect("https://www.gib.gov.tr/haberlerveduyurular").Get();
        Element gib_news = gib.GetElementById("block-system-main");
        Elements gibNews = gib_news.GetElementsByClass("blogpost");
        foreach (Element item in gibNews)
        {
            gibDuyuruModel.GibTitle.Add(item.Select("a").Text);
            gibDuyuruModel.GibLink.Add(item.Select("a").Attr("href"));
            gibDuyuruModel.GibDate.Add(item.GetElementsByClass("date").Text);
        }
        model.gibDuyuruModel = gibDuyuruModel;
        //-------------------------GÝB------------------------------------

        ViewBag.count = sgkDuyuruModel.SgkLink.Count;


        return View(model);
    }


    public IActionResult Privacy()
    {
        return View();
    }


}
