#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c17194045f496856d4af369d8c82299b834175b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_BlogCategory_AddOrUpdate), @"mvc.1.0.view", @"/Areas/Admin/Views/BlogCategory/AddOrUpdate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c17194045f496856d4af369d8c82299b834175b1", @"/Areas/Admin/Views/BlogCategory/AddOrUpdate.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_BlogCategory_AddOrUpdate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Dashboard";
    string error = TempData["error"] as string;
    var pageNumber = (int)ViewBag.pageNumber;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"py-5\">Cập nhật thông tin danh mục blog</h2>\r\n");
#nullable restore
#line 9 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
 if (!string.IsNullOrEmpty(error))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"text-danger\">");
#nullable restore
#line 11 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
                      Write(error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 12 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 14 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
     if (Model.Id == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-8\">\r\n            <form");
            BeginWriteAttribute("action", " action=\"", 439, "\"", 502, 2);
            WriteAttributeValue("", 448, "/admin/blogcategory/AddOrUpdate?pageNumber=", 448, 43, true);
#nullable restore
#line 17 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 491, pageNumber, 491, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" method=""post"">
                <div class=""form-group row"">
                    <label for=""productname"" class=""col-sm-2 col-form-label"">Tên danh mục:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""name"" class=""form-control"" id=""productname"">
                    </div>
                </div>
                <div class=""form-group row"" style=""display:flex"">
                    <div class=""col-sm-2"">
                        <button type=""submit"" class=""btn btn-primary"">Xác nhận</button>
                    </div>
                    <div class=""col-sm-12 pt-3"">
                        <a class=""btn btn-primary""");
            BeginWriteAttribute("href", " href=\"", 1186, "\"", 1241, 2);
            WriteAttributeValue("", 1193, "/admin/blogcategory/index?pageNumber=", 1193, 37, true);
#nullable restore
#line 29 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 1230, pageNumber, 1230, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Quay lại</a>\r\n                    </div>\r\n                </div>\r\n            </form>\r\n        </div>\r\n");
#nullable restore
#line 34 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-8\">\r\n            <form");
            BeginWriteAttribute("action", " action=\"", 1419, "\"", 1474, 2);
            WriteAttributeValue("", 1428, "/admin/blog/AddOrUpdate?pageNumber=", 1428, 35, true);
#nullable restore
#line 38 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 1463, pageNumber, 1463, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" method=""post"">
                <div class=""form-group row"">
                    <label for=""productid"" class=""col-sm-2 col-form-label"">Mã danh mục</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""id"" class=""form-control"" id=""productid""");
            BeginWriteAttribute("value", " value=\"", 1767, "\"", 1784, 1);
#nullable restore
#line 42 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 1775, Model.Id, 1775, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productname"" class=""col-sm-2 col-form-label"">Tên danh mục:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""name"" class=""form-control"" id=""productname""");
            BeginWriteAttribute("value", " value=\"", 2132, "\"", 2151, 1);
#nullable restore
#line 48 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 2140, Model.Name, 2140, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productcman"" class=""col-sm-2 col-form-label"">Người tạo:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""createdby"" class=""form-control"" id=""productcman""");
            BeginWriteAttribute("value", " value=\"", 2492, "\"", 2516, 1);
#nullable restore
#line 54 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 2500, Model.CreatedBy, 2500, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productcdate"" class=""col-sm-2 col-form-label"">Ngày tạo:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""createdate"" class=""form-control"" id=""productcdate""");
            BeginWriteAttribute("value", " value=\"", 2868, "\"", 2893, 1);
#nullable restore
#line 60 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 2876, Model.CreateDate, 2876, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productuman"" class=""col-sm-2 col-form-label"">Người cập nhật:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""updatedby"" class=""form-control"" id=""productuman""");
            BeginWriteAttribute("value", " value=\"", 3248, "\"", 3272, 1);
#nullable restore
#line 66 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 3256, Model.UpdatedBy, 3256, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productudate"" class=""col-sm-2 col-form-label"">Ngày cập nhật:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""updatedate"" class=""form-control"" id=""productudate""");
            BeginWriteAttribute("value", " value=\"", 3629, "\"", 3654, 1);
#nullable restore
#line 72 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 3637, Model.UpdateDate, 3637, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly>
                    </div>
                </div>
                <fieldset class=""form-group"">
                    <div class=""row"">
                        <label class=""col-form-label col-sm-2 pt-0"">Tình trạng sử dụng:</label>
                        <div class=""col-sm-10"">
");
#nullable restore
#line 79 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
                             if (Model.Status == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""form-check"">
                                    <input class=""form-check-input"" type=""radio"" name=""status"" id=""status1"" value=""1"" checked>
                                    <label class=""form-check-label"" for=""status1"">
                                        Còn dùng
                                    </label>
                                </div>
                                <div class=""form-check"">
                                    <input class=""form-check-input"" type=""radio"" name=""status"" id=""status2"" value=""0"">
                                    <label class=""form-check-label"" for=""status2"">
                                        Không dùng
                                    </label>
                                </div>
");
#nullable restore
#line 93 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""form-check"">
                                    <input class=""form-check-input"" type=""radio"" name=""status"" id=""status1"" value=""1"">
                                    <label class=""form-check-label"" for=""status1"">
                                        Còn dùng
                                    </label>
                                </div>
                                <div class=""form-check"">
                                    <input class=""form-check-input"" type=""radio"" name=""status"" id=""status2"" value=""0"" checked>
                                    <label class=""form-check-label"" for=""status2"">
                                        Không dùng
                                    </label>
                                </div>
");
#nullable restore
#line 108 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                </fieldset>
                <div class=""form-group row"" style=""display:flex"">
                    <div class=""col-sm-2"">
                        <button type=""submit"" class=""btn btn-primary"">Xác nhận</button>
                    </div>
                    <div class=""col-sm-12 pt-3"">
                        <a class=""btn btn-primary""");
            BeginWriteAttribute("href", " href=\"", 6191, "\"", 6246, 2);
            WriteAttributeValue("", 6198, "/admin/blogcategory/index?pageNumber=", 6198, 37, true);
#nullable restore
#line 117 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
WriteAttributeValue("", 6235, pageNumber, 6235, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Quay lại</a>\r\n                    </div>\r\n                </div>\r\n            </form>\r\n        </div>\r\n");
#nullable restore
#line 122 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\BlogCategory\AddOrUpdate.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
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
