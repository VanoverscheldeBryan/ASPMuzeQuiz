#pragma checksum "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Admin\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de21fdc76d504fd1cb900f60045be71ee6a430a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Users), @"mvc.1.0.view", @"/Views/Admin/Users.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\_ViewImports.cshtml"
using MuzeQuiz.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\_ViewImports.cshtml"
using MuzeQuiz.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\_ViewImports.cshtml"
using MuzeQuiz.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de21fdc76d504fd1cb900f60045be71ee6a430a7", @"/Views/Admin/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6faf0c99ee69b83ac0d701e81ecbb25c636eb7e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MuzeQuiz.Models.AppUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Admin\Users.cshtml"
  
    ViewData["Title"] = "Users";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Users</h1>\r\n\r\n<a href=\"/Identity/Account/Register\">Add User</a>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Admin\Users.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Admin\Users.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 22 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Admin\Users.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 26 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Admin\Users.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 29 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Admin\Users.cshtml"
               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 32 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Admin\Users.cshtml"
               Write(Html.ActionLink("Add User To a Role", "AddRoleToUser", new { userId = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 35 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Admin\Users.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MuzeQuiz.Models.AppUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
