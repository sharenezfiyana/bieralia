#pragma checksum "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce6da5dcdfeb4fa546981fbbfa58c64f7cb0af32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_History), @"mvc.1.0.view", @"/Views/User/History.cshtml")]
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
#line 1 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\_ViewImports.cshtml"
using Bieralia;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\_ViewImports.cshtml"
using Bieralia.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\_ViewImports.cshtml"
using Bieralia.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce6da5dcdfeb4fa546981fbbfa58c64f7cb0af32", @"/Views/User/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be88c95b80ecac7374403d8ccca085d8111c954b", @"/Views/_ViewImports.cshtml")]
    public class Views_User_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TransactionListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid rounded-start"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
  
    Layout = "_LoginLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n");
#nullable restore
#line 11 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
     if(Model.TransactionList.Count() == 0){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n        <div class=\"wrapper-cart\">\r\n            <span>Your Cart is Empty!!!</span>\r\n        </div>\r\n");
#nullable restore
#line 16 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
     foreach(var tl in Model.TransactionList)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n        <div class=\"wrapper-cart\">\r\n            <h5>");
#nullable restore
#line 21 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
           Write(tl.Transaction.TransactionID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 22 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
              
                int totalPrice = 0;
                int totalAllPrice = 0;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
             foreach(var t in @tl.TransactionDetailList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card mb-3\" style=\"max-height: 240px\">\r\n                    <div class=\"row g-0\">\r\n                        <div class=\"col-md-1 p-2\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ce6da5dcdfeb4fa546981fbbfa58c64f7cb0af326510", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 962, "~/images/", 962, 9, true);
#nullable restore
#line 31 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
AddHtmlAttributeValue("", 971, t.Book.Image, 971, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-md-8\">\r\n                            <div class=\"card-body cart-title\">\r\n                                <h5 style=\"font-size: 1.2em\" class=\"card-title\">");
#nullable restore
#line 35 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
                                                                           Write(t.Book.BookTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <p style=\"font-size: 1em\" class=\"card-text\">Rp ");
#nullable restore
#line 36 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
                                                                          Write(t.Book.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / book</p>\r\n                                <p style=\"font-size: 1em\" class=\"card-text\">Quantity : ");
#nullable restore
#line 37 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
                                                                                  Write(t.TransactionDetail.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 38 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
                                   
                               totalPrice = t.Book.Price * t.TransactionDetail.Quantity;
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p style=\"font-size: 1em\" class=\"card-text\">Total : ");
#nullable restore
#line 41 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
                                                                               Write(totalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 45 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
                      
                        totalAllPrice += totalPrice;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 49 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n            <div class=\"button-checkout d-flex justify-content-between align-items-center\">\r\n                <span style=\"font-size: 1em; font-weight:bold\" class=\"card-text\">Total Price : Rp ");
#nullable restore
#line 52 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
                                                                                             Write(totalAllPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span>");
#nullable restore
#line 53 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
                 Write(tl.Transaction.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 56 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\User\History.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TransactionListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
