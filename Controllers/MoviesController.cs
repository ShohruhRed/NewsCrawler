using ASPTryParsing.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASPTryParsing.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            List<News> jobs = new List<News>();

            var web = new HtmlWeb();


            var doc = web.Load("https://www.kinomania.ru/news");
            foreach (var item in doc.DocumentNode.SelectNodes("//div[@class='pagelist-item clear']"))
            {

                string title = item.SelectSingleNode(".//div[@class='pagelist-item-title']").InnerText.Trim();
                //string text = item.SelectSingleNode("//div[@class='pagelist-item clear']/p").InnerText.Trim();
                string details = "https://www.kinomania.ru/" + item.SelectSingleNode(".//a").GetAttributeValue("href", null).Trim();
                string img = item.SelectSingleNode(".//img").GetAttributeValue("data-original", null).Trim();

                jobs.Add(new News()
                {
                    Title = title,
                    //Text = text,
                    Details = details,
                    Img = img,

                }); ;
            }

            return View(jobs);
        }
    }
}
