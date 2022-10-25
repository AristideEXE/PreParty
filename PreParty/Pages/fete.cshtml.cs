using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using System.Runtime.Intrinsics.Arm;

namespace PreParty.Pages
{
    public class feteModel : PageModel
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
                string idFete = HttpContext.Request.Query["fete"];
                MySqlDataReader rdr = BDD.Select("SELECT * FROM fete WHERE idFete=" + idFete);
                this.fete = new Fete(rdr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
