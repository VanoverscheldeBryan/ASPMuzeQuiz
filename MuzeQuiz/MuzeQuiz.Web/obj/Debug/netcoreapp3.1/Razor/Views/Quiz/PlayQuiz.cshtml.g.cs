#pragma checksum "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\PlayQuiz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed30af52b04bb0924f13f39e9a749cdd093101d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quiz_PlayQuiz), @"mvc.1.0.view", @"/Views/Quiz/PlayQuiz.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed30af52b04bb0924f13f39e9a749cdd093101d9", @"/Views/Quiz/PlayQuiz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6faf0c99ee69b83ac0d701e81ecbb25c636eb7e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Quiz_PlayQuiz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MuzeQuiz.Web.ViewModels.fullQuiz>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\PlayQuiz.cshtml"
  
    ViewData["Title"] = "PlayQuiz";
    DateTime timestarted = DateTime.Now;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>");
#nullable restore
#line 9 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\PlayQuiz.cshtml"
Write(Model.quizName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div>\r\n    <h4>");
#nullable restore
#line 12 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\PlayQuiz.cshtml"
   Write(Model.quizQuestion.QuestionSelf);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n");
#nullable restore
#line 15 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\PlayQuiz.cshtml"
             for (int i = 0; i < Model.answers.Count(); i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 18 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\PlayQuiz.cshtml"
               Write(Html.ActionLink(Model.answers[i].Answer_Text, "NextQuestion", new { quizId = Model.quizId, quizName = Model.quizName, qstnIndex = Model.QuestionIndex, date = timestarted, correct = Model.answers[i].IsCorrect, score = ViewBag.score }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n");
#nullable restore
#line 20 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\PlayQuiz.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n</div>\r\n<div>\r\n    <p>Score : ");
#nullable restore
#line 24 "C:\Users\Hawkeys\Desktop\HEREXAMENS 2e JAAR\Backend\ASPMuzeQuiz\MuzeQuiz\MuzeQuiz.Web\Views\Quiz\PlayQuiz.cshtml"
          Write(ViewBag.score);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MuzeQuiz.Web.ViewModels.fullQuiz> Html { get; private set; }
    }
}
#pragma warning restore 1591
