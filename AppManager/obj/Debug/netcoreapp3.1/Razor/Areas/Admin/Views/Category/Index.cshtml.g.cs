#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bfc427afcf813b5a996d011512628ebdd6f8b8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bfc427afcf813b5a996d011512628ebdd6f8b8d", @"/Areas/Admin/Views/Category/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Index.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Quản lý danh mục";
    string name = ViewBag.name;



#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Quản lý danh mục</h2>

<div class=""row"">
    <div class=""col-md-12"">
        <div style=""display:flex;justify-content:space-between;align-items:center"">
            <div class=""row"">
                <div class=""col-lg-4"">
                    <div class=""form-inline mb-4"" style=""display:flex"">
                        <input type=""text"" name=""freetext""");
            BeginWriteAttribute("value", " value=\"", 514, "\"", 527, 1);
#nullable restore
#line 17 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Category\Index.cshtml"
WriteAttributeValue("", 522, name, 522, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control"" placeholder=""Nhập danh mục..."" />
                        <button class=""btn btn-primary ml-3"" id=""searchCategory"">Tìm kiếm</button>
                    </div>
                </div>
                <input type=""number"" name=""PageNumber"" id=""txtPageNumberCat"" value=""1"" hidden />
            </div>
            <a href=""/admin/category/AddOrUpdate"" class=""btn btn-primary"" style=""height:50%"">Thêm danh mục mới</a>
        </div>

        <table class=""table table-bordered table-striped"" id=""categoryTable"">
            <thead>
                <tr>
                    <th>STT</th>
                    <th>Mã phân loại</th>
                    <th>Loại sản phẩm</th>
                    <th>Slug</th>
                    <th>Mô tả</th>
                    <th>Tình trạng dùng</th>
                    <th>Thao tác</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function clickPage(pageNumber) {
            document.getElementById(""txtPageNumber"").value = pageNumber;
            document.getElementById(""formSearch"").submit();
        }

        let req = {
            PageSize: 10,
            PageNumber: 1
        };
        req.Freetext = $('input[name=""freetext""]').val()
        getData(req);

        $('#searchCategory').click(function () {
            req.Freetext = $('input[name=""freetext""]').val()
            getData(req);
        });

        function getData(obj) {
            $.ajax({
                url: ""/admin/category/GetData"",
                type: ""POST"",
                datatype: ""json"",
                contentType: ""application/json"",
                data: JSON.stringify(obj),
                beforeSend: function () {

                },
                success: function (res) {
                    $('#categoryTable tbody').html('');
                    res.data.forEach(function (item, index) {
  ");
                WriteLiteral(@"                      var str;
                        if (item.status == 1) {
                            str = ""Còn dùng"";
                        } else {
                            str = ""Không dùng""
                        }
                        let row = `<tr>
                                                <td>${index + 1}</td>
                                                <td>${item.id}</td>
                                                <td>${item.name}</td>>
                                                <td>${item.slug}</td>
                                                <td>${item.description}</td>
                                                <td>${str}</td>
                                                <td>
                                                    <a href=""/Admin/Category/Image?id=${item.id}"" class=""btn btn-warning"" style=""color: white"">Ảnh</a>
                                                    <a href=""/Admin/Category/AddOrUpdate?id=${item.id}"" class=""btn");
                WriteLiteral(@" btn-primary"" style=""color: white"">Sửa</a>
                                                    <a href=""/Admin/Category/Delete?id=${item.id}"" class=""btn btn-danger"" style=""color: white"">Xóa</a>
                                                </td>
                                            </tr>`;
                        $('#categoryTable tbody').append(row);
                    });
                }
            })
        }
    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
