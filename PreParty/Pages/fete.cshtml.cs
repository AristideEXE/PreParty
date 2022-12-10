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
            try
            {
                int idFete;
                //if (HttpContext.Request.Query["fete"] == "")
                //{
                    //Response.Redirect("Index");
                    idFete = 1;
                    this.fete = FeteCRUD.GetById(idFete);
                //}
                //else
                //{
                //    idFete = Int32.Parse(HttpContext.Request.Query["fete"]);
                //    this.fete = FeteCRUD.GetById(idFete);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
