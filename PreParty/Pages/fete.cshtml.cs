using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.Intrinsics.Arm;

namespace PreParty.Pages
{
    public class FeteModel : PageModel
    {
        private Fete fete;
        public Fete Fete
        {
            get { return fete; }
        }

        public void OnGet()
        {
            //try
            //{
            //    string idFete;
            //    if (HttpContext.Request.Query["fete"] == "")
            //    {
            //        idFete = "1";
            //    }
            //    else
            //    {
            //        idFete = HttpContext.Request.Query["fete"];
            //    }
            //    this.fete = new Fete(BDD.SelectSingleLine("SELECT * FROM fete WHERE idFete=1"));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }
    }
}
