using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using TweetSharp;

namespace VirtualSummit.Models
{
    [SitecoreType(AutoMap = true)]
    public class TweetList
    {
        public virtual string Username { get; set; }

        [SitecoreField("Username")]
        public virtual IEnumerable<TwitterStatus> Tweets { get; set; } 

    }
}