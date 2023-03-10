#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ecfdbe61651aa30940fc1d7577ae35c94c90fe5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_ShopDetails), @"mvc.1.0.view", @"/Views/Products/ShopDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ecfdbe61651aa30940fc1d7577ae35c94c90fe5", @"/Views/Products/ShopDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39bdf4e2eeb9182a14600fe5d339bdb2f9540938", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_ShopDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
  
    var price = Model.Price.ToString("0.00");
    ViewData["Title"] = "Product Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Breadcrumb Section Begin -->
<section class=""breadcrumb-section set-bg"" data-setbg=""/img/breadcrumb.jpg"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12 text-center"">
                <div class=""breadcrumb__text"">
                    <h2>");
#nullable restore
#line 12 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <div class=\"breadcrumb__option\">\r\n                        <a href=\"/Home/Index\">Home</a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 543, "\"", 596, 2);
            WriteAttributeValue("", 550, "/products/index?categoryId=", 550, 27, true);
#nullable restore
#line 15 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
WriteAttributeValue("", 577, ViewBag.categoryId, 577, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 15 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                                                            Write(ViewBag.categoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        <span>");
#nullable restore
#line 16 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                         Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Breadcrumb Section End -->
<!-- Product Details Section Begin -->
<section class=""product-details spad"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6 col-md-6"">
                <div class=""product__details__pic"">
                    <div class=""product__details__pic__item"">
                        <img class=""product__details__pic__item--large""");
            BeginWriteAttribute("src", "\r\n                             src=\"", 1188, "\"", 1240, 1);
#nullable restore
#line 32 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
WriteAttributeValue("", 1224, Model.ImagePath, 1224, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1241, "\"", 1247, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </div>\r\n                    <div class=\"product__details__pic__slider owl-carousel\" id=\"product-images\">\r\n");
#nullable restore
#line 35 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                          
                            foreach(var path in Model.Images) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                                            <img data-imgbigurl=\"");
#nullable restore
#line 37 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                                                                                            Write(path);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("src", "\r\n                                                                                             src=\"", 1589, "\"", 1694, 1);
#nullable restore
#line 38 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
WriteAttributeValue("", 1689, path, 1689, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1695, "\"", 1701, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 39 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6 col-md-6\">\r\n                <div class=\"product__details__text\">\r\n                    <h3>");
#nullable restore
#line 46 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                    <div class=""product__details__rating"">
                        <i class=""fa fa-star""></i>
                        <i class=""fa fa-star""></i>
                        <i class=""fa fa-star""></i>
                        <i class=""fa fa-star""></i>
                        <i class=""fa fa-star-half-o""></i>
                        <span>(18 reviews)</span>
                    </div>
                    <div class=""product__details__price"">$");
#nullable restore
#line 55 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                                     Write(price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <p>\r\n                        ");
#nullable restore
#line 57 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                   Write(Model.SummaryContent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                    <div class=""product__details__quantity"">
                        <div class=""quantity"">
                            <div class=""pro-qty"">
                                <input type=""text"" value=""1"" id=""buy-quantity"">
                            </div>
                        </div>
                    </div>
");
#nullable restore
#line 66 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                      
                        if (Model.Status == 1 && Model.Quantity > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                                        <a onclick=\"addToCart()\" class=\"btn primary-btn\" style=\"color:white\">ADD TO CARD</a>\r\n");
#nullable restore
#line 69 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                        }
                        else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                                        <a class=\"disabled-btn\">ADD TO CARD</a>\r\n");
#nullable restore
#line 72 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a href=\"#\" class=\"heart-icon\"><span class=\"icon_heart_alt\"></span></a>\r\n                    <ul>\r\n                        <li><b>Availability</b> \r\n");
#nullable restore
#line 77 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                              
                                if (Model.Status == 1 && Model.Quantity > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                                                                <span>In Stock</span>\r\n");
#nullable restore
#line 80 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                }
                                else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                                                                <span>Contact</span>\r\n");
#nullable restore
#line 83 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </li>\r\n                        <li><b>Shipping</b> <span>01 day shipping. <samp>Free pickup today</samp></span></li>\r\n                        <li><b>Weight</b> <span>");
#nullable restore
#line 87 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                           Write(Model.Weight);

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                                        Write(Model.Unit);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></li>
                        <li>
                            <b>Share on</b>
                            <div class=""share"">
                                <a href=""#""><i class=""fa fa-facebook""></i></a>
                                <a href=""#""><i class=""fa fa-twitter""></i></a>
                                <a href=""#""><i class=""fa fa-instagram""></i></a>
                                <a href=""#""><i class=""fa fa-pinterest""></i></a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div class=""col-lg-12"">
                <div class=""product__details__tab"">
                    <ul class=""nav nav-tabs"" role=""tablist"">
                        <li class=""nav-item"">
                            <a class=""nav-link active"" data-toggle=""tab"" href=""#tabs-1"" role=""tab""
                               aria-selected=""true"">Description</a>
                        </li>
                        <li ");
            WriteLiteral(@"class=""nav-item"">
                            <a class=""nav-link"" data-toggle=""tab"" href=""#tabs-3"" role=""tab""
                               aria-selected=""false"">Reviews <span>(1)</span></a>
                        </li>
                    </ul>
                    <div class=""tab-content"">
                        <div class=""tab-pane active"" id=""tabs-1"" role=""tabpanel"">
                            <div class=""product__details__tab__desc"">
                                <h6>Products Description</h6>
                                <p>
                                    ");
#nullable restore
#line 117 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                               Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </p>
                            </div>
                        </div>
                        <div class=""tab-pane"" id=""tabs-3"" role=""tabpanel"">
                            <div class=""product__details__tab__desc"">
                                <h6>Reivews</h6>
                                <p>
                                    Review
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Product Details Section End -->
<!-- Related Product Section Begin -->
<section class=""related-product"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""section-title related__product__title"">
                    <h2>Related Product</h2>
                </div>
            </div>
        </div>
        <div class=""row"" id=""related-pr");
            WriteLiteral("oduct\">\r\n\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Related Product Section End -->\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $.ajax({\r\n            url: \"/products/GetRelatedProduct?categoryId=\" + ");
#nullable restore
#line 156 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                                        Write(Model.CategoryId);

#line default
#line hidden
#nullable disable
                WriteLiteral(" + \"&thisId=\" + ");
#nullable restore
#line 156 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                                                                         Write(Model.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
            type: ""GET"",
            dataType: ""json"",
            success: function(data) {
                var count = 0;
                $('related-product').html('');
                data.forEach(function(item,index) {
                    if (count == 4) {
                        return;
                    }
                    let row = `<div class=""col-lg-3 col-md-4 col-sm-6"">
                        <div class=""product__item"">
                            <div class=""product__item__pic set-bg"" style=""background-image:url(${item.imagePath});"">
                                <ul class=""product__item__pic__hover"">
                                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                    <li><a href=""#""><i class=""fa fa-retweet""></i></a></li>
                                    <li><a href=""#""><i class=""fa fa-shopping-cart""></i></a></li>
                                </ul>
                            </div>
                          ");
                WriteLiteral("  <div class=\"product__item__text\">\r\n");
                WriteLiteral(@"                                <h6><a href=""/products/shopdetails?productId=${item.id}"">${item.name}</a></h6>
                                <h5>$${item.price}</h5>
                            </div>
                        </div>
                    </div>`
                    $('#related-product').append(row);
                    count += 1;
                }) 
            },
            error: error => {
                console.log(error);
            }
        })

        function addToCart() {
            var quantity = $('#buy-quantity').val();
            $.ajax({
                url: ""/products/AddToCart?productId="" + ");
#nullable restore
#line 194 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                                   Write(Model.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" + ""&quantity="" + quantity,
                type: ""GET"",
                dataType: ""json"",
                success: function(data) {
                    console.log(data);
                    if (data.status == ""error-login"") {
                        window.location.href = ""/admin/account/login"";
                    }
                    if (data.status == ""error-notcustomer"") {
                        window.location.href = ""/products/shopdetails?productId="" + ");
#nullable restore
#line 203 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Views\Products\ShopDetails.cshtml"
                                                                               Write(Model.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
                    }
                    if (data.status == ""not-enough-products"") {
                        alert(""The number of products in stock is not enough!"");
                    }
                    if (data.status == ""success"") {
                        alert(""Add to cart successfully"");
                    }
                },
                error: error => {
                    console.log(error);
                }
            })
        }

        var proQty = $('.pro-qty');
        proQty.prepend('<span class=""dec qtybtn"">-</span>');
        proQty.append('<span class=""inc qtybtn"">+</span>');
        proQty.on('click', '.qtybtn', function () {
            var $button = $(this);
            var oldValue = $button.parent().find('input').val();
            if ($button.hasClass('inc')) {
                var newVal = parseFloat(oldValue) + 1;
            } else {
                // Don't allow decrementing below one
                if (oldValue > 1) {
                   ");
                WriteLiteral(" var newVal = parseFloat(oldValue) - 1;\r\n                } else {\r\n                    newVal = 1;\r\n                }\r\n            }\r\n            $button.parent().find(\'input\').val(newVal);\r\n        });\r\n    </script>\r\n");
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
