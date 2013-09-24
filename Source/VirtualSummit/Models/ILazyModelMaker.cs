using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualSummit.Models
{
    public interface ILazyModelMaker
    {
        string Url { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
    }


}