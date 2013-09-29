using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Razor.Web.Ui;
using VirtualSummit.ViewModels.DemoBehind;

namespace VirtualSummit.Layouts.GlassRazor
{
    public class DemoBehind : AbstractRazorControl<DemoBehindModel>
	{
        public override DemoBehindModel GetModel()
		{
			var item = GetDataSourceOrContextItem();

		    var model = new DemoBehindModel();
            model.Page = SitecoreContext.CreateType<Models.sitecore.templates.VirtualSummit.Pages.General>(item);
		    model.IsPostback = Page.IsPostBack;


		    return model;
		}
	}
}
