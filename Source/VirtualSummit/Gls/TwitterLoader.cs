using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Fluent;
using TweetSharp;

namespace VirtualSummit.Gls
{
    public class TwitterLoader
    {
        public static  SitecoreFluentConfigurationLoader Load()
        {
            var loader = new SitecoreFluentConfigurationLoader();

            loader.Add<SendTweetOptions>().Fields(x=>
            {
                x.Field(y => y.Status);
                x.Field(y => y.Lat);
                x.Field(y => y.Long);
                x.Field(y => y.DisplayCoordinates);
                x.Field(y => y.TrimUser);
            });

            return loader;
        }

    }
}