#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3697b224439546008cf24a35c3beafb59fb5b81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/Index.cshtml")]
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
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
using AppManager.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3697b224439546008cf24a35c3beafb59fb5b81", @"/Areas/Admin/Views/Product/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Quản lý sản phẩm";
    int pageCount = (int)ViewBag.pageCount;
    int pageNumber = (int)ViewBag.pageNumber;
    int pageSize = (int)ViewBag.pageSize;
    int stt = pageNumber * pageSize - pageSize + 1;
    string name = ViewBag.name;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2 class=""py-5"">Danh sách sản phẩm</h2>
<div style=""justify-content:space-between;display:flex;align-items:center"">
    <form action=""/Admin/Product/"" method=""get"" id=""formSearch"">
        <div class=""row"">
            <div class=""col-lg-4"">
                <div class=""form-inline mb-4"" style=""display:flex"">
                    <input type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 772, "\"", 785, 1);
#nullable restore
#line 20 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 780, name, 780, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control"" placeholder=""Nhập sản phẩm..."" />
                    <button class=""btn btn-primary ml-3"">Tìm kiếm</button>
                </div>
            </div>
            <input type=""number"" name=""pageNumber"" id=""txtPageNumber"" value=""1"" hidden />
        </div>
    </form>
    <a class=""btn btn-primary"" style=""height:50%""");
            BeginWriteAttribute("href", " href=\"", 1132, "\"", 1188, 2);
            WriteAttributeValue("", 1139, "/admin/product/AddOrUpdate?pageNumber=", 1139, 38, true);
#nullable restore
#line 27 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 1177, pageNumber, 1177, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Thêm mới sản phẩm</a>
</div>
<table class=""table table-bordered table-striped"">
    <thead>
        <tr>
            <th>STT</th>
            <th>Mã sản phẩm</th>
            <th>Tên sản phẩm</th>
            <th>Slug</th>
            <th>Giá bán</th>
            <th>Giá cũ</th>
            <th>Số lượng</th>
            <th>Trọng lượng</th>
            <th>Phân loại</th>
            <th>Ngày tạo</th>
            <th>Tình trạng bán</th>
            <th>Thao tác</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 47 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
          
            foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 51 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(stt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 52 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 53 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 54 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.Slug);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 55 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.Price.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 56 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.OldPrice.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 57 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 58 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.Weight);

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                               Write(item.Unit);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                    <td>");
#nullable restore
#line 59 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 60 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                   Write(item.CreateDate.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 61 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                      
                        if (item.Status == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>Còn bán</td>\r\n");
#nullable restore
#line 65 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>Không bán</td>\r\n");
#nullable restore
#line 69 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2682, "\"", 2748, 4);
            WriteAttributeValue("", 2689, "/Admin/Product/ImageList?id=", 2689, 28, true);
#nullable restore
#line 72 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2717, item.Id, 2717, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2725, "&pageNumber=", 2725, 12, true);
#nullable restore
#line 72 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2737, pageNumber, 2737, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\" style=\"color: white\">Ảnh</a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2830, "\"", 2898, 4);
            WriteAttributeValue("", 2837, "/Admin/Product/AddOrUpdate?id=", 2837, 30, true);
#nullable restore
#line 73 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2867, item.Id, 2867, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2875, "&pageNumber=", 2875, 12, true);
#nullable restore
#line 73 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 2887, pageNumber, 2887, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\" style=\"color: white\">Sửa</a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2980, "\"", 3043, 4);
            WriteAttributeValue("", 2987, "/Admin/Product/Delete?id=", 2987, 25, true);
#nullable restore
#line 74 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 3012, item.Id, 3012, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3020, "&pageNumber=", 3020, 12, true);
#nullable restore
#line 74 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 3032, pageNumber, 3032, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\" style=\"color: white\">Xóa</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 77 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                stt++;
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n<nav aria-label=\"Page navigation example\">\r\n    <ul class=\"pagination\">\r\n        <li class=\"page-item\">\r\n            <a class=\"page-link\" href=\"#\" aria-label=\"Previous\">\r\n                <span aria-hidden=\"true\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3437, "\"", 3482, 2);
            WriteAttributeValue("", 3447, "clickPage(", 3447, 10, true);
#nullable restore
#line 88 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 3457, Math.Max(pageNumber-1,1), 3457, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&laquo;</span>\r\n                <span class=\"sr-only\">Previous</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 92 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
         for (int i = 1; i <= pageCount; ++i)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\"><a class=\"page-link\" href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3709, "\"", 3732, 3);
            WriteAttributeValue("", 3719, "clickPage(", 3719, 10, true);
#nullable restore
#line 94 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 3729, i, 3729, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3731, ")", 3731, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 94 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
                                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 95 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link\" href=\"#\" aria-label=\"Next\">\r\n                <span aria-hidden=\"true\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3892, "\"", 3945, 2);
            WriteAttributeValue("", 3902, "clickPage(", 3902, 10, true);
#nullable restore
#line 98 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Product\Index.cshtml"
WriteAttributeValue("", 3912, Math.Min(pageNumber+1,pageCount), 3912, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&raquo;</span>\r\n                <span class=\"sr-only\">Next</span>\r\n            </a>\r\n        </li>\r\n    </ul>\r\n</nav>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        function clickPage(pageNumber) {\r\n            document.getElementById(\"txtPageNumber\").value = pageNumber;\r\n            document.getElementById(\"formSearch\").submit();\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("   ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
