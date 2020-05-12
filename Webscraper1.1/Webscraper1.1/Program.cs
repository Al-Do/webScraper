using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Webscraper1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHtmlAsync();
            Console.ReadLine();
        }
        private static async void GetHtmlAsync()
        {
            var url = "https://www.indeed.com/jobs?l=aurora%2C%20il&radius=0&sort=date&start=20&vjk=c9396f74158c1e6d";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var JobsHtml = htmlDocument.DocumentNode.Descendants(0).Where(n => n.HasClass("jobsearch-SerpJobCard")).ToList();
            
            foreach (var job in JobsHtml)
            {
             job.Descendants("h2").Where(n => n.HasClass("title")).FirstOrDefault();
            }
             //JobsHtml[0].Descendants("h2").Where(n => n.HasClass("title")).ToList();

            //Descendants(0).Where(n => n.HasClass("title"));

            //var JobsListItems = JobsTitle[0].Descendants("a")
            //    .Where(node => node.GetAttributeValue("id", "")
            //    .Contains("jl").ToList();

            Console.WriteLine();
           
            
        }
    }
}
