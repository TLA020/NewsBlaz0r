using System;

namespace NewsBlaz0r.Shared.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set;  }
        
        public string DescriptionTrimmed =>  Description;
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }

        public Article(string title, string description, string imageUrl, DateTime publishDate)
        {
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            PublishDate = publishDate;
        }

        public Article()
        {
        }
    }
}