#pragma checksum "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Shared\_Compte.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8d015240f1f6f54b1ae6db49b82b3b71dc40882"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Compte), @"mvc.1.0.view", @"/Views/Shared/_Compte.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8d015240f1f6f54b1ae6db49b82b3b71dc40882", @"/Views/Shared/_Compte.cshtml")]
    public class Views_Shared__Compte : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionRelationClient.Models.Compte>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 10 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Shared\_Compte.cshtml"
 using (Html.BeginForm("SelectionCompteClient", "Client", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"formSelectionCompte\">\r\n    <h4>");
#nullable restore
#line 13 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Shared\_Compte.cshtml"
   Write(Model.NomCompte);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    ");
#nullable restore
#line 14 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Shared\_Compte.cshtml"
Write(Html.Hidden("IdCompte", Model.CompteId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <button type=\"submit\" class=\"btn btn-primary\">Sélectionner ce compte</button>\r\n</div>\r\n");
#nullable restore
#line 17 "C:\Users\Antoine\Desktop\Scolaire\Master2Uqar\Programmation objet avancée\TP3\gestionClientWeb\GestionRelationClient\GestionRelationClient\Views\Shared\_Compte.cshtml"
}

#line default
#line hidden
#nullable disable
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
