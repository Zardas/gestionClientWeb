#pragma checksum "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\AjouterAbonnement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3273946db7eb5b3f004237bdc6b4829955a8284b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gestionnaire_AjouterAbonnement), @"mvc.1.0.view", @"/Views/Gestionnaire/AjouterAbonnement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3273946db7eb5b3f004237bdc6b4829955a8284b", @"/Views/Gestionnaire/AjouterAbonnement.cshtml")]
    public class Views_Gestionnaire_AjouterAbonnement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionRelationClient.Models.Gestionnaire>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\AjouterAbonnement.cshtml"
  
    Layout = "_LayoutGestionnaire";
    ViewBag.Title = "Ajout d'un abonnement";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"interfaceGestionnaire\">\r\n    <h2>Ajout d\'un abonnement</h2>\r\n\r\n    <div class=\"ajoutArticle\">\r\n");
#nullable restore
#line 15 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\AjouterAbonnement.cshtml"
         using (Html.BeginForm("AjouterAbonnement", "Gestionnaire", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Duree\">Duree en mois</label>\r\n                    <input type=\"number\" name=\"Duree\" class=\"form-control\" required />\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary\">Ajouter cet abonnement</button>\r\n");
#nullable restore
#line 25 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\AjouterAbonnement.cshtml"
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
