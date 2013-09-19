using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pages = VirtualSummit.Models.sitecore.templates.VirtualSummit.Pages;

namespace VirtualSummit.ViewModels.FeaturedNews
{
    public class IndexGet
    {
        public Pages.FeaturedNews FeaturedNews { get; set; }
        public IEnumerable<Pages.NewsArticle> Articles { get; set; }
    }
}