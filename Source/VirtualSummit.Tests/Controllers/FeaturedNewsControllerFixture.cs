using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Glass.Mapper.Sc;
using NSubstitute;
using NUnit.Framework;
using VirtualSummit.Controllers;
using VirtualSummit.Models.sitecore.templates.VirtualSummit.Pages;
using VirtualSummit.ViewModels.FeaturedNews;

namespace VirtualSummit.Tests.Controllers
{
    [TestFixture]
    public class FeaturedNewsControllerFixture
    {
        [Test]
        public void Index_PageGet_ReturnsViewModelWithPageAndArticles()
        {
            //Arrange
            var featuredNews = new FeaturedNews();

            var article = new NewsArticle();
            featuredNews.NewsArticles = new []{article};

            var context = Substitute.For<ISitecoreContext>();
            context.GetCurrentItem<FeaturedNews>().Returns(featuredNews);

            var controller = new StubFeaturedNewsController(context, null);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            var model = result.Model as IndexGet;

            Assert.IsNotNull(result);
            Assert.AreEqual(featuredNews, model.FeaturedNews);
            Assert.AreEqual(article, model.Articles.First());
            Assert.AreEqual(1, model.Articles.Count());
        }

        [Test]
        public void Index_PageGet_ReturnsFeaturedOnlyArticles()
        {
            //Arrange
            var featuredNews = new FeaturedNews();

            var notFeatured = new NewsArticle();
            var featured = new NewsArticle();
            featured.Featured = true;

            featuredNews.NewsArticles = new[] { notFeatured, featured };

            var context = Substitute.For<ISitecoreContext>();
            context.GetCurrentItem<FeaturedNews>().Returns(featuredNews);

            var controller = new StubFeaturedNewsController(context, null);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            var model = result.Model as IndexGet;

            Assert.IsNotNull(result);
            Assert.AreEqual(featuredNews, model.FeaturedNews);
            Assert.AreEqual(featured, model.Articles.First());
            Assert.AreEqual(1, model.Articles.Count());
        }

        [Test]
        public void Index_PageGet_ReturnsFeaturedOnlyArticlesInThePast()
        {
            //Arrange
            var featuredNews = new FeaturedNews();

            var notFeatured = new NewsArticle();
            
            var featuredInThePast = new NewsArticle();
            featuredInThePast.Featured = true;
            featuredInThePast.Date = DateTime.Now.AddDays(-1);

            var featuredInTheFuture = new NewsArticle();
            featuredInTheFuture.Featured = true;
            featuredInTheFuture.Date = DateTime.Now.AddDays(+1);


            featuredNews.NewsArticles = new[] { notFeatured, featuredInThePast, featuredInTheFuture };

            var context = Substitute.For<ISitecoreContext>();
            context.GetCurrentItem<FeaturedNews>().Returns(featuredNews);

            var controller = new StubFeaturedNewsController(context, null);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            var model = result.Model as IndexGet;

            Assert.IsNotNull(result);
            Assert.AreEqual(featuredNews, model.FeaturedNews);
            Assert.AreEqual(featuredInThePast, model.Articles.First());
            Assert.AreEqual(1, model.Articles.Count());
        }

        #region Stubs


        public class StubFeaturedNewsController : FeaturedNewsController
        {
            public StubFeaturedNewsController(ISitecoreContext sitecoreContext, IGlassHtml glassHtml ) :base(sitecoreContext, glassHtml)
            {
            }
        }

        #endregion

    }
}
