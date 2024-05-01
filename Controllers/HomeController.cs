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
        using (var client = new HttpClient())
        {
            // API endpoint'i
            string apiUrl = "https://www.sgk.gov.tr/Duyuru";
            
            try
            {
                // API'den veriyi al
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Ýsteðin baþarýlý olup olmadýðýný kontrol et
                if (response.IsSuccessStatusCode)
                {
                    // Yanýtý JSON olarak oku
                    string responseBody = await response.Content.ReadAsStringAsync();

                    //-------------------------------------

                    var doc = new HtmlDocument();
                    doc.LoadHtml(responseBody);

                    // Örnek olarak, HTML içerisinde belirli bir elementi seçelim
                    var duyurularNodes = doc.DocumentNode.SelectNodes("//div[@class='entry-title']");


                    var duyurular = new List<object>();

                    if (duyurularNodes != null)
                    {
                        foreach (var node in duyurularNodes)
                        {
                            // HTML içeriðinden gerekli verileri alarak JSON objelerine dönüþtürün
                            var baslik = node.SelectSingleNode(".//h4").InnerText.Trim();


                            duyurular.Add(new { Baslik = baslik });

                        }
                    }
                    
                    string jsonDuyurular = JsonConvert.SerializeObject(duyurular);
                    JArray jArray = JArray.Parse(jsonDuyurular);


                    List<JToken> jTokenList = jArray.ToList();
                    SgkDuyuruModel sgk = new SgkDuyuruModel();


                    for (int i = 0; i < jTokenList.Count; i++)
                    {
                        sgk.Id = i+1;
                        sgk.Baslik.Add(jTokenList[i].Last.ToString());

                        model.Title = sgk.Baslik;
                    }

                }

                else
                {
                    Console.WriteLine("API isteði baþarýsýz: " + response.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Hata oluþtu: " + e.Message);
            }

        }

        return View(model);

    }



    public IActionResult Privacy()
    {
        return View();
    }


}
