#pragma checksum "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42408ca542ed1e15c4b9f457206c2591603262de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42408ca542ed1e15c4b9f457206c2591603262de", @"/Areas/Admin/Views/Home/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Home\Index.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Trang quản trị</h2>
<section class=""content"">
    <!-- Small boxes (Stat box) -->
    <div class=""row"">
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-aqua"">
                <div class=""inner"">
                    <h3>");
#nullable restore
#line 14 "D:\code_devmaster\.NET Core\AppManagerNew\AppManager\AppManager\Areas\Admin\Views\Home\Index.cshtml"
                   Write(ViewBag.NewOrders);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                    <p>Đơn hàng mới</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-bag""></i>
                </div>
                <a href=""/admin/salesreceipt/index"" class=""small-box-footer"">Thông tin <i class=""fa fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-green"" id=""revenue-in-month"">
                
            </div>
        </div>
    </div>
    <!-- /.row -->
    <!-- Main row -->
    <div class=""row"">
        <!-- Left col -->
        <section class=""col-lg-7 connectedSortable"">
            <!-- Custom tabs (Charts with tabs)-->
            <div class=""nav-tabs-custom box box-success"">
                <!-- Tabs within a box -->
                <ul class=""nav nav-tabs pull-right"">
                    <li class=""active""><a href=""#sales-chart"" data-toggle=""tab"">Donut</a></li>
             ");
            WriteLiteral(@"       <li class=""pull-left header""><i class=""fa fa-inbox""></i> Sales</li>
                </ul>
                <div class=""tab-content no-padding"">
                    <!-- Morris chart - Sales -->
                    <div class=""chart tab-pane active"" id=""sales-chart"" style=""position: relative; height: 300px;""></div>
                </div>
            </div>
            
        </section>
        <!-- /.Left col -->
        <!-- right col (We are only adding the ID to make the widgets sortable)-->
        <section class=""col-lg-5 connectedSortable"">
            <!-- Calendar -->
            <div class=""box box-solid bg-green-gradient"">
                <div class=""box-header"">
                    <i class=""fa fa-calendar""></i>

                    <h3 class=""box-title"">Calendar</h3>
                    <!-- tools box -->
                    <div class=""pull-right box-tools"">
                        <!-- button with a dropdown -->
                        <button type=""button"" class=""btn");
            WriteLiteral(@" btn-success btn-sm"" data-widget=""collapse"">
                            <i class=""fa fa-minus""></i>
                        </button>
                    </div>
                    <!-- /. tools -->
                </div>
                <!-- /.box-header -->
                <div class=""box-body no-padding"">
                    <!--The calendar -->
                    <div id=""calendar"" style=""width: 100%""></div>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->

        </section>
        <!-- right col -->
    </div>
    <!-- /.row (main row) -->

</section>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $.ajax({
            url: ""/admin/Home/GetSaleNumber"",
            type: ""GET"",
            dataType: ""json"",
            beforeSend: function () {

            },
            success: function (obj) {
                //Donut Chart
                var sellQuantity = obj.sellQuantity;
                var productInStock = obj.productInStock;
                var donut = new Morris.Donut({
                    element: 'sales-chart',
                    resize: true,
                    colors: [""#3c8dbc"", ""#f56954""],
                    data: [
                        { label: ""Đã bán"", value: sellQuantity },
                        { label: ""Còn trong kho"", value: productInStock }
                    ],
                    hideHover: 'auto'
                });
            },
            error: function (error) {

            },
            complete: function () {

            }
        });

        $.ajax({
            url: ""/admin/Home/GetRevenueOfMonth"",
");
                WriteLiteral(@"            type: ""GET"",
            dataType: ""json"",
            beforeSend: function () {

            },
            success: function (data) {
                $('#revenue-in-month').html('');
                let row = `<div class=""inner"">
                            <h3>${data}<sup style=""font-size: 20px"">$</sup></h3>
                            <p>Doanh thu trong tháng</p>
                        </div>
                        <div class=""icon"">
                            <i class=""ion ion-stats-bars""></i>
                        </div>`;
                $('#revenue-in-month').append(row);
            },
            error: function (error) {

            },
            complete: function () {

            }
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