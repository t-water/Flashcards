#pragma checksum "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d39dc9c2f89a614b381566c9a2d6773694948e80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Roles_ListUsers), @"mvc.1.0.view", @"/Views/Roles/ListUsers.cshtml")]
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
#line 1 "C:\Users\Tyler\source\repos\Flashcards\Views\_ViewImports.cshtml"
using Flashcards;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tyler\source\repos\Flashcards\Views\_ViewImports.cshtml"
using Flashcards.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tyler\source\repos\Flashcards\Views\_ViewImports.cshtml"
using Flashcards.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Tyler\source\repos\Flashcards\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d39dc9c2f89a614b381566c9a2d6773694948e80", @"/Views/Roles/ListUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b570223d8992e3f34531de3668e0920232df408", @"/Views/_ViewImports.cshtml")]
    public class Views_Roles_ListUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<string>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml"
  
    ViewData["Title"] = "ListUsers";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 6 "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml"
Write(ViewBag.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<p>Id: ");
#nullable restore
#line 7 "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml"
  Write(ViewBag.RoleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>Users:</h3>\r\n");
#nullable restore
#line 12 "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml"
     foreach(var m in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>- <strong>");
#nullable restore
#line 14 "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml"
                Write(m);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n");
#nullable restore
#line 15 "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No Users In This Role Yet</p>\r\n");
#nullable restore
#line 20 "C:\Users\Tyler\source\repos\Flashcards\Views\Roles\ListUsers.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<string>> Html { get; private set; }
    }
}
#pragma warning restore 1591
