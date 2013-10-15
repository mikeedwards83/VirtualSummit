using Glass.Mapper;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Razor.Web.Ui;
using Sitecore.Shell.Applications.ContentEditor;
using VirtualSummit.Models.sitecore.templates.VirtualSummit.Base;
using VirtualSummit.ViewModels.TipsAndTricks;

namespace VirtualSummit.Layouts.GlassRazor
{
	public class TipsAndTricks : AbstractRazorControl<TipsAndTricksModel>
	{             
		public override TipsAndTricksModel GetModel()
		{
		    var model = new TipsAndTricksModel();
            
            var item = GetDataSourceOrContextItem();
			
            //items extensions, useful for pipelines/workflows
		    var pageTitles = item.GlassCast<PageTitles>();

		    pageTitles.FeatureTitle += "Some modification";

		    using (new ItemEditing(item, true))
		    {
		        item.GlassRead(pageTitles);
		    }

            //using protected vs public memebrs.
		    model.PageTitles = SitecoreContext.GetCurrentItem<CustomPageTitles>();

            model.Injected = SitecoreContext.GetCurrentItem<ConstructorInjection, string>("Combined Title");

		    return model;
		}
       
	    public class CustomPageTitles
	    {
            protected virtual string ShortTitle { get; set; }
            protected virtual string LongTitle { get; set; }

	        public virtual string Title
	        {
	            get
	            {
	                return string.IsNullOrEmpty(LongTitle) ? ShortTitle : LongTitle;
	            }
	        }

            public virtual string FeatureTitle { get; set; }

	    }

	    public class ConstructorInjection
	    {
	        private readonly string _someOtherValue;

	        public ConstructorInjection(string someOtherValue)
	        {
	            _someOtherValue = someOtherValue;
	        }

            protected virtual string ShortTitle { get; set; }

	        public virtual string CombinedTitle
	        {
	            get
	            {
	                return _someOtherValue + ShortTitle;
	            }
	        }
	    }
	}
}
