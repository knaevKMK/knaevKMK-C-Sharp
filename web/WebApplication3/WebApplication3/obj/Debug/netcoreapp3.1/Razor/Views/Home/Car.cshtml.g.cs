#pragma checksum "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\Home\Car.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f7cdd5e52f5a70eb07fe99138ee989f75fe944f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Car), @"mvc.1.0.view", @"/Views/Home/Car.cshtml")]
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
#line 1 "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f7cdd5e52f5a70eb07fe99138ee989f75fe944f", @"/Views/Home/Car.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"463d1c12e8fc14b2589daa67feec3183fea97611", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Car : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication3.Views.ExportDto.CarExportDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\Home\Car.cshtml"
  
    ViewData["Title"] = "Car";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <p>Car Details</p><br />\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 141, "\"", 162, 1);
#nullable restore
#line 9 "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\Home\Car.cshtml"
WriteAttributeValue("", 147, Model.ImageUrl, 147, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 163, "\"", 201, 2);
#nullable restore
#line 9 "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\Home\Car.cshtml"
WriteAttributeValue("", 169, Model.Manufacturer, 169, 19, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\Home\Car.cshtml"
WriteAttributeValue(" ", 188, Model.Model, 189, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <p>");
#nullable restore
#line 10 "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\Home\Car.cshtml"
  Write(Model.type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 11 "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\Home\Car.cshtml"
  Write(Model.Engine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 12 "C:\Users\master\source\repos\WebApplication3\WebApplication3\Views\Home\Car.cshtml"
  Write(Model.Transmision);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication3.Views.ExportDto.CarExportDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
