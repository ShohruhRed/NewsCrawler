using Microsoft.AspNetCore.Mvc;
using System.Net;
using HtmlAgilityPack;
using ASPTryParsing.Models;

namespace ASPTryParsing.Controllers
{
    public class OffersController : Controller
    {
        public IActionResult Index()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            List<News> jobs = new List<News>();

            var web = new HtmlWeb();
            
            
            var doc = web.Load("https://www.spot.uz/ru/news/");
            foreach (var item in doc.DocumentNode.SelectNodes("//div[@class='contentBox']"))
            {
                
                string title = item.SelectSingleNode(".//h2[@class='itemTitle']").InnerText.Trim();
                string details = "https://www.spot.uz/" + item.SelectSingleNode(".//a").GetAttributeValue("href", null).Trim();
                string img = "https://www.spot.uz/" +  item.SelectSingleNode(".//img").GetAttributeValue("data-src", null).Trim();

                jobs.Add(new News()
                {
                    Title=title,
                    Details=details,
                    Img=img,
                    
                });;
            }

            return View(jobs);
        }
    }
}
