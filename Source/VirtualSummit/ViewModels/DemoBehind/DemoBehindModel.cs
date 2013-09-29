using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualSummit.Models.sitecore.templates.VirtualSummit.Pages;

namespace VirtualSummit.ViewModels.DemoBehind
{
    public class DemoBehindModel
    {
        public bool IsPostback { get; set; }
        public General Page { get; set; }
    }
}