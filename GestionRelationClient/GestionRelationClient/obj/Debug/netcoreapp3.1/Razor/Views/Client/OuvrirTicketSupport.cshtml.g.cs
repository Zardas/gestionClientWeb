#pragma checksum "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24e88a8ae9c4d97ad8143fd67e366177e5ca7f52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_OuvrirTicketSupport), @"mvc.1.0.view", @"/Views/Client/OuvrirTicketSupport.cshtml")]
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
#line 9 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml"
using GestionRelationClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24e88a8ae9c4d97ad8143fd67e366177e5ca7f52", @"/Views/Client/OuvrirTicketSupport.cshtml")]
    public class Views_Client_OuvrirTicketSupport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionRelationClient.Models.Compte>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml"
  
    Layout = "_LayoutClient";
    ViewBag.Title = "";

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml"
  
    Article article = ViewData["Article"] as Article;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"ouvertureTicketSupport\">\r\n\r\n    <h3>Ouverture d\'un ticket par ");
#nullable restore
#line 19 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml"
                             Write(Model.NomCompte);

#line default
#line hidden
#nullable disable
            WriteLiteral(" pour l\'article ");
#nullable restore
#line 19 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml"
                                                             Write(article.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 20 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml"
     using (Html.BeginForm("AjouterTicketSupport", "Client", FormMethod.Post))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml"
   Write(Html.Hidden("CompteId", Model.CompteId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml"
   Write(Html.Hidden("ArticleId", article.ArticleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <label for=\"Objet\">Objet</label>\r\n            <input type=\"text\" name=\"Objet\" class=\"form-control\" required />\r\n        </div>\r\n");
            WriteLiteral("        <div>\r\n            <label for=\"Description\">Description</label>\r\n            <textarea type=\"text\" name=\"Description\" class=\"form-control\" placeholder=\"Decrivez votre problème\" required></textarea>\r\n        </div>\r\n");
            WriteLiteral("        <button type=\"submit\" class=\"btn btn-primary\">Créer le ticket</button>\r\n");
#nullable restore
#line 36 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Client\OuvrirTicketSupport.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
