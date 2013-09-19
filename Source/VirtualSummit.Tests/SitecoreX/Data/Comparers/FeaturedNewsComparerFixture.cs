using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VirtualSummit.Models.sitecore.templates.VirtualSummit.Pages;
using VirtualSummit.SitecoreX.Data.Comparers;

namespace VirtualSummit.Tests.SitecoreX.Data.Comparers
{
    [TestFixture]
    public class FeaturedNewsComparerFixture
    {
        [Test]
        public void DoCompare_FeaturedVsNotFeatured_ReturnsMinusOne()
        {
            //Arrange
            var featured = new NewsArticle();
            featured.Featured = true;
            var notFeatured = new NewsArticle();

            var comparer = new StubFeaturedNewsComparer();

            //Act
            var result = comparer.DoCompare(featured, notFeatured);

            //Assert
            Assert.AreEqual(-1, result );
        }

        [Test]
        public void DoCompare_NotFeatureVsFeatured_ReturnsMinusOne()
        {
            //Arrange
            var featured = new NewsArticle();
            featured.Featured = true;
            var notFeatured = new NewsArticle();

            var comparer = new StubFeaturedNewsComparer();

            //Act
            var result = comparer.DoCompare(notFeatured, featured);

            //Assert
            Assert.AreEqual(1, result);
        }
      

        #region Stubs


        public class StubFeaturedNewsComparer : FeaturedNewsComparer
        {
            public int DoCompare(NewsArticle item1, NewsArticle item2)
            {
                return base.DoCompare(item1, item2);
            }
        }

        #endregion

    }
}
