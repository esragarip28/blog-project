using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.DataAccess.Abstracts;
using WebProject.Models.DataAccess.Concretes;
using WebProject.Models.Entities.Concretes;
using WebProject.Models.Services.Abstracts;

namespace WebProject.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [Route("get/article")]
        public Article getArticleNameById(int id)
        {
            return _articleService.GetArticleNameById(id);
        }

        [Route("get/all/articles")]
        public List<Article> getAllArticles()
        {
            return _articleService.GetAllArticles();
        }
        [Route("find/article")]
        public Article FindArticleByName(string name)
        {
            return _articleService.FindArticleByName(name);
        }
        [HttpPost]
        [Route("create/article")]
        public IActionResult CreateArticle(Article article)
        {
            _articleService.CreateArticle(article);
            return RedirectToAction("Dashboard", "Home");
        }
        
        [HttpGet]
        [Route("delete/article")]
        public void DeleteArticleById(int id)
        {
            _articleService.DeleteArticleById(id);
        }

        [HttpPost]
        [Route("update/article")]
        public IActionResult UpdateArticle(Article article)
        {
            _articleService.UpdateArticle(article);
            return RedirectToAction("Dashboard", "Home");
        }

        [HttpGet]
        [Route("get/all/articles/by/user")]
        public List<Article> GetAllArticlesByUser()
        {
            return _articleService.GetAllArticlesByUser();
        }
    }
}
