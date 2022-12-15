using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace PreParty.Pages
{
    public class ModificationMdpModel : PageModel
    {
        private Utilisateur user = UtilisateurLogin.Instance.GetUtilisateur();
        public Utilisateur User
        {
            get { return user; }
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string oldMdp = Request.Form["_oldMdp"];
            string password = Request.Form["_password"];
            string passwordConfirm = Request.Form["_passwordConfirm"];
            string hash = "";

            if (User.PasswordVerify(oldMdp))
            {
                Console.WriteLine("Bon mdp");
                if ((password == passwordConfirm) && (password.Length >= 8))
                {
                    hash = Utilisateur.GetHashString(password);
                    User.Hash = hash;
                    UtilisateurManager.UpdateMdp(User, hash);
                    Response.Redirect("Index");
                }
                else
                {
                    //To do
                }
            }
            else
            {
                // to do
            }
            
            
        }
    }
}
