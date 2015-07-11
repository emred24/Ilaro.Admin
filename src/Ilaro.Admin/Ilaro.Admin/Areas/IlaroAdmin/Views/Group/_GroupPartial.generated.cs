﻿using System;
using System.CodeDom.Compiler;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using Ilaro.Admin.Extensions;
using Ilaro.Admin.Models;
using Resources;

#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36213
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    [GeneratedCode("RazorGenerator", "2.0.0.0")]
    [PageVirtualPath("~/Areas/IlaroAdmin/Views/Group/_GroupPartial.cshtml")]
    public partial class _Areas_IlaroAdmin_Views_Group__GroupPartial_cshtml : WebViewPage<GroupModel>
    {
        public _Areas_IlaroAdmin_Views_Group__GroupPartial_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
 if (!Model.Name.IsNullOrEmpty())
{

            
            #line default
            #line hidden
WriteLiteral("    <h3>");

            
            #line 5 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
   Write(Html.ActionLink(Model.Name, "Index", new { groupName = Model.Name }));

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n");

            
            #line 6 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<table");

WriteLiteral(" class=\"table table-striped table-bordered table-hover\"");

WriteLiteral(">\r\n    <tbody>\r\n");

            
            #line 9 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
        
            
            #line default
            #line hidden
            
            #line 9 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
         foreach (var entity in Model.Entities)
        {

            
            #line default
            #line hidden
WriteLiteral("            <tr>\r\n                <td");

WriteLiteral(" class=\"max-width\"");

WriteLiteral(">");

            
            #line 12 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
                                 Write(Html.ActionLink(entity.Verbose.Plural, "Index", "Entities", new { area = "IlaroAdmin", entityName = entity.Name }, null));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                <td>\r\n");

            
            #line 14 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
                     if (entity.CanAdd)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 579), Tuple.Create("\"", 672)
            
            #line 16 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
, Tuple.Create(Tuple.Create("", 586), Tuple.Create<Object, Int32>(Url.Action("Create", "Entity", new { area = "IlaroAdmin", entityName = entity.Name })
            
            #line default
            #line hidden
, 586), false)
);

WriteLiteral(" class=\"btn btn-xs btn-link\"");

WriteLiteral("><span");

WriteLiteral(" class=\"glyphicon glyphicon-plus\"");

WriteLiteral("></span> ");

            
            #line 16 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
                                                                                                                                                                                               Write(IlaroAdminResources.Add);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 17 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n            </tr>\r\n");

            
            #line 20 "..\..\Areas\IlaroAdmin\Views\Group\_GroupPartial.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </tbody>\r\n</table>\r\n");

        }
    }
}
#pragma warning restore 1591