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

            //On v�rifie que l'utilisateur a bien saisi l'ancien mdp du compte
            if (User.PasswordVerify(oldMdp))
            {
                //On v�rifie que le nouveau mdp et la confirmation sont �gales et sup�rieur � 8 carcat�res
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
