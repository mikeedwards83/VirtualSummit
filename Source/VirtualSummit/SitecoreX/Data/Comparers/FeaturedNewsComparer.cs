using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc;
using Sitecore.Data.Comparers;
using Sitecore.Data.Items;
using VirtualSummit.Models.sitecore.templates.VirtualSummit.Pages;

namespace VirtualSummit.SitecoreX.Data.Comparers
{
    public class FeaturedNewsComparer : Comparer
    {
        protected override int DoCompare(Item item1, Item item2)
        {
            return DoCompare(item1.GlassCast<NewsArticle>(), item2.GlassCast<NewsArticle>());
        }

        protected virtual int DoCompare(NewsArticle item1, NewsArticle item2)
        {
            if ( (item1.Featured && item2.Featured) || (!item1.Featured && !item2.Featured))
            {
                return item1.Date.CompareTo(item2.Date);
            }
            if (item1.Featured && !item2.Featured)
                return -1;

            if (!item1.Featured && item2.Featured)
                return 1;

            return 0;
        }
    }
}