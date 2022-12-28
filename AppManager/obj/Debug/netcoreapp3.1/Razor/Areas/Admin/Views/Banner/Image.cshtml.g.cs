#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\Image.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1485dadaa9775845019db090ae86f945e3016d46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Banner_Image), @"mvc.1.0.view", @"/Areas/Admin/Views/Banner/Image.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1485dadaa9775845019db090ae86f945e3016d46", @"/Areas/Admin/Views/Banner/Image.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Banner_Image : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\Image.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Image";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-md-6"">
    <div class=""form-group"">
        <form class=""form-horizontal"" action=""/Admin/Banner/UpdateBannerImage"" method=""post"">
            <div class=""box-body"">
                <div class=""form-group"">
                    <input type=""text"" name=""bannerid""");
            BeginWriteAttribute("value", " value=\"", 383, "\"", 408, 1);
#nullable restore
#line 11 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\Image.cshtml"
WriteAttributeValue("", 391, ViewBag.bannerId, 391, 17, false);

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
                        <img");
            BeginWriteAttribute("src", " src=\"", 845, "\"", 871, 1);
#nullable restore
#line 17 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Banner\Image.cshtml"
WriteAttributeValue("", 851, ViewBag.bannerImage, 851, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""image-upload"" class=""rounded mx-auto d-block"" style=""width: 100%"" />
                    </div>
                </div>
                <div class=""form-group"">
                    <input type=""file"" name=""fileUpload"" id=""exampleInputFile"">
                    <i class=""help-block"">Upload ảnh của banner</i>
                </div>
                <div>
                    <button type=""submit"" class=""btn btn-primary"">Thêm ảnh</button>
                    <a href=""/admin/banner/index"" class=""btn btn-warning"">Trở về</a>
                </div>
            </div>
        </form>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).on('change', 'input[name=""fileUpload""]', function () {
            let files = $(this).prop(""files"");
            let formData = new FormData();
            formData.append(""file"", files[0]);
            $.ajax({
                url: ""/admin/banner/uploadfile"",
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
                    }
                    else {
                        alert(""Error!"");
                    }
                },
             ");
                WriteLiteral("   error: error => {\r\n                    console.log(error);\r\n                }\r\n            })\r\n        });\r\n    </script>\r\n");
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
