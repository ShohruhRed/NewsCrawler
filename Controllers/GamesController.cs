﻿using ASPTryParsing.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASPTryParsing.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            List<News> jobs = new List<News>();

            var web = new HtmlWeb();


            var doc = web.Load("https://www.playground.ru/news");
            foreach (var item in doc.DocumentNode.SelectNodes("//div[@class='post']"))
            {

                string title = item.SelectSingleNode(".//div[@class='post-title']").InnerText.Trim();
                string details = item.SelectSingleNode(".//a").GetAttributeValue("href", null).Trim();
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
