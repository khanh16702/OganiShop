#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f755b170642dc84576ae89b2e69e7788db7ed81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyAccount_Index), @"mvc.1.0.view", @"/Views/MyAccount/Index.cshtml")]
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
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\_ViewImports.cshtml"
using AppManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\_ViewImports.cshtml"
using AppManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f755b170642dc84576ae89b2e69e7788db7ed81", @"/Views/MyAccount/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39bdf4e2eeb9182a14600fe5d339bdb2f9540938", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_MyAccount_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/myaccount/updateaccount"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
  
    ViewData["Title"] = "My account";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"" style=""margin-bottom:20px"">
    <div class=""row d-flex justify-content-center align-items-center"">
        <div class=""col-xl-9"">
            <div class=""card"" style=""border-radius: 15px;background-color:#E1FFCE"">
                <div style=""display:flex;justify-content:space-between"">
                    <h2>");
#nullable restore
#line 10 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
                   Write(ViewBag.username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 11 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
                     if (ViewBag.Role == "admin") {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a href=\"/admin/home/index\" class=\"btn btn-warning pull-right\" style=\"color:white\">Go to manager\'s page</a>\r\n");
#nullable restore
#line 13 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
                     if (ViewBag.Role == "staff") {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a href=\"/admin/product/index\" class=\"btn btn-warning pull-right\" style=\"color:white\">Go to manager\'s page</a>\r\n");
#nullable restore
#line 16 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <div class=\"card-body\" >\r\n                    <p style=\"color:red\">");
#nullable restore
#line 19 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
                                    Write(TempData["AlertAccount"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f755b170642dc84576ae89b2e69e7788db7ed816445", async() => {
                WriteLiteral("\r\n                        <div class=\"row align-items-center pt-4 pb-3\">\r\n                            <input type=\"text\" name=\"avatar\" id=\"account-avatar\"");
                BeginWriteAttribute("value", " value=\"", 1198, "\"", 1221, 1);
#nullable restore
#line 22 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
WriteAttributeValue("", 1206, ViewBag.avatar, 1206, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" hidden />
                            <input type=""text"" id=""image-file-path"" name=""filePath"" hidden>
                            <input type=""text"" id=""image-file-id"" name=""fileId"" hidden>
                            <input type=""text"" id=""image-name"" name=""name"" hidden />
                            <div class=""col-md-12 text-center"">
                                <img");
                BeginWriteAttribute("src", " src=\"", 1603, "\"", 1624, 1);
#nullable restore
#line 27 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
WriteAttributeValue("", 1609, ViewBag.avatar, 1609, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" id=""image-upload"" class=""rounded mx-auto d-block"" style=""width: 256px"" />
                            </div>
                        </div>
                        <div class=""row align-items-center pt-4 pb-3"">
                            <input type=""file"" name=""fileUpload"" id=""exampleInputFile"">
                            <i class=""help-block"">Update your avatar</i>
                        </div>
                        <hr class=""mx-n3"">
                        <div class=""row align-items-center py-3"">
                            <div class=""col-md-3 ps-5"">
                                <h6 class=""mb-0"">Username:</h6>
                            </div>
                            <div class=""col-md-9 pe-5"">
                                <input type=""text"" name=""username"" class=""form-control form-control-lg""");
                BeginWriteAttribute("value", " value=\"", 2465, "\"", 2490, 1);
#nullable restore
#line 40 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\MyAccount\Index.cshtml"
WriteAttributeValue("", 2473, ViewBag.username, 2473, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" readonly />
                            </div>
                        </div>
                        <hr class=""mx-n3"">
                        <div class=""row align-items-center py-3"">
                            <div class=""col-md-3 ps-5"">
                                <h6 class=""mb-0"">New password:</h6>
                            </div>
                            <div class=""col-md-9 pe-5"">
                                <input type=""password"" name=""password"" class=""form-control form-control-lg"" />
                            </div>
                        </div>
                        <hr class=""mx-n3"">
                        <div class=""row align-items-center py-3"">
                            <div class=""col-md-3 ps-5"">
                                <h6 class=""mb-0"">Confirm password:</h6>
                            </div>
                            <div class=""col-md-9 pe-5"">
                                <input type=""password"" name=""retypedpassword"" class=""form-control ");
                WriteLiteral(@"form-control-lg"" />
                            </div>
                        </div>
                        <hr class=""mx-n3"">
                        <div class=""px-5 py-4"">
                            <button type=""submit"" class=""btn btn-success btn-lg"">Okay</button>
                            <a href=""/admin/account/signout"" class=""btn btn-danger btn-lg pull-right"">Log out</a>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).on('change', 'input[name=""fileUpload""]', function () {
            let files = $(this).prop(""files"");
            let formData = new FormData();
            formData.append(""file"", files[0]);
            console.log(formData)
            $.ajax({
                url: ""/myaccount/uploadfile"",
                type: ""POST"",
                data: formData,
                contentType: false,
                processData: false,
                beforeSend: () => {

                },
                success: res => {
                    if (res.status == 'success') {
                        $('#image-upload').attr('src', res.fileInfo.filePath);
                        $('#image-file-path').val(res.fileInfo.filePath);
                        $('#image-file-id').val(res.fileInfo.id);
                        $('#image-name').val(res.fileInfo.Name)
                        $('#account-avatar').val(res.fileInfo.filePath);
                    }
                    ");
                WriteLiteral(@"else if (res.status == ""error1"") {
                        console.log(""Lỗi"");
                    }
                },
                error: error => {
                    console.log(error);
                }
            })
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
