#pragma checksum "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b7569e2e3b04d1acb445e5325352461291ba416"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_GetCompletedOrder), @"mvc.1.0.view", @"/Views/Report/GetCompletedOrder.cshtml")]
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
#line 1 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\_ViewImports.cshtml"
using Sjx_Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\_ViewImports.cshtml"
using Sjx_Mvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b7569e2e3b04d1acb445e5325352461291ba416", @"/Views/Report/GetCompletedOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a7fcaa2947fdebd6e5e9e898ab89961dcb80c89", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_GetCompletedOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Sjx_Mvc.ViewModels.OrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetAllUsers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline ml-3 navbar-nav"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml"
  
    ViewData["Title"] = "User List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7b7569e2e3b04d1acb445e5325352461291ba4165623", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<h1>Users</h1>



<section class=""content"">
    <div class=""row"">
        <div class=""col-12"">


            <div class=""card"">
                <div class=""card-header"">

                    <nav class=""main-header navbar navbar-expand navbar-white navbar-light"">
                        <!-- Left navbar links -->

                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b7569e2e3b04d1acb445e5325352461291ba4167103", async() => {
                WriteLiteral(@"
                            <div class=""input-group input-group-sm"">
                                <label> Search</label>
                                <input class=""form-control form-control-navbar"" type=""text"" placeholder=""e.g Name, Mobile & Email"" aria-label=""Search"" name=""searchTerm"" id=""searchTerm"">
                                <div class=""input-group-append"">
                                    <button class=""btn btn-navbar"" type=""submit"">
                                        <i class=""fas fa-search""></i>
                                    </button>
                                </div>
                            </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"



                        <ul class=""navbar-nav ml-auto"">


                            <li class=""nav-item "">
                                <button name=""Submit"" class=""btn btn-primary""> Export</button>

                            </li>

                            <li><input type=""button"" onclick=""exported()"" value=""Export"" /></li>



                        </ul>
                    </nav>


                </div>
                <div class=""card-body"">
                    <table id=""example1"" class=""table table-bordered table-striped responsive-table"">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Email(s)</th>
                                <th>Mobile</th>
                                <th>Order-Code</th>
                                <th>Address</th>
                                <th rowspan=""4"" style=""align-items:center"">Operations</th>
                        ");
            WriteLiteral("    </tr>\r\n\r\n                        </thead>\r\n                        <tbody id=\"quotesRow\">\r\n\r\n");
#nullable restore
#line 70 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml"
                             if (Model.Count() == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td colspan=\"7\" class=\"text-center\">No Record Found</td>\r\n                            </tr>\r\n");
#nullable restore
#line 75 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml"
                            }
                            else
                            {
                                foreach (var user in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr class=\"odd gradeX\">\r\n                                <td style=\"width:40%\">");
#nullable restore
#line 81 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml"
                                                 Write(user.RecieversName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td style=\"width:40%\">");
#nullable restore
#line 82 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml"
                                                 Write(user.CustomersEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td style=\"width:30%\">");
#nullable restore
#line 83 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml"
                                                 Write(user.RecieversPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td style=\"width:30%\">");
#nullable restore
#line 84 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml"
                                                 Write(user.OrderCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td style=\"width:30%\">");
#nullable restore
#line 85 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml"
                                                 Write(user.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 88 "C:\Users\GlobalSJX\Desktop\Sjx-Mvc\Views\Report\GetCompletedOrder.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n\r\n                    </table>\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral(@"                    <script type=""text/javascript"" charset=""utf8"" src=""http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js""></script>
                    <script type=""text/javascript"" charset=""utf8"" src=""http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/jquery.dataTables.min.js""></script>

                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</section>





<script>
    //$(document).ready(function () {
    //    $(""body"").tooltip({ selector: '[data-toggle=tooltip]' });
    //});
    $(function () {
        $(""#example"").dataTable();
    })
    $(function () {
        $(""#example1"").DataTable({
            ""responsive"": true,
            ""autoWidth"": false,
        });
        $('#example2').DataTable({
            ""paging"": true,
            ""lengthChange"": false,
            ""searching"": false,
            ""ordering"": true,
            ""info""");
            WriteLiteral(@": true,
            ""autoWidth"": false,
            ""responsive"": true,
        });
    });


    $(document).ready(function () {
        $('#searchTerm').keydown(function () {
            var searchTerm = $(this).val();
            var url = 'Account/GetAllUsers?searchTerm='

            $.ajax({
                type: ""Post"",
                url: url + searchTerm,
                contentType: ""html"",
                success: function (response) {
                    $(""#quotesRow"").html(response);
                }
            })
        })

    })


    }
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Sjx_Mvc.ViewModels.OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591