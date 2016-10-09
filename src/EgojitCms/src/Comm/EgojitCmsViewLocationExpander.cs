using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace EgojitCms.web.Comm
{
    public class EgojitCmsViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            yield return "~/Views/{1}/{0}.cshtml";
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            
        }
    }
}
