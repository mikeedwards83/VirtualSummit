using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Controllers;
using VirtualSummit.Models;
using VirtualSummit.Models.sitecore.templates.VirtualSummit.Pages;
using VirtualSummit.ViewModels.FeaturedNews;

namespace VirtualSummit.Controllers
{
    public class FeaturedNewsController : GlassController
    {

        /// <summary>
        /// Used for unit testing
        /// </summary>
        /// <param name="context"></param>
        /// <param name="glassHtml"></param>
        internal FeaturedNewsController(ISitecoreContext context, IGlassHtml glassHtml):base(context, glassHtml){}
      
        public override ActionResult Index()
        {
            var viewModel = new IndexGet();

            var featuredNews = SitecoreContext.GetCurrentItem<FeaturedNews>();
            viewModel.FeaturedNews = featuredNews;
            viewModel.Articles = featuredNews.NewsArticles;

            return View(viewModel);
        }
    }
}