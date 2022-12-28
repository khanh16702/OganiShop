#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d290fa53eccb78c475fbc016b890c0f2715cd8db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_DiscountCode_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/DiscountCode/Index.cshtml")]
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
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
using AppManager.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d290fa53eccb78c475fbc016b890c0f2715cd8db", @"/Areas/Admin/Views/DiscountCode/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_DiscountCode_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DiscountCodeModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Quản lý banner";
    int pageCount = (int)ViewBag.pageCount;
    int pageNumber = (int)ViewBag.pageNumber;
    int pageSize = (int)ViewBag.pageSize;
    int stt = pageNumber * pageSize - pageSize + 1;
    string name = ViewBag.name;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2 class=""py-5"">Danh sách banner</h2>
<div style=""justify-content:space-between;display:flex;align-items:center"">
    <form action=""/Admin/DiscountCode/"" method=""get"" id=""formSearch"">
        <div class=""row"">
            <div class=""col-lg-4"">
                <div class=""form-inline mb-4"" style=""display:flex"">
                    <input type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 774, "\"", 787, 1);
#nullable restore
#line 20 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
WriteAttributeValue("", 782, name, 782, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control"" placeholder=""Nhập tên mã..."" />
                    <button class=""btn btn-primary ml-3"">Tìm kiếm</button>
                </div>
            </div>
            <input type=""number"" name=""pageNumber"" id=""txtPageNumber"" value=""1"" hidden />
        </div>
    </form>
    <a class=""btn btn-primary"" style=""height:50%""");
            BeginWriteAttribute("href", " href=\"", 1132, "\"", 1193, 2);
            WriteAttributeValue("", 1139, "/admin/discountcode/AddOrUpdate?pageNumber=", 1139, 43, true);
#nullable restore
#line 27 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
WriteAttributeValue("", 1182, pageNumber, 1182, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Thêm mới mã giảm giá</a>
</div>
<table class=""table table-bordered table-striped"">
    <thead>
        <tr>
            <th>STT</th>
            <th>Mã giảm giá</th>
            <th>Tên mã giảm giá</th>
            <th>Số tiền giảm</th>
            <th>Thao tác</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 40 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
          
            foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 44 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
                   Write(stt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 45 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 46 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 47 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
                   Write(item.ReducedAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("$</td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1822, "\"", 1890, 4);
            WriteAttributeValue("", 1829, "/Admin/discountcode/Delete?id=", 1829, 30, true);
#nullable restore
#line 49 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
WriteAttributeValue("", 1859, item.Id, 1859, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1867, "&pageNumber=", 1867, 12, true);
#nullable restore
#line 49 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
WriteAttributeValue("", 1879, pageNumber, 1879, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\" style=\"color: white\">Xóa</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 52 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
                stt++;
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n<nav aria-label=\"Page navigation example\">\r\n    <ul class=\"pagination\">\r\n        <li class=\"page-item\">\r\n            <a class=\"page-link\" href=\"#\" aria-label=\"Previous\">\r\n                <span aria-hidden=\"true\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2284, "\"", 2329, 2);
            WriteAttributeValue("", 2294, "clickPage(", 2294, 10, true);
#nullable restore
#line 63 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
WriteAttributeValue("", 2304, Math.Max(pageNumber-1,1), 2304, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&laquo;</span>\r\n                <span class=\"sr-only\">Previous</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 67 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
         for (int i = 1; i <= pageCount; ++i)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\"><a class=\"page-link\" href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2556, "\"", 2579, 3);
            WriteAttributeValue("", 2566, "clickPage(", 2566, 10, true);
#nullable restore
#line 69 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
WriteAttributeValue("", 2576, i, 2576, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2578, ")", 2578, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 69 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
                                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 70 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link\" href=\"#\" aria-label=\"Next\">\r\n                <span aria-hidden=\"true\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2739, "\"", 2792, 2);
            WriteAttributeValue("", 2749, "clickPage(", 2749, 10, true);
#nullable restore
#line 73 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\DiscountCode\Index.cshtml"
WriteAttributeValue("", 2759, Math.Min(pageNumber+1,pageCount), 2759, 33, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DiscountCodeModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591