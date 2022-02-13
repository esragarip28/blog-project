 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WebProject.Models.Entities.Concretes
{
    [Serializable]
    public class Article 
    {
        private int articleId;
        private int userId;
        private string articleName;
        private string author;
        private DateTime publishedDate;
        private DateTime updatedDate;
        private string articleContent;
         
        public Article() { }
        public Article(int articleId, int userId, string articleName, string author, DateTime publishedDate, DateTime updatedDate, string articleContent)
        {
            this.articleId = articleId;
            this.userId = userId;
            this.articleName = articleName;
            this.author = author;
            this.publishedDate = publishedDate;
            this.updatedDate = updatedDate;
            this.articleContent = articleContent;
        }

        public int ArticleId { get => articleId; set => articleId = value; }
        public int UserId { get => userId; set => userId = value; }
        public string ArticleName { get => articleName; set => articleName = value; }
        public string Author { get => author; set => author = value; }
        public DateTime PublishedDate { get => publishedDate; set => publishedDate = value; }
        public DateTime UpdatedDate { get => updatedDate; set => updatedDate = value; }
        public string ArticleContent { get => articleContent; set => articleContent = value; }
    }
}
