#pragma checksum "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f755688fed5721c54b618bc78b7f2f4db888affa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__EditLayout), @"mvc.1.0.view", @"/Views/Shared/_EditLayout.cshtml")]
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
#line 1 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\_ViewImports.cshtml"
using Ucebnice.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\_ViewImports.cshtml"
using Ucebnice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\_ViewImports.cshtml"
using Ucebnice.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
using System.Collections;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f755688fed5721c54b618bc78b7f2f4db888affa", @"/Views/Shared/_EditLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"758607f68e04b2b44a8fad5b4bf0ad5bfece4d1d", @"/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80ec0f612acbb947172444e03e4e2ceab8229abc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__EditLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style_navbar.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link navbar-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpravaMetadat", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpravaUcebnice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f755688fed5721c54b618bc78b7f2f4db888affa7907", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n\r\n    <title>");
#nullable restore
#line 10 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
      Write(ViewBag.Ucebnice);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>

    <!-- Bootstrap CSS CDN -->
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css"" integrity=""sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4"" crossorigin=""anonymous"">
    <!-- Our Custom CSS -->
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f755688fed5721c54b618bc78b7f2f4db888affa8886", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <!-- Font Awesome JS -->
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/simplemde/latest/simplemde.min.css"">
    <script src=""https://cdn.jsdelivr.net/simplemde/latest/simplemde.min.js""></script>
    <link rel=""stylesheet"" href=""https://pro.fontawesome.com/releases/v5.10.0/css/all.css"" integrity=""sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p"" crossorigin=""anonymous"" />

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f755688fed5721c54b618bc78b7f2f4db888affa11205", async() => {
                WriteLiteral("\r\n    <div class=\"wrapper\">\r\n        <!-- Sidebar  -->\r\n        <nav id=\"sidebar\">\r\n            <div class=\"sidebar-header\">\r\n                <h3>");
#nullable restore
#line 28 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
               Write(ViewBag.Ucebnice);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n            </div>\r\n\r\n            <ul class=\"list-unstyled components\">\r\n                <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f755688fed5721c54b618bc78b7f2f4db888affa11965", async() => {
                    WriteLiteral(" Základní informace ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Ucebnice", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                                                                                                                         WriteLiteral(ViewBag.Ucebnice);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Ucebnice"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Ucebnice", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Ucebnice"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n\r\n");
#nullable restore
#line 34 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                  int pokus = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                 foreach (KeyValuePair
               <string, ArrayList>
                   entry in @ViewBag.Kapitoly_podkapitoly)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <li>\r\n                        <a");
                BeginWriteAttribute("href", " href=\"", 1711, "\"", 1725, 2);
                WriteAttributeValue("", 1718, "#", 1718, 1, true);
#nullable restore
#line 40 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
WriteAttributeValue("", 1719, pokus, 1719, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" data-toggle=\"collapse\" aria-expanded=\"false\" class=\"dropdown-toggle\">");
#nullable restore
#line 40 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                                                                                                          Write(entry.Key);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                        <ul class=\"collapse list-unstyled\"");
                BeginWriteAttribute("id", " id=\"", 1870, "\"", 1881, 1);
#nullable restore
#line 41 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
WriteAttributeValue("", 1875, pokus, 1875, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 42 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                              pokus = pokus + 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                             foreach (string podKapitola in @ViewBag.Kapitoly_podkapitoly[entry.Key])
                            {
                                string uprava = podKapitola.Remove(podKapitola.Length - 3);


#line default
#line hidden
#nullable disable
                WriteLiteral("                                <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f755688fed5721c54b618bc78b7f2f4db888affa17368", async() => {
                    WriteLiteral(" ");
#nullable restore
#line 47 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                                                                                                                                                                                                                                          Write(uprava);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Ucebnice", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                                                                                                                                          WriteLiteral(ViewBag.Ucebnice);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Ucebnice"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Ucebnice", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Ucebnice"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                                                                                                                                                                                 WriteLiteral(entry.Key);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["kapitola"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-kapitola", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["kapitola"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                                                                                                                                                                                                                    WriteLiteral(podKapitola);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["podkapitola"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-podkapitola", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["podkapitola"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n");
#nullable restore
#line 48 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            \r\n                            <li><a class=\"nav-link navbar-dark\" style=\"background-color:darkgrey\" href=#");
                BeginWriteAttribute("onClick", " onClick=\'", 2587, "\'", 2647, 6);
                WriteAttributeValue("", 2597, "novaPodKapitola(\"", 2597, 17, true);
#nullable restore
#line 50 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
WriteAttributeValue("", 2614, ViewBag.Ucebnice, 2614, 17, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2631, "\",", 2631, 2, true);
                WriteAttributeValue(" ", 2633, "\"", 2634, 2, true);
#nullable restore
#line 50 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
WriteAttributeValue("", 2635, entry.Key, 2635, 10, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2645, "\")", 2645, 2, true);
                EndWriteAttribute();
                WriteLiteral("> Přidat podkapitolu</a></li>\r\n\r\n                        </ul>\r\n                    </li>\r\n");
#nullable restore
#line 54 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </ul>\r\n\r\n            <ul class=\"list-unstyled CTAs\">\r\n\r\n                <li>\r\n                    <a href=# onClick=novaKapitola(\"");
#nullable restore
#line 61 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                                               Write(ViewBag.Ucebnice);

#line default
#line hidden
#nullable disable
                WriteLiteral("\") class=\"article\">Přidat kapitolu</a>\r\n                    <a href=# onClick=smazatKapitolu(\"");
#nullable restore
#line 62 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
                                                 Write(ViewBag.Ucebnice);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""") class=""article"">Smazat kapitolu</a>

                </li>

            </ul>
        </nav>

        <!-- Page Content  -->
        <div id=""content"">
            <nav class=""navbar navbar-expand-lg navbar-light bg-light"">
                <div class=""container-fluid"">
                    <div style=""display: inline"">
                        <button style=""display: inline"" type=""button"" id=""sidebarCollapse"" class=""btn btn-dark"">
                            <i class=""fas fa-align-left""></i>
                            <span>Přepnout sidebar</span>
                        </button>
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f755688fed5721c54b618bc78b7f2f4db888affa25449", async() => {
                    WriteLiteral(@"
                            <button style=""display: inline"" type=""button"" id=""sidebarCollapse"" class=""btn btn-dark"">
                                <i class='fas fa-arrow-left btn-dark'></i>
                                <span>Ostatní učebnice</span>
                            </button>
                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </nav>\r\n            <div class=\"container\">\r\n                <main role=\"main\" class=\"pb-3\">\r\n                    ");
#nullable restore
#line 89 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
               Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </main>
            </div>

        </div>
    </div>

    <!-- jQuery CDN - Slim version (=without AJAX) -->
    <script src=""https://code.jquery.com/jquery-3.3.1.slim.min.js"" integrity=""sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"" crossorigin=""anonymous""></script>
    <!-- Popper.JS -->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"" integrity=""sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ"" crossorigin=""anonymous""></script>
    <!-- Bootstrap JS -->
    <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"" integrity=""sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm"" crossorigin=""anonymous""></script>

    <script type=""text/javascript"">
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
        ");
                WriteLiteral(@"function novaKapitola(ucebnice) {
            let kapitola = prompt(""Napište název kapitoly"", """");
            if (kapitola == null || kapitola == """") {
                alert(""Nebyl vybrán žádný název pro kapitolu"")
            } else {
                window.location.reload(true);
                window.location.href = ""/home/NovaKapitola?ucebnice="" + ucebnice + ""&kapitola="" + kapitola;
            }
        }
        function novaPodKapitola(ucebnice, kapitola) {
            console.log(ucebnice, kapitola);
            let podkapitola = prompt(""Napište název podkapitoly"", """");
            if (podkapitola == null || podkapitola == """") {
                alert(""Nebyl vybrán žádný název pro podkapitolu"")
            } else {
                console.log(podkapitola);
                window.location.reload(true);
                window.location.href = ""/home/NovaPodKapitola?ucebnice="" + ucebnice + ""&kapitola="" + kapitola + ""&podkapitola="" + podkapitola;
            }
        }
        function");
                WriteLiteral(@" smazatKapitolu(ucebnice) {
            let kapitola = prompt(""Napište název kapitoly ke smazání (NEVRATNÉ!)"", """");
            if (kapitola == null || kapitola == """") {
                alert(""Nebyla vybrána žádná kapitola ke smazání"")
            } else {
                window.location.reload(true);
                window.location.href = ""/home/SmazatKapitolu?ucebnice="" + ucebnice + ""&kapitola="" + kapitola;
            }
        }
    </script>
    ");
#nullable restore
#line 139 "C:\Users\Nel\source\repos\Ucebnice\Ucebnice\Views\Shared\_EditLayout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
