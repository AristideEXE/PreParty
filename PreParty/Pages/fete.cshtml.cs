using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using System.Runtime.Intrinsics.Arm;

namespace PreParty.Pages
{
    public class feteModel : PageModel
    {
        private Utilisateur aristide;
        public Utilisateur Aristide { 
            get { return aristide; } 
        }

        public void OnGet()
        {
            BDD.Open();
            MySqlDataReader rdr = BDD.Select("SELECT * FROM utilisateur WHERE idUtilisateur=1");
            this.aristide = new Utilisateur(rdr);
            BDD.Close();
        }
    }
}
