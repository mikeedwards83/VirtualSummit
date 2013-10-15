using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualSummit.ViewModels.TipsAndTricks
{
    public class TipsAndTricksModel
    {
        public Layouts.GlassRazor.TipsAndTricks.CustomPageTitles PageTitles { get; set; }
        public Layouts.GlassRazor.TipsAndTricks.ConstructorInjection Injected { get; set; }
    }
}