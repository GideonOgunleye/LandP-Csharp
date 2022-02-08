using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace SeleniumWebdriver.TestScript.WebCrawler
{
    class Crawler
    {
        static void Main(string[] args)
        {
            startCrawlerasync();
            Console.ReadLine();
        }

        private static async Task startCrawlerasync()
        {
            var url = "http://qa.conventionbureau.london/search-accommodation";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var links = new List<Link>();

            var divs =
                htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("")).ToList();
            foreach (var div in divs)
            {
                ///var link = new Link
                var link = new Link
                {

                };
                links.Add(link);
            }

        }
    }
}
