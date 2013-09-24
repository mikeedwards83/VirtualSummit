using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Glass.Mapper.Configuration;
using Glass.Mapper.Pipelines.ConfigurationResolver;
using Glass.Mapper.Sc.CastleWindsor;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.SecurityModel;
using VirtualSummit.Gls.Mapper.Pipelines.ConfigurationResolver;

namespace VirtualSummit.App_Start
{
    public static  class GlassMapperScCustom
    {
		public static void CastleConfig(IWindsorContainer container){
			var config = new Config();

		    container.Register(
                Component.For<IConfigurationResolverTask>().ImplementedBy<InterfaceInjection>()

                );
			container.Install(new SitecoreInstaller(config));
		}

		public static IConfigurationLoader[] GlassLoaders(){
			var attributes = new SitecoreAttributeConfigurationLoader("VirtualSummit");
			
			return new IConfigurationLoader[]{attributes};
		}
		public static void PostLoad(){
			//Remove the comments to activate CodeFist
			/* CODE FIRST START
            var dbs = Sitecore.Configuration.Factory.GetDatabases();
            foreach (var db in dbs)
            {
                var provider = db.GetDataProviders().FirstOrDefault(x => x is GlassDataProvider) as GlassDataProvider;
                if (provider != null)
                {
                    using (new SecurityDisabler())
                    {
                        provider.Initialise(db);
                    }
                }
            }
             * CODE FIRST END
             */
		}
    }
}
