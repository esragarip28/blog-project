using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.Entities.Concretes;

namespace WebProject.Models.DataAccess.Abstracts
{
    public interface IArticleDal
    {
        Article GetArticleNameById(int id);
        List<Article> GetAllArticles();
        void CreateArticle(Article article);
        Article FindArticleByName(string name);
        void DeleteArticleById(int id);
        void UpdateArticle(Article article);
        List<Article> GetAllArticlesByUser();





    }
}
