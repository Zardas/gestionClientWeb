#pragma checksum "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98feeb03f7a5b0e308eed43440b26529f1d43770"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrateur_ModificationClient), @"mvc.1.0.view", @"/Views/Administrateur/ModificationClient.cshtml")]
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
#line 9 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
using GestionRelationClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98feeb03f7a5b0e308eed43440b26529f1d43770", @"/Views/Administrateur/ModificationClient.cshtml")]
    public class Views_Administrateur_ModificationClient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionRelationClient.Models.Administrateur>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
  
    Layout = "_LayoutAdministrateur";
    ViewBag.Title = "Ajout client";

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
  
    Client client = ViewData["Client"] as Client;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n<div class=\"interfaceGestionnaire\">\r\n    <h2>Modification du client ");
#nullable restore
#line 18 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
                          Write(client.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n    <div class=\"ajoutArticle\">\r\n");
#nullable restore
#line 21 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
         using (Html.BeginForm("ModificationClient", "Administrateur", FormMethod.Post))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
       Write(Html.Hidden("AdministrateurId", Model.UtilisateurId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
       Write(Html.Hidden("ClientId", client.UtilisateurId));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Login\">Login</label>\r\n                    <input type=\"text\" name=\"Login\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 950, "\"", 971, 1);
#nullable restore
#line 28 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
WriteAttributeValue("", 958, client.Login, 958, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Mail\">Mail</label>\r\n                    <input type=\"text\" name=\"Mail\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1156, "\"", 1176, 1);
#nullable restore
#line 32 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
WriteAttributeValue("", 1164, client.Mail, 1164, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Nom\">Nom</label>\r\n                    <input type=\"text\" name=\"Nom\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1420, "\"", 1439, 1);
#nullable restore
#line 40 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
WriteAttributeValue("", 1428, client.Nom, 1428, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Prenom\">Prenom</label>\r\n                    <input type=\"text\" name=\"Prenom\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1630, "\"", 1652, 1);
#nullable restore
#line 44 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
WriteAttributeValue("", 1638, client.Prenom, 1638, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    <label for=\"Telephone\">Téléphone</label>\r\n                    <input type=\"text\" name=\"Telephone\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1912, "\"", 1937, 1);
#nullable restore
#line 51 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
WriteAttributeValue("", 1920, client.Telephone, 1920, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n                <div>\r\n                    <label for=\"Age\">Age</label>\r\n                    <input type=\"number\" name=\"Age\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 2121, "\"", 2140, 1);
#nullable restore
#line 55 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
WriteAttributeValue("", 2129, client.Age, 2129, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary\">Modifier ce client</button>\r\n");
#nullable restore
#line 60 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\ModificationClient.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionRelationClient.Models.Administrateur> Html { get; private set; }
    }
}
#pragma warning restore 1591
