#pragma checksum "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\Schools\AllSchools.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bed97390d9c496ecb01f323a5c2f08e28d8a5990"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Schools_AllSchools), @"mvc.1.0.view", @"/Views/Schools/AllSchools.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Schools/AllSchools.cshtml", typeof(AspNetCore.Views_Schools_AllSchools))]
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
#line 1 "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\_ViewImports.cshtml"
using E_LearningAppMongoDbAPI.Models;

#line default
#line hidden
#line 2 "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\_ViewImports.cshtml"
using E_LearningApp;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bed97390d9c496ecb01f323a5c2f08e28d8a5990", @"/Views/Schools/AllSchools.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1e466518c5d6c0d82a29e3d1e377fe6c956110b", @"/Views/_ViewImports.cshtml")]
    public class Views_Schools_AllSchools : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<E_LearningApp.ViewModels.SchoolsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\Schools\AllSchools.cshtml"
  
    ViewData["Title"] = "AllSchools";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(143, 320, true);
            WriteLiteral(@"
<h2>All Schools</h2>
<div class=""row"">
    <div class=""col-lg-12"">
        <table class=""table table-bordered"">
            <thead>
                <tr>
                    <th>Skola</th>
                    <th>Kurs</th>
                </tr>
            </thead>
            <tbody>
                <tr>
");
            EndContext();
#line 19 "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\Schools\AllSchools.cshtml"
                     foreach (var s in Model.Schools)
                    {

#line default
#line hidden
            BeginContext(541, 28, true);
            WriteLiteral("                        <td>");
            EndContext();
            BeginContext(570, 6, false);
#line 21 "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\Schools\AllSchools.cshtml"
                       Write(s.Name);

#line default
#line hidden
            EndContext();
            BeginContext(576, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 22 "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\Schools\AllSchools.cshtml"
                    }

#line default
#line hidden
            BeginContext(606, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 23 "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\Schools\AllSchools.cshtml"
                     foreach (var c in Model.Courses)
                    {

#line default
#line hidden
            BeginContext(684, 28, true);
            WriteLiteral("                        <td>");
            EndContext();
            BeginContext(713, 6, false);
#line 25 "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\Schools\AllSchools.cshtml"
                       Write(c.Name);

#line default
#line hidden
            EndContext();
            BeginContext(719, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 26 "C:\Users\Milica\Desktop\E-LearningApp\E-LearningApp\Views\Schools\AllSchools.cshtml"
                    }

#line default
#line hidden
            BeginContext(749, 101, true);
            WriteLiteral("                </tr>                \r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<E_LearningApp.ViewModels.SchoolsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591