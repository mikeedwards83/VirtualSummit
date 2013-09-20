using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualSummit.Gls.Mapper.Sc.Configuration.Attributes
{
    public class SitecoreSearch
    {
        public string Query { get; set; }

        public SitecoreSearch(string query)
        {
            Query = query;
        }
    }
}