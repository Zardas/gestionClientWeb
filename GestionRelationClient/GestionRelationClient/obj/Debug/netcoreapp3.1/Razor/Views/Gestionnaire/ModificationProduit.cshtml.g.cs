#pragma checksum "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53543cd1421226ba34267019c4e843054dab6d22"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53543cd1421226ba34267019c4e843054dab6d22", @"/Views/Gestionnaire/ModificationProduit.cshtml")]
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
       Write(Html.Hidden("GestionnaireId", Model.UtilisateurId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
       Write(Html.Hidden("ProduitId", produit.ArticleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Nom\">Nom</label>\r\n                    <input type=\"text\" name=\"Nom\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 938, "\"", 958, 1);
#nullable restore
#line 28 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 946, produit.Nom, 946, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Image\">Image (à placer dans \"wwwwroot/img/articles/\")</label>\r\n                    <input type=\"text\" name=\"Image\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1187, "\"", 1209, 1);
#nullable restore
#line 32 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 1195, produit.Image, 1195, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Fabricant\">Fabricant</label>\r\n                    <input type=\"text\" name=\"Fabricant\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1409, "\"", 1435, 1);
#nullable restore
#line 36 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 1417, produit.Fabricant, 1417, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Type\">Type</label>\r\n                    <input type=\"text\" name=\"Type\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1682, "\"", 1703, 1);
#nullable restore
#line 44 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 1690, produit.Type, 1690, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Prix\">Prix</label>\r\n                    <input type=\"number\" name=\"Prix\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1890, "\"", 1911, 1);
#nullable restore
#line 48 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 1898, produit.Prix, 1898, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Quantite\">Quantité</label>\r\n                    <input type=\"number\" name=\"Quantite\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 2110, "\"", 2135, 1);
#nullable restore
#line 52 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 2118, produit.Quantite, 2118, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Capacite\">Capacité</label>\r\n                    <input type=\"number\" name=\"Capacite\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 2334, "\"", 2359, 1);
#nullable restore
#line 56 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
WriteAttributeValue("", 2342, produit.Capacite, 2342, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Description\">Description</label>\r\n                    <textarea name=\"Description\" class=\"form-control\" required>");
#nullable restore
#line 63 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
                                                                          Write(produit.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n                </div>\r\n                <div>\r\n                    <label for=\"Manuel\">Manuel</label>\r\n                    <textarea name=\"Manuel\" class=\"form-control\" required>");
#nullable restore
#line 67 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
                                                                     Write(produit.Manuel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary\">Modifier ce produit</button>\r\n");
#nullable restore
#line 72 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\ModificationProduit.cshtml"
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
