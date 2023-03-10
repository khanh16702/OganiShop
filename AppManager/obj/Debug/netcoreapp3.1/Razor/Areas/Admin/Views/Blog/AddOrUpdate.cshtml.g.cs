#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6aacb85f8eb4576eed146bfce00d9b775714a012"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Blog_AddOrUpdate), @"mvc.1.0.view", @"/Areas/Admin/Views/Blog/AddOrUpdate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6aacb85f8eb4576eed146bfce00d9b775714a012", @"/Areas/Admin/Views/Blog/AddOrUpdate.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Blog_AddOrUpdate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Dashboard";
    string error = TempData["error"] as string;
    var pageNumber = (int)ViewBag.pageNumber;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"py-5\">Cập nhật thông tin blog</h2>\r\n");
#nullable restore
#line 9 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
 if (!string.IsNullOrEmpty(error))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"text-danger\">");
#nullable restore
#line 11 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
                      Write(error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 12 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 14 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
     if (Model.Id == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-md-8"">
            <form action=""/admin/blog/AddOrUpdate"" method=""post"">
                <div class=""form-group row"">
                    <label for=""productname"" class=""col-sm-2 col-form-label"">Tiêu đề:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""title"" class=""form-control"" id=""productname"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productcategory"" class=""col-sm-2 col-form-label"">Mã phân loại:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""blogcategoryid"" class=""form-control"" id=""productcategory"">
                    </div>
                </div>
                <div class=""form-group"">
                    <input type=""text"" name=""imagepath"" id=""blog-avatar"" hidden />
                    <input type=""text"" id=""image-file-path"" name=""filePath"" hidden>
                    <inp");
            WriteLiteral(@"ut type=""text"" id=""image-file-id"" name=""fileId"" hidden>
                    <input type=""text"" id=""image-name"" name=""name"" hidden />
                    <label class=""control-label"" for=""exampleInputPassword1"">Upload ảnh</label>
                    <div class=""col-md-12 text-center"">
                        <img src=""/img/default.jpg"" id=""image-upload"" class=""rounded mx-auto d-block"" style=""width: 256px"" />
                    </div>
                </div>
                <div class=""form-group"">
                    <input type=""file"" name=""fileUpload"" id=""exampleInputFile"">
                    <i class=""help-block"">Upload ảnh blog</i>
                </div>
                <div class=""form-group row"">
                    <label for=""productsummary"" class=""col-sm-2 col-form-label"">Tóm tắt:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""summary"" class=""form-control"" id=""productsummary"">
                    </div>
                </div>
    ");
            WriteLiteral(@"            <div class=""form-group row"">
                    <label for=""productsummary"" class=""col-sm-2 col-form-label"">Nội dung:</label>
                    <div class=""col-sm-10"">
                        <textarea name=""content"" id=""editor""></textarea>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productsummary"" class=""col-sm-2 col-form-label"">Tags:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""tagsname"" class=""form-control"" id=""producttags"">
                    </div>
                </div>
                <div class=""form-group row"" style=""display:flex"">
                    <div class=""col-sm-2"">
                        <button type=""submit"" class=""btn btn-primary"">Xác nhận</button>
                    </div>
                    <div class=""col-sm-12 pt-3"">
                        <a class=""btn btn-primary""");
            BeginWriteAttribute("href", " href=\"", 3406, "\"", 3453, 2);
            WriteAttributeValue("", 3413, "/admin/blog/index?pageNumber=", 3413, 29, true);
#nullable restore
#line 67 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 3442, pageNumber, 3442, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Quay lại</a>\r\n                    </div>\r\n                </div>\r\n            </form>\r\n        </div>\r\n");
#nullable restore
#line 72 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-8\">\r\n            <form");
            BeginWriteAttribute("action", " action=\"", 3631, "\"", 3686, 2);
            WriteAttributeValue("", 3640, "/admin/blog/AddOrUpdate?pageNumber=", 3640, 35, true);
#nullable restore
#line 76 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 3675, pageNumber, 3675, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" method=""post"">
                <div class=""form-group row"">
                    <label for=""productid"" class=""col-sm-2 col-form-label"">Mã blog</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""id"" class=""form-control"" id=""productid""");
            BeginWriteAttribute("value", " value=\"", 3975, "\"", 3992, 1);
#nullable restore
#line 80 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 3983, Model.Id, 3983, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productname"" class=""col-sm-2 col-form-label"">Tiêu đề:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""title"" class=""form-control"" id=""productname""");
            BeginWriteAttribute("value", " value=\"", 4336, "\"", 4356, 1);
#nullable restore
#line 86 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 4344, Model.Title, 4344, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productcategory"" class=""col-sm-2 col-form-label"">Mã phân loại:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""blogcategoryid"" class=""form-control"" id=""productcategory""");
            BeginWriteAttribute("value", " value=\"", 4713, "\"", 4742, 1);
#nullable restore
#line 92 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 4721, Model.BlogCategoryId, 4721, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <input type=\"text\" name=\"imagepath\" id=\"blog-avatar\"");
            BeginWriteAttribute("value", " value=\"", 4912, "\"", 4936, 1);
#nullable restore
#line 96 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 4920, Model.ImagePath, 4920, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" hidden />
                    <input type=""text"" id=""image-file-path"" name=""filePath"" hidden>
                    <input type=""text"" id=""image-file-id"" name=""fileId"" hidden>
                    <input type=""text"" id=""image-name"" name=""name"" hidden />
                    <label class=""control-label"" for=""exampleInputPassword1"">Upload ảnh</label>
                    <div class=""col-md-12 text-center"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 5375, "\"", 5397, 1);
#nullable restore
#line 102 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 5381, Model.ImagePath, 5381, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""image-upload"" class=""rounded mx-auto d-block"" style=""width: 256px"" />
                    </div>
                </div>
                <div class=""form-group"">
                    <input type=""file"" name=""fileUpload"" id=""exampleInputFile"">
                    <i class=""help-block"">Upload ảnh blog</i>
                </div>
                <div class=""form-group row"">
                    <label for=""productsummary"" class=""col-sm-2 col-form-label"">Tóm tắt:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""summary"" class=""form-control"" id=""productsummary""");
            BeginWriteAttribute("value", " value=\"", 6023, "\"", 6045, 1);
#nullable restore
#line 112 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 6031, Model.Summary, 6031, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productsummary"" class=""col-sm-2 col-form-label"">Nội dung:</label>
                    <div class=""col-sm-10"">
                        <textarea name=""content"" id=""editor"">");
#nullable restore
#line 118 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
                                                        Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</textarea>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label for=""productsummary"" class=""col-sm-2 col-form-label"">Tags:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" name=""tagsname"" class=""form-control"" id=""producttags""");
            BeginWriteAttribute("value", " value=\"", 6713, "\"", 6736, 1);
#nullable restore
#line 124 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 6721, Model.TagsName, 6721, 15, false);

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
            BeginWriteAttribute("value", " value=\"", 7077, "\"", 7101, 1);
#nullable restore
#line 130 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 7085, Model.CreatedBy, 7085, 16, false);

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
            BeginWriteAttribute("value", " value=\"", 7453, "\"", 7478, 1);
#nullable restore
#line 136 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 7461, Model.CreateDate, 7461, 17, false);

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
            BeginWriteAttribute("value", " value=\"", 7833, "\"", 7857, 1);
#nullable restore
#line 142 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 7841, Model.UpdatedBy, 7841, 16, false);

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
            BeginWriteAttribute("value", " value=\"", 8214, "\"", 8239, 1);
#nullable restore
#line 148 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 8222, Model.UpdateDate, 8222, 17, false);

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
#line 155 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
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
#line 169 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
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
#line 184 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
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
            BeginWriteAttribute("href", " href=\"", 10776, "\"", 10823, 2);
            WriteAttributeValue("", 10783, "/admin/blog/index?pageNumber=", 10783, 29, true);
#nullable restore
#line 193 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
WriteAttributeValue("", 10812, pageNumber, 10812, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Quay lại</a>\r\n                    </div>\r\n                </div>\r\n            </form>\r\n        </div>\r\n");
#nullable restore
#line 198 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\AddOrUpdate.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).on('change', 'input[name=""fileUpload""]', function () {
            let files = $(this).prop(""files"");
            let formData = new FormData();
            formData.append(""file"", files[0]);
            console.log(formData)
            $.ajax({
                url: ""/admin/blog/uploadfile"",
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
                        $('#blog-avatar').val(res.fileInfo.filePath);

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

        ClassicEditor
            .create(document.querySelector('#editor'))
            .catch(error => {
                console.error(error);
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
