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

                // �ste�in ba�ar�l� olup olmad���n� kontrol et
                if (response.IsSuccessStatusCode)
                {
                    // Yan�t� JSON olarak oku
                    string responseBody = await response.Content.ReadAsStringAsync();

                    //-------------------------------------

                    var doc = new HtmlDocument();
                    doc.LoadHtml(responseBody);

                    // �rnek olarak, HTML i�erisinde belirli bir elementi se�elim
                    var duyurularNodes = doc.DocumentNode.SelectNodes("//div[@class='entry-title']");


                    var duyurular = new List<object>();

                    if (duyurularNodes != null)
                    {
                        foreach (var node in duyurularNodes)
                        {
                            // HTML i�eri�inden gerekli verileri alarak JSON objelerine d�n��t�r�n
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
                    Console.WriteLine("API iste�i ba�ar�s�z: " + response.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Hata olu�tu: " + e.Message);
            }

        }

        return View(model);

    }



    public IActionResult Privacy()
    {
        return View();
    }


}
