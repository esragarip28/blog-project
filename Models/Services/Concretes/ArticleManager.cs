using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.DataAccess.Abstracts;
using WebProject.Models.Entities.Concretes;
using WebProject.Models.Services.Abstracts;
namespace WebProject.Models.Services.Concretes
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }
        public void CreateArticle(Article article)
        {
            _articleDal.CreateArticle(article);
        }

        public void DeleteArticleById(int id)
        {
            _articleDal.DeleteArticleById(id);
        }

        public Article FindArticleByName(string name)
        {
           return _articleDal.FindArticleByName(name);
        }

        public List<Article> GetAllArticles()
        {
            return _articleDal.GetAllArticles();
        }

        public List<Article> GetAllArticlesByUser()
        {
            return _articleDal.GetAllArticlesByUser();
        }

        public Article GetArticleNameById(int id)
        {
            return _articleDal.GetArticleNameById(id);
        }

        public void UpdateArticle( Article article)
        {
            _articleDal.UpdateArticle(article);
        }
    }
}
