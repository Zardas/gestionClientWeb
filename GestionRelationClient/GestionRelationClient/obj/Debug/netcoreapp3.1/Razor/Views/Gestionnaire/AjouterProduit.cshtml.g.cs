#pragma checksum "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\AjouterProduit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf352a73723ecf3bd53037fa6296263fc41b1e77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gestionnaire_AjouterProduit), @"mvc.1.0.view", @"/Views/Gestionnaire/AjouterProduit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf352a73723ecf3bd53037fa6296263fc41b1e77", @"/Views/Gestionnaire/AjouterProduit.cshtml")]
    public class Views_Gestionnaire_AjouterProduit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionRelationClient.Models.Gestionnaire>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\AjouterProduit.cshtml"
  
    Layout = "_LayoutGestionnaire";
    ViewBag.Title = "Ajout produit";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"interfaceGestionnaire\">\r\n    <h2>Ajout d\'un produit</h2>\r\n\r\n    <div class=\"ajoutArticle\">\r\n");
#nullable restore
#line 15 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\AjouterProduit.cshtml"
         using (Html.BeginForm("AjoutProduit", "Gestionnaire", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""form-group"">
                <div>
                    <label for=""Nom"">Nom</label>
                    <input type=""text"" name=""Nom"" class=""form-control"" required/>
                </div>
                <div>
                    <label for=""Image"">Image</label>
                    <input type=""text"" name=""Image"" class=""form-control"" required/>
                </div>
                <div>
                    <label for=""Fabricant"">Fabricant</label>
                    <input type=""text"" name=""Fabricant"" class=""form-control"" required/>
                </div>
            </div>
");
            WriteLiteral(@"            <div class=""form-group"">
                <div>
                    <label for=""Type"">Type</label>
                    <input type=""text"" name=""Type"" class=""form-control"" required />
                </div>
                <div>
                    <label for=""Prix"">Prix</label>
                    <input type=""number"" name=""Prix"" class=""form-control"" required />
                </div>
                <div>
                    <label for=""Quantite"">Quantité</label>
                    <input type=""number"" name=""Quantite"" class=""form-control"" required />
                </div>
                <div>
                    <label for=""Capacite"">Capacité</label>
                    <input type=""number"" name=""Capacite"" class=""form-control"" required />
                </div>
            </div>
");
            WriteLiteral(@"            <div class=""form-group"">
                <div>
                    <label for=""Description"">Description</label>
                    <textarea name=""Description"" class=""form-control"" required>Description du produit</textarea>
                </div>
                <div>
                    <label for=""Manuel"">Manuel</label>
                    <textarea name=""Manuel"" class=""form-control"" required>Manuel du produit</textarea>
                </div>
            </div>
");
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary\">Ajouter ce produit</button>\r\n");
#nullable restore
#line 64 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Gestionnaire\AjouterProduit.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    \r\n</div>");
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
