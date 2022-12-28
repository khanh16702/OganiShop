#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7349a39abea5f9cd8ddceec650d62b1b6317cd17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Blog_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Blog/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7349a39abea5f9cd8ddceec650d62b1b6317cd17", @"/Areas/Admin/Views/Blog/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Quản lý blog";
    int pageCount = (int)ViewBag.pageCount;
    int pageNumber = (int)ViewBag.pageNumber;
    int pageSize = (int)ViewBag.pageSize;
    int stt = pageNumber * pageSize - pageSize + 1;
    string title = ViewBag.title;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2 class=""py-5"">Danh sách blog</h2>
<div style=""justify-content:space-between;display:flex;align-items:center"">
    <form action=""/Admin/Blog/"" method=""get"" id=""formSearch"">
        <div class=""row"">
            <div class=""col-lg-4"">
                <div class=""form-inline mb-4"" style=""display:flex"">
                    <input type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 692, "\"", 706, 1);
#nullable restore
#line 17 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 700, title, 700, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""form-control"" placeholder=""Nhập tiêu đề..."" />
                    <button class=""btn btn-primary ml-3"">Tìm kiếm</button>
                </div>
            </div>
            <input type=""number"" name=""pageNumber"" id=""txtPageNumber"" value=""1"" hidden />
        </div>
    </form>
    <a class=""btn btn-primary"" style=""height:50%""");
            BeginWriteAttribute("href", " href=\"", 1052, "\"", 1105, 2);
            WriteAttributeValue("", 1059, "/admin/blog/AddOrUpdate?pageNumber=", 1059, 35, true);
#nullable restore
#line 24 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1094, pageNumber, 1094, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Thêm mới blog</a>
</div>
<table class=""table table-bordered table-striped"">
    <thead>
        <tr>
            <th>STT</th>
            <th>Mã blog</th>
            <th>Ảnh</th>
            <th>Tiêu đề</th>
            <th>Slug</th>
            <th>Phân loại</th>
            <th>Số bình luận</th>
            <th>Ngày tạo</th>
            <th>Tình trạng dùng</th>
            <th>Thao tác</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 42 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
          
            foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 46 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                       Write(stt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 47 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1799, "\"", 1820, 1);
#nullable restore
#line 49 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1805, item.ImagePath, 1805, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:128px\"/>\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 51 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 52 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                       Write(item.Slug);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 53 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                       Write(item.BlogCategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 54 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                       Write(item.Comments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 55 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                       Write(item.CreateDate.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 56 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                          
                            if (item.Status == 1) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Còn dùng</td>\r\n");
#nullable restore
#line 59 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                            }
                            else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Không dùng</td>\r\n");
#nullable restore
#line 62 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2517, "\"", 2582, 4);
            WriteAttributeValue("", 2524, "/Admin/Blog/AddOrUpdate?id=", 2524, 27, true);
#nullable restore
#line 65 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 2551, item.Id, 2551, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2559, "&pageNumber=", 2559, 12, true);
#nullable restore
#line 65 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 2571, pageNumber, 2571, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\" style=\"color: white\">Sửa</a>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2668, "\"", 2728, 4);
            WriteAttributeValue("", 2675, "/Admin/Blog/Delete?id=", 2675, 22, true);
#nullable restore
#line 66 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 2697, item.Id, 2697, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2705, "&pageNumber=", 2705, 12, true);
#nullable restore
#line 66 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 2717, pageNumber, 2717, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\" style=\"color: white\">Xóa</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 69 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                stt++;
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n<nav aria-label=\"Page navigation example\">\r\n    <ul class=\"pagination\">\r\n        <li class=\"page-item\">\r\n            <a class=\"page-link\" href=\"#\" aria-label=\"Previous\">\r\n                <span aria-hidden=\"true\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3130, "\"", 3175, 2);
            WriteAttributeValue("", 3140, "clickPage(", 3140, 10, true);
#nullable restore
#line 80 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3150, Math.Max(pageNumber-1,1), 3150, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">&laquo;</span>\r\n                <span class=\"sr-only\">Previous</span>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 84 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
         for (int i = 1; i <= pageCount; ++i)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\"><a class=\"page-link\" href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3402, "\"", 3425, 3);
            WriteAttributeValue("", 3412, "clickPage(", 3412, 10, true);
#nullable restore
#line 86 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3422, i, 3422, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3424, ")", 3424, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 86 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
                                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 87 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link\" href=\"#\" aria-label=\"Next\">\r\n                <span aria-hidden=\"true\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3585, "\"", 3638, 2);
            WriteAttributeValue("", 3595, "clickPage(", 3595, 10, true);
#nullable restore
#line 90 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3605, Math.Min(pageNumber+1,pageCount), 3605, 33, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591