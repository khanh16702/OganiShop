#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "039ae0e76d3488d5d34b601625103f95b07a0ab6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Banner_AddOrUpdate), @"mvc.1.0.view", @"/Areas/Admin/Views/Banner/AddOrUpdate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"039ae0e76d3488d5d34b601625103f95b07a0ab6", @"/Areas/Admin/Views/Banner/AddOrUpdate.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Banner_AddOrUpdate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Quản lý banner";
    string error = TempData["error"] as string;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"py-5\">Cập nhật thông tin banner</h2>\r\n");
#nullable restore
#line 8 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
 if (!string.IsNullOrEmpty(error))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"text-danger\">");
#nullable restore
#line 10 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
                      Write(error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 11 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n");
#nullable restore
#line 14 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
     if (Model.Id == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-md-8"">
            <form action=""/admin/banner/AddOrUpdate"" method=""post"">
                <div class=""form-group row"">
                    <label for=""productname"" class=""col-sm-2 col-form-label"">Tiêu đề banner:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""title"" class=""form-control"" id=""productname"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productslug"" class=""col-sm-2 col-form-label"">Slug:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""slug"" class=""form-control"" id=""productslug"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productslug"" class=""col-sm-2 col-form-label"">Mã phân loại đến:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""tocatego");
            WriteLiteral(@"ryid"" class=""form-control"" id=""producttocategory"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productcontent"" class=""col-sm-2 col-form-label"">Nội dung:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""content"" class=""form-control"" id=""productcontent"">
                    </div>
                </div>
                <div class=""form-group row"" style=""display:flex"">
                    <div class=""col-sm-2"">
                        <button type=""submit"" class=""btn btn-primary"">Xác nhận</button>
                    </div>
                    <div class=""col-sm-12 pt-3"">
                        <a class=""btn btn-primary"" href=""/admin/banner/index"">Quay lại</a>
                    </div>
                </div>
            </form>
        </div>
");
#nullable restore
#line 52 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-8\">\r\n            <form action=\"/admin/banner/AddOrUpdate\" method=\"post\">\r\n                <input type=\"text\" name=\"imagepath\"");
            BeginWriteAttribute("value", " value=\"", 2449, "\"", 2473, 1);
#nullable restore
#line 57 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 2457, Model.ImagePath, 2457, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" hidden/>
                <div class=""form-group row"">
                    <label for=""productid"" class=""col-sm-2 col-form-label"">Mã banner:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""id"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 2744, "\"", 2761, 1);
#nullable restore
#line 61 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 2752, Model.Id, 2752, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""productid"" readonly>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productname"" class=""col-sm-2 col-form-label"">Tiêu đề banner:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""title"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 3110, "\"", 3130, 1);
#nullable restore
#line 67 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 3118, Model.Title, 3118, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""productname"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productslug"" class=""col-sm-2 col-form-label"">Slug:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""slug"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 3461, "\"", 3480, 1);
#nullable restore
#line 73 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 3469, Model.Slug, 3469, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""productslug"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productslug"" class=""col-sm-2 col-form-label"">Mã phân loại đến:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""tocategoryid"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 3831, "\"", 3858, 1);
#nullable restore
#line 79 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 3839, Model.ToCategoryId, 3839, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""producttocategory"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productcontent"" class=""col-sm-2 col-form-label"">Nội dung:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""content"" class=""form-control"" id=""productcontent""");
            BeginWriteAttribute("value", " value=\"", 4225, "\"", 4247, 1);
#nullable restore
#line 85 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 4233, Model.Content, 4233, 14, false);

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
            BeginWriteAttribute("value", " value=\"", 4588, "\"", 4612, 1);
#nullable restore
#line 91 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 4596, Model.CreatedBy, 4596, 16, false);

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
            BeginWriteAttribute("value", " value=\"", 4964, "\"", 4989, 1);
#nullable restore
#line 97 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 4972, Model.CreateDate, 4972, 17, false);

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
            BeginWriteAttribute("value", " value=\"", 5344, "\"", 5368, 1);
#nullable restore
#line 103 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 5352, Model.UpdatedBy, 5352, 16, false);

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
            BeginWriteAttribute("value", " value=\"", 5725, "\"", 5750, 1);
#nullable restore
#line 109 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
WriteAttributeValue("", 5733, Model.UpdateDate, 5733, 17, false);

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
#line 116 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
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
#line 130 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
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
#line 145 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                </fieldset>
                <fieldset class=""form-group"">
                    <div class=""row"">
                        <label class=""col-form-label col-sm-2 pt-0"">Banner chính:</label>
                        <div class=""col-sm-10"">
");
#nullable restore
#line 153 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
                             if (Model.Status == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""form-check"">
                                    <input class=""form-check-input"" type=""radio"" name=""BigImage"" id=""BigImage1"" value=""true"" disabled>
                                    <label class=""form-check-label"" for=""BigImage1"">
                                        Có
                                    </label>
                                </div>
                                <div class=""form-check"">
                                    <input class=""form-check-input"" type=""radio"" name=""BigImage"" id=""BigImage2"" value=""false"" checked>
                                    <label class=""form-check-label"" for=""BigImage2"">
                                        Không
                                    </label>
                                </div>
");
#nullable restore
#line 167 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 170 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
                                 if (Model.BigImage == true)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""form-check"">
                                        <input class=""form-check-input"" type=""radio"" name=""BigImage"" id=""BigImage1"" value=""true"" checked>
                                        <label class=""form-check-label"" for=""BigImage1"">
                                            Có
                                        </label>
                                    </div>
                                    <div class=""form-check"">
                                        <input class=""form-check-input"" type=""radio"" name=""BigImage"" id=""BigImage2"" value=""false"">
                                        <label class=""form-check-label"" for=""BigImage2"">
                                            Không
                                        </label>
                                    </div>
");
#nullable restore
#line 184 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""form-check"">
                                        <input class=""form-check-input"" type=""radio"" name=""BigImage"" id=""BigImage1"" value=""true"">
                                        <label class=""form-check-label"" for=""BigImage1"">
                                            Có
                                        </label>
                                    </div>
                                    <div class=""form-check"">
                                        <input class=""form-check-input"" type=""radio"" name=""BigImage"" id=""BigImage2"" value=""false"" checked>
                                        <label class=""form-check-label"" for=""BigImage2"">
                                            Không
                                        </label>
                                    </div>
");
#nullable restore
#line 199 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 199 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </fieldset>
                <div class=""form-group row"" style=""display:flex"">
                    <div class=""col-sm-2"">
                        <button type=""submit"" class=""btn btn-primary"">Xác nhận</button>
                    </div>
                    <div class=""col-sm-12 pt-3"">
                        <a class=""btn btn-primary"" href=""/admin/banner/index"">Quay lại</a>
                    </div>
                </div>
            </form>
        </div>
");
#nullable restore
#line 215 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\AddOrUpdate.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
