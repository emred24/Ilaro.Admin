﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ilaro.Admin.Views.IlaroAdmin
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Ilaro.Admin.Commons.Paging;
    using Ilaro.Admin.Extensions;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/IlaroAdmin/Index.cshtml")]
    public partial class Index : System.Web.Mvc.WebViewPage<Ilaro.Admin.ViewModels.IndexViewModel>
    {
        public Index()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\IlaroAdmin\Index.cshtml"
  
    Layout = "~/Views/IlaroAdmin/_Layout.cshtml";
    ViewBag.Title = Resources.IlaroAdminResources.Index_Title;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("Breadcrumb", () => {

WriteLiteral("\r\n<ul");

WriteLiteral(" class=\"breadcrumb\"");

WriteLiteral(">\r\n    <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\IlaroAdmin\Index.cshtml"
                  Write(Resources.IlaroAdminResources.Index_Title);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n</ul>\r\n");

});

WriteLiteral("\r\n<ul");

WriteLiteral(" class=\"thumbnails\"");

WriteLiteral(">\r\n");

            
            #line 16 "..\..\Views\IlaroAdmin\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\IlaroAdmin\Index.cshtml"
     foreach (var group in Model.EntitiesGroups)
    { 
        Html.RenderPartial("_GroupPartial", group);
    }

            
            #line default
            #line hidden
WriteLiteral("</ul>\r\n");

        }
    }
}
#pragma warning restore 1591
