using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper;
using Glass.Mapper.Pipelines.ConfigurationResolver;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration;
using Sitecore.Data.Items;
using VirtualSummit.Models;

namespace VirtualSummit.Pipelines.ConfigurationResolver
{
    public class InterfaceInjection : IConfigurationResolverTask
    {
        public void Execute(ConfigurationResolverArgs args)
        {
            //if(args.Result == null && args.AbstractTypeCreationContext.RequestedType.Any(x=> x == typeof(IDynamic)))
            //{
            //    var scContext = args.AbstractTypeCreationContext as SitecoreTypeCreationContext;
            //    var ids=  scContext.Item.Template.BaseTemplates.Select(x => x.ID);

            //    var configs = args.Context.TypeConfigurations.Cast<SitecoreTypeConfiguration>()
            //        .Where(x => ids.Any(y => y == x.TemplateId));




            //}
        }
    }
}