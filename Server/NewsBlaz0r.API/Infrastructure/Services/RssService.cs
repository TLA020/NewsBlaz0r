using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Parsers.Rss;
using NewsBlaz0r.Shared.Models;

namespace NewsBlaz0r.API.Infrastructure.Services
{
    public class RssService : IRssService
    {
        private readonly ILogger _logger;

        public RssService(ILogger<RssService> logger)
        {
            _logger = logger;
        }

        public async Task<List<Article>> GetArticles(string endpoint)
        {
            string feed = null;

            using (var client = new HttpClient())
            {
                var feedResponse = await client.GetAsync(endpoint);

                if (!feedResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Feed unavailable");
                }

                feed = await feedResponse.Content.ReadAsStringAsync();
            }

            var parser = new RssParser();
            var rss = parser.Parse(feed);

            var articles = new List<Article>();

            foreach (var element in rss)
            {
                var article = new Article(element.Title, element.Summary, element.ImageUrl, element.PublishDate);
                articles.Add(article);
            }

            return articles;
        }


        public async Task<List<Article>> GetFromBing(string endpoint)
        {
            string feed;

            using (var client = new HttpClient())
            {
                var feedResponse = await client.GetAsync(endpoint);

                if (!feedResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Feed unavailable");
                }

                feed = await feedResponse.Content.ReadAsStringAsync();
            }

            var doc = XDocument.Parse(feed);
            var items = doc.Descendants("item").ToList();
            var ns = doc.Root?.GetNamespaceOfPrefix("News");
            var articles = new List<Article>();

            foreach (var d in items)
            {
                var article = new Article()
                {
                    Title = d.Element("title")?.Value,
                    Description = d.Element("description")?.Value,
                    ImageUrl = d.Element(ns + "Image")?.Value + "\\",
                    PublishDate = DateTime.Parse(d.Element("pubDate")?.Value ?? string.Empty)
                };
                articles.Add(article);
            }

            return articles;
        }
    }
}
