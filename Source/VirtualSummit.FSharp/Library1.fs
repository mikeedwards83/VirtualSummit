namespace VirtualSummit.FSharp
open Glass.Mapper.Sc
open Glass.Mapper.Sc.Configuration.Fluent;


type FSharpModel ()= 
    member val SomeTitle = "" with get, set
    member val FeaturedImage : Glass.Mapper.Sc.Fields.Image = null  with get, set




