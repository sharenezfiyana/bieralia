#pragma checksum "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15e48711724659a15c714b9869d9bf5cfade7b6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ReportAdmin), @"mvc.1.0.view", @"/Views/Admin/ReportAdmin.cshtml")]
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
#line 1 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
using Bieralia.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15e48711724659a15c714b9869d9bf5cfade7b6f", @"/Views/Admin/ReportAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be88c95b80ecac7374403d8ccca085d8111c954b", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ReportAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TransactionListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
  
    if(Context.Session.GetString("Username") == null)
    {
        Layout = "_Layout";
    }
    else
    {
        Layout = "_LayoutAdmin";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<section class=\"reports\">\r\n    <div class=\"container\">\r\n\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 23 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
             foreach(var tl in Model.TransactionList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-sm-6 mb-4\">\r\n                <div class=\"card text-left reports-admin\">\r\n                    <div class=\"card-header\">User ID: ");
#nullable restore
#line 27 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
                                                 Write(tl.Transaction.UserID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">Transaction ID: ");
#nullable restore
#line 29 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
                                                          Write(tl.Transaction.TransactionID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 30 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
                          int total = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
                             foreach(var t in @tl.TransactionDetailList)
                            {
                                total = total + (t.Book.Price * t.TransactionDetail.Quantity);
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"card-text\">Total: Rp. ");
#nullable restore
#line 35 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
                                                       Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 36 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
                             if(tl.Transaction.Status == "Unpaid")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1359, "\"", 1415, 3);
            WriteAttributeValue("", 1369, "acceptPayment(\'", 1369, 15, true);
#nullable restore
#line 38 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
WriteAttributeValue("", 1384, tl.Transaction.TransactionID, 1384, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1413, "\')", 1413, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1416, "\"", 1450, 1);
#nullable restore
#line 38 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
WriteAttributeValue("", 1421, tl.Transaction.TransactionID, 1421, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-color-report\">Accept Payment</a>\r\n");
#nullable restore
#line 39 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a class=\"btn btn-color-report disabled\" aria-disabled=\"true\">Payment Accepted</a>\r\n");
#nullable restore
#line 43 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 47 "C:\Users\ezsha\Desktop\KULIAH SHAREN\Semester 4\BIERALIA\BIERALIA\Bieralia\Views\Admin\ReportAdmin.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>

        async function acceptPayment_query(transactionID){
            console.log(transactionID)
            const response = await fetch(""../Admin/AcceptPayment?TransactionID="" + transactionID,
                {
                    method: ""POST""
                }
            )
            const data = await response.json();
            return data;

        }

        async function acceptPayment(transactionID){

            console.log(transactionID);
            const ret = await acceptPayment_query(transactionID);
            alert(""Payment Accepted"");
            document.getElementById(transactionID).setAttribute(""aria-disabled"", ""true"");
            document.getElementById(transactionID).classList.add(""disabled"");
            document.getElementById(transactionID).innerText = 'Payment Accepted'
        }
    </script>
");
            }
            );
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
