using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace VirtualSummit.Models
{
    public partial class GlassBase
    {
        [SitecoreInfo(SitecoreInfoType.Url)]
        public virtual string Url { get; set; }
    }
}