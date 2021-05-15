#pragma checksum "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a862de610da21316d890107b375c379e90c11e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gestionnaire_ModificationProduit), @"mvc.1.0.view", @"/Views/Gestionnaire/ModificationProduit.cshtml")]
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
#line 9 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
using GestionRelationClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a862de610da21316d890107b375c379e90c11e9", @"/Views/Gestionnaire/ModificationProduit.cshtml")]
    public class Views_Gestionnaire_ModificationProduit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionRelationClient.Models.Gestionnaire>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
  
    Layout = "_LayoutGestionnaire";
    ViewBag.Title = "Modification du produit";

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
  
    Produit produit = ViewData["Produit"] as Produit;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n<div class=\"interfaceGestionnaire\">\r\n    <h2>Modification de ");
#nullable restore
#line 18 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
                   Write(produit.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n    <div class=\"ajoutArticle\">\r\n");
#nullable restore
#line 21 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
         using (Html.BeginForm("ModifierProduit", "Gestionnaire", FormMethod.Post))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
       Write(Html.Hidden("ProduitId", produit.ArticleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Nom\">Nom</label>\r\n                    <input type=\"text\" name=\"Nom\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 873, "\"", 893, 1);
#nullable restore
#line 27 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 881, produit.Nom, 881, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Image\">Image</label>\r\n                    <input type=\"text\" name=\"Image\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1081, "\"", 1103, 1);
#nullable restore
#line 31 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 1089, produit.Image, 1089, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Fabricant\">Fabricant</label>\r\n                    <input type=\"text\" name=\"Fabricant\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1294, "\"", 1320, 1);
#nullable restore
#line 35 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 1302, produit.Fabricant, 1302, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Type\">Type</label>\r\n                    <input type=\"text\" name=\"Type\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1567, "\"", 1588, 1);
#nullable restore
#line 43 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 1575, produit.Type, 1575, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Prix\">Prix</label>\r\n                    <input type=\"number\" name=\"Prix\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1775, "\"", 1796, 1);
#nullable restore
#line 47 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 1783, produit.Prix, 1783, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Quantite\">Quantité</label>\r\n                    <input type=\"number\" name=\"Quantite\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1995, "\"", 2020, 1);
#nullable restore
#line 51 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 2003, produit.Quantite, 2003, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Capacite\">Capacité</label>\r\n                    <input type=\"number\" name=\"Capacite\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 2219, "\"", 2244, 1);
#nullable restore
#line 55 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 2227, produit.Capacite, 2227, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Description\">Description</label>\r\n                    <textarea name=\"Description\" class=\"form-control\" required>");
#nullable restore
#line 62 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
                                                                          Write(produit.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n                </div>\r\n                <div>\r\n                    <label for=\"Manuel\">Manuel</label>\r\n                    <textarea name=\"Manuel\" class=\"form-control\" required>");
#nullable restore
#line 66 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
                                                                     Write(produit.Manuel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary\">Modifier ce produit</button>\r\n");
#nullable restore
#line 71 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionRelationClient.Models.Gestionnaire> Html { get; private set; }
    }
}
#pragma warning restore 1591
