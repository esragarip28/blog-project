using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.Entities.Concretes;

namespace WebProject.Models.Services.Abstracts
{
    public interface IArticleService
    {
        Article GetArticleNameById(int id);
        List<Article> GetAllArticles();
        void CreateArticle(Article article);
        Article FindArticleByName(string name);
        void DeleteArticleById(int id);

        void UpdateArticle(Article article);
        public List<Article> GetAllArticlesByUser();

    }
}
