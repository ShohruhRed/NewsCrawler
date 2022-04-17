using ASPTryParsing.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASPTryParsing.Controllers
{
    public class BelNewsController : Controller
    {
        public IActionResult Index()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            List<News> jobs = new List<News>();

            var web = new HtmlWeb();


            var doc = web.Load("https://www.belnovosti.by/news");
            foreach (var item in doc.DocumentNode.SelectNodes("//div[@class='ex_box']"))
            {

                string title = item.SelectSingleNode(".//span[@itemprop='name']").InnerText.Trim();
                string details = "https://www.belnovosti.by/" + item.SelectSingleNode(".//a").GetAttributeValue("href", null).Trim();
                string img = item.SelectSingleNode(".//img").GetAttributeValue("src", null).Trim();

                jobs.Add(new News()
                {
                    Title = title,
                    Details = details,
                    Img = img,

                }); ;
            }

            return View(jobs);
        }
    }
}
