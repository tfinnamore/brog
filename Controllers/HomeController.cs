using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Brog.Models;
using Brog.Services;
using Brog.ViewModels;
using Brog.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Brog.Controllers
{
    public class HomeController : Controller
    {
        private IArticleData _articleData;

        public HomeController(IArticleData articleData){
            _articleData = articleData;
        }
    
        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Articles = _articleData.GetAll();

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Post(int id)
        {
            var model = _articleData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(ArticleAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newArticle = new Article();
                newArticle.title = model.title;
                newArticle.teaser = model.teaser;
                newArticle.body = model.articleBody;

                _articleData.Add(newArticle);

                return RedirectToAction("Post", new { id = newArticle.id });
            }

            return View();

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
