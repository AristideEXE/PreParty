using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace PreParty.Pages
{
    public class ConnexionModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string adresse = Request.Form["email"];
            string mdp = Request.Form["mdp"];
            if (adresse != null && mdp != null)
            {
                //String sql = "SELECT motDePasse FROM utilisateur WHERE adresse = " + adresse;
                //MySqlDataReader r = BDD.Select(sql);
                //string s = r.GetValue(r.GetOrdinal("motdepasse")).ToString();
                //if (s.Equals(mdp))
                //{
                //    //C'est bon
                //}


            }
            else
            {
                
            }

        }
    }
}
