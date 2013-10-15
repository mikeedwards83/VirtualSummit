using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration.Fluent;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using TweetSharp;
using VirtualSummit.Models.sitecore.templates.VirtualSummit.Settings;

namespace VirtualSummit.SitecoreX.Commands
{
    public class TweetCommand : Command
    {
        public  const string SettingsPath = "/sitecore/content/Settings/Twitter";

        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull((object) context, "context");
            if (context.Items.Length != 1)
                return;
            Item item = context.Items[0];

            var scService = new SitecoreService(item.Database);
            var settings = scService.GetItem<TwitterSettings>(SettingsPath);


            TwitterService twitterService = new TwitterService(settings.ConsumerKey, settings.ConsumerSecret);
            twitterService.AuthenticateWith(settings.AccessToken, settings.AccessTokenSecret);

            TwitterUser user = twitterService.VerifyCredentials(new VerifyCredentialsOptions());

            var tweet = scService.CreateType<SendTweetOptions>(item);
            twitterService.SendTweet(tweet);
        }

    }
}