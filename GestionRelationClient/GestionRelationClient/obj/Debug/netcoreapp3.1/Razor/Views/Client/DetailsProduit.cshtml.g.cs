#pragma checksum "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3755da63593b4fa19c8a4b12ef473b18c639ce4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_DetailsProduit), @"mvc.1.0.view", @"/Views/Client/DetailsProduit.cshtml")]
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
#line 9 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
using GestionRelationClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3755da63593b4fa19c8a4b12ef473b18c639ce4", @"/Views/Client/DetailsProduit.cshtml")]
    public class Views_Client_DetailsProduit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionRelationClient.Models.Compte>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
  
    Layout = "_LayoutClient";
    ViewBag.Title = "";

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
  
    Produit article = ViewData["Produit"] as Produit;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"detailsArticle\">\r\n\r\n    <div class=\"row\">\r\n        <div class=\"row\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 485, "\"", 505, 1);
#nullable restore
#line 20 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
WriteAttributeValue("", 491, article.Image, 491, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 506, "\"", 524, 1);
#nullable restore
#line 20 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
WriteAttributeValue("", 512, article.Nom, 512, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n            <div class=\"column\">\r\n                <h3>");
#nullable restore
#line 23 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
               Write(article.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <p>Type : ");
#nullable restore
#line 24 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
                     Write(article.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Fabricant : ");
#nullable restore
#line 25 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
                          Write(article.Fabricant);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Capacité : ");
#nullable restore
#line 26 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
                         Write(article.Capacite);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n        \r\n        \r\n        <div class=\"column\">\r\n            <h5 class=\"prix\">");
#nullable restore
#line 32 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
                        Write(article.Prix);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</h5>\r\n");
#nullable restore
#line 33 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
             if (ViewData["PeutEtreAchete"].ToString() == "True")
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
                 using (Html.BeginForm("AjoutPanierArticle", "Client", FormMethod.Post))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
               Write(Html.Hidden("CompteId", Model.CompteId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
               Write(Html.Hidden("ArticleId", article.ArticleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <button type=\"submit\" class=\"btn btn-primary\">Ajouter ce produit au panier</button>\r\n");
#nullable restore
#line 40 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n\r\n    <div class=\"row row-longTexts\">\r\n        <div class=\"column\">\r\n            <h5>Description</h5>\r\n            <p class=\"longText\">");
#nullable restore
#line 49 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
                           Write(article.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"column\">\r\n            <h5>Manuel</h5>\r\n            <p class=\"longText\">");
#nullable restore
#line 53 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\DetailsProduit.cshtml"
                           Write(article.Manuel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionRelationClient.Models.Compte> Html { get; private set; }
    }
}
#pragma warning restore 1591
