#pragma checksum "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e56157fcf90132866e856812e1cebdb76a72018d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quiz_Quizzes), @"mvc.1.0.view", @"/Views/Quiz/Quizzes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e56157fcf90132866e856812e1cebdb76a72018d", @"/Views/Quiz/Quizzes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6faf0c99ee69b83ac0d701e81ecbb25c636eb7e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Quiz_Quizzes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MuzeQuiz.Models.Quiz>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
  
    ViewData["Title"] = "Quizzes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Quizzes</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n");
#nullable restore
#line 13 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
             if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>\r\n                    ");
#nullable restore
#line 16 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
               Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 19 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
               Write(Html.DisplayNameFor(model => model.AppUserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n");
#nullable restore
#line 21 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
           Write(Html.DisplayNameFor(model => model.Diff));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 35 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n");
#nullable restore
#line 37 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
             if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 40 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
               Write(Html.DisplayFor(modelItem => item.AppUserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 45 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>\r\n                ");
#nullable restore
#line 47 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Diff));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n");
#nullable restore
#line 55 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
             if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <td>\r\n            ");
#nullable restore
#line 58 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
       Write(Html.ActionLink("Delete", "DeleteQuiz", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n");
#nullable restore
#line 60 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 64 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
           Write(Html.ActionLink("Play", "PlayQuiz", new { /* id=item.PrimaryKey */quizid = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 67 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\Quizzes.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MuzeQuiz.Models.Quiz>> Html { get; private set; }
    }
}
#pragma warning restore 1591
