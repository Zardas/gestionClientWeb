#pragma checksum "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\AjoutClient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c900c9cfb1f68c22aa9e975b387b8ee5accc6b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrateur_AjoutClient), @"mvc.1.0.view", @"/Views/Administrateur/AjoutClient.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c900c9cfb1f68c22aa9e975b387b8ee5accc6b5", @"/Views/Administrateur/AjoutClient.cshtml")]
    public class Views_Administrateur_AjoutClient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionRelationClient.Models.Administrateur>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\AjoutClient.cshtml"
  
    Layout = "_LayoutAdministrateur";
    ViewBag.Title = "Ajout client";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"interfaceGestionnaire\">\r\n    <h2>Ajout d\'un client</h2>\r\n\r\n    <div class=\"ajoutArticle\">\r\n");
#nullable restore
#line 15 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\AjoutClient.cshtml"
         using (Html.BeginForm("AjoutClient", "Administrateur", FormMethod.Post))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\AjoutClient.cshtml"
       Write(Html.Hidden("AdministrateurId", Model.UtilisateurId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""form-group"">
                <div>
                    <label for=""Login"">Login</label>
                    <input type=""text"" name=""Login"" class=""form-control"" required />
                </div>
                <div>
                    <label for=""Mail"">Mail</label>
                    <input type=""text"" name=""Mail"" class=""form-control"" required />
                </div>
            </div>
");
            WriteLiteral(@"            <div class=""form-group"">
                <div>
                    <label for=""Nom"">Nom</label>
                    <input type=""text"" name=""Nom"" class=""form-control"" required />
                </div>
                <div>
                    <label for=""Prenom"">Prenom</label>
                    <input type=""text"" name=""Prenom"" class=""form-control"" required />
                </div>
            </div>
");
            WriteLiteral(@"            <div class=""form-group"">
                <div>
                    <label for=""MotDePasse"">Mot de passe</label>
                    <input type=""text"" name=""MotDePasse"" class=""form-control"" required />
                </div>
            </div>
");
            WriteLiteral(@"            <div class=""form-group"">
                <div>
                    <label for=""Telephone"">Téléphone</label>
                    <input type=""text"" name=""Telephone"" class=""form-control"" required />
                </div>
                <div>
                    <label for=""Age"">Age</label>
                    <input type=""number"" name=""Age"" class=""form-control"" required />
                </div>
            </div>
");
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary\">Ajouter ce client</button>\r\n");
#nullable restore
#line 60 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Administrateur\AjoutClient.cshtml"
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
