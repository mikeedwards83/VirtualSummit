using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.DataMappers;
using TweetSharp;
using VirtualSummit.Models.sitecore.templates.VirtualSummit.Settings;
using VirtualSummit.SitecoreX.Commands;

namespace VirtualSummit.Gls.Mapper.Sc.DataMappers
{
    public class TweetDataMapper : AbstractSitecoreFieldMapper
    {
        public TweetDataMapper():base(typeof(IEnumerable<TwitterStatus>))
        {
            ReadOnly = true;
        }
        

        public override string SetFieldValue(object value, SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
            throw new NotImplementedException();
        }

        public override object GetFieldValue(string fieldValue, SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
          return null;
            
        }
    }
}