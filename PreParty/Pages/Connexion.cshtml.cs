using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Tls;
using System.Data;

namespace PreParty.Pages
{
    public class ConnexionModel : PageModel
    {
        public void OnGet()
        {
            if (UtilisateurLogin.Instance.IsConnected)
            {
                UtilisateurLogin.Instance.Disconnect();
            }
            else
            {
                //UtilisateurLogin.Instance.Connect(UtilisateurCRUD.GetById(1));
            }
        }

        public void OnPost()
        {
            string adresse = Request.Form["email"];
            string mdp = Request.Form["mdp"];
            Utilisateur user = UtilisateurManager.GetByMail(adresse);
            if(user != null)
            {
                if (user.PasswordVerify(mdp)) {
                    UtilisateurLogin.Instance.Connect(user);
                    Response.Redirect("Index");
                }
                else
                {
                    Console.WriteLine("mauvais mdp");
                }
                
            }
            else
            {
                Console.WriteLine("oups trompé de personne");
            }

        }
    }
}
