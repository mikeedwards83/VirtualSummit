using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace VirtualSummit.Models.sitecore.templates.VirtualSummit.Pages
{
    public partial class FeaturedNews
    {
        [SitecoreChildren]
        public virtual IEnumerable<NewsArticle> NewsArticles { get; set; }
    }
}