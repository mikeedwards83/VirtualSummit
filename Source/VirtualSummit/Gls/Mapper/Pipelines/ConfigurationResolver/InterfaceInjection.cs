using System.Linq;
using Glass.Mapper.Pipelines.ConfigurationResolver;
using Glass.Mapper.Pipelines.ConfigurationResolver.Tasks.OnDemandResolver;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration;
using VirtualSummit.Models;

namespace VirtualSummit.Gls.Mapper.Pipelines.ConfigurationResolver
{
    public class InterfaceInjection : IConfigurationResolverTask
    {
        public void Execute(ConfigurationResolverArgs args)
        {
            if (args.Result == null && args.RequestedType == typeof (ILazyModelMaker))
            {
                var scContext = args.AbstractTypeCreationContext as SitecoreTypeCreationContext;

                var ids =
                    scContext.Item.Template.BaseTemplates.Select(x => x.ID)
                        .Union(new[] {scContext.Item.TemplateID})
                        .Distinct();

                var lazyConfig = args.Context[args.RequestedType];
                if (lazyConfig == null)
                {
                    var loader = new OnDemandLoader<SitecoreTypeConfiguration>(args.RequestedType);
                    args.Context.Load(loader);
                    lazyConfig = args.Context[args.RequestedType];
                }

                var configs =
                    args.Context.TypeConfigurations.Where(x => x.Value is SitecoreTypeConfiguration).Select(x=>x.Value)
                        .Cast<SitecoreTypeConfiguration>();

                args.Result =
                    new[] {lazyConfig}.Union(
                        ids.Select(x => configs.FirstOrDefault(y => y.TemplateId == x && y.Type.IsInterface))
                        .Where(x => x != null));
            }
        }
    }
}