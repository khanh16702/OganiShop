#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82d7e40d2795d340a1200e5505062d2289ee51ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Image), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Image.cshtml")]
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
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
using AppManager.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82d7e40d2795d340a1200e5505062d2289ee51ab", @"/Areas/Admin/Views/Category/Image.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Category_Image : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CategoryImageModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Image";
    var avatar = ViewBag.categoryAvatar;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""box box-info"">
    <div class=""box-header"">
        <h3>Quản lý ảnh danh mục</h3>
        <a href=""/admin/category/index"" class=""btn btn-warning"">Quay về trang danh mục</a>
    </div>
    <div class=""container"">
        <div class=""row"" style=""overflow:hidden"">
            <div class=""col-md-6"">
                <form class=""form-horizontal"" action=""/Admin/Category/UpdateCategoryAvatar"" method=""post"">
                    <div class=""box-body"">
                        <div class=""form-group"">
                            <label class=""control-label"">Avatar:</label>
                            <input type=""text"" name=""categoryid""");
            BeginWriteAttribute("value", " value=\"", 872, "\"", 894, 1);
#nullable restore
#line 21 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
WriteAttributeValue("", 880, ViewBag.catId, 880, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>\r\n                            <input type=\"text\" name=\"id\" id=\"cat-avatar-id\"");
            BeginWriteAttribute("value", " value=\"", 980, "\"", 998, 1);
#nullable restore
#line 22 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
WriteAttributeValue("", 988, avatar.Id, 988, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>\r\n                            <input type=\"text\" id=\"cat-delete-id\" value=\"-1\" hidden />\r\n                            <div class=\"text-center\">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 1188, "\"", 1210, 1);
#nullable restore
#line 25 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
WriteAttributeValue("", 1194, avatar.FilePath, 1194, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""cat-image-avatar"" class=""rounded mx-auto d-block"" style=""width: 256px"" />
                            </div>
                        </div>
                        <div class=""form-group"" style=""padding-top: 1rem; padding-bottom: 1rem"">
                            <i>Chọn một trong những ảnh dưới đây đặt làm ảnh đại diện cho danh mục</i>
                        </div>
                        <div class=""form-group text-center"">
");
#nullable restore
#line 32 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
                              
                                foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <div class=\"col-sm-3\">\r\n                                                <img");
            BeginWriteAttribute("src", " src=\"", 1903, "\"", 1923, 1);
#nullable restore
#line 36 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
WriteAttributeValue("", 1909, item.FilePath, 1909, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1924, "\"", 1937, 1);
#nullable restore
#line 36 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
WriteAttributeValue("", 1929, item.Id, 1929, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"cat-list-image rounded mx-auto d-block\" style=\"width: 128px\" />\r\n                                            </div>\r\n");
#nullable restore
#line 38 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                    <div class=""box-footer"">
                        <button class=""btn btn-danger pull-right"" id=""cat-deleteBtn"" style=""margin-left: 10px"">Xóa</button>
                        <button type=""submit"" class=""btn btn-primary pull-right"" id=""cat-update-avatar"">Xác nhận</button>
                    </div>
                </form>
            </div>
            <div class=""col-md-6"">
                <div class=""form-group"">
                    <form class=""form-horizontal"" action=""/Admin/Category/UpdateCategoryImage"" method=""post"">
                        <div class=""box-body"">
                            <div class=""form-group"">
                                <input type=""text"" name=""categoryid""");
            BeginWriteAttribute("value", " value=\"", 2915, "\"", 2937, 1);
#nullable restore
#line 53 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Image.cshtml"
WriteAttributeValue("", 2923, ViewBag.catId, 2923, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" hidden>
                                <input type=""text"" id=""image-file-path"" name=""filePath"" hidden>
                                <input type=""text"" id=""image-file-id"" name=""fileId"" hidden>
                                <input type=""text"" id=""image-name"" name=""name"" hidden />
                                <label class=""control-label"" for=""exampleInputPassword1"">Upload ảnh</label>
                                <div class=""col-md-12 text-center"">
                                    <img src=""/img/default.jpg"" id=""image-upload"" class=""rounded mx-auto d-block"" style=""width: 256px"" />
                                </div>
                            </div>
                            <div class=""form-group"">
                                <input type=""file"" name=""fileUpload"" id=""exampleInputFile"">
                                <i class=""help-block"">Upload ảnh của sản phẩm</i>
                            </div>
                            <div class=""box-footer"">
                     ");
            WriteLiteral(@"           <button type=""submit"" class=""btn btn-primary pull-right"">Thêm ảnh</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
        <script>
            $('.cat-list-image').click(function () {
                $('#cat-image-avatar').attr(""src"", $(this).attr(""src""));
                $('#cat-avatar-id').val($(this).attr(""id""));
                $('#cat-delete-id').val($(this).attr(""id""));
            });

            $('#cat-update-avatar').click(function () {
                alert(""Thay đổi ảnh đại diện của danh mục thành công!"");
            });

            $(document).on('click', 'button[id=""cat-deleteBtn""]', function () {
                let deleteId = $('#cat-delete-id').val();
                $.ajax({
                    url: ""/admin/category/deleteimage?id="" + deleteId,
                    type: ""POST"",
                    data: '',
                    contentType: false,
                    processData: false,
                    beforeSend: () => {

                    },
                    success: res => {
                        if (res.status == 'success') {
                            alert(""");
                WriteLiteral(@"Xóa ảnh thành công!"");
                            location.reload();
                        }
                        else {
                            alert(""Error!"");
                        }
                    },
                    error: error => {
                        console.log(error);
                    }
                })
            });

            $(document).on('change', 'input[name=""fileUpload""]', function () {
                let files = $(this).prop(""files"");
                let formData = new FormData();
                formData.append(""file"", files[0]);
                $.ajax({
                    url: ""/admin/category/uploadfile"",
                    type: ""POST"",
                    data: formData,
                    contentType: false,
                    processData: false,
                    beforeSend: () => {

                    },
                    success: res => {
                        if (res.status == 'success') {
                    ");
                WriteLiteral(@"        $('#image-upload').attr('src', res.fileInfo.filePath);
                            $('#image-file-path').val(res.fileInfo.filePath);
                            $('#image-file-id').val(res.fileInfo.id);
                            $('#image-name').val(res.fileInfo.Name)
                        }
                        else {
                            alert(""Error!"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CategoryImageModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591