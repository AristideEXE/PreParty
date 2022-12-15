using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PreParty.Pages
{
    public class GestionCompteModel : PageModel
    {
        private Utilisateur user = UtilisateurLogin.Instance.GetUtilisateur();
        public Utilisateur User
        {
            get { return user; }
        }
        private string dateAjd;
        public string DateAjd
        {
            get { return dateAjd; }
            set
            {
                this.dateAjd = value;
            }
        }

        private string dateNaissance;
        public string DateNiassance
        {
            get { return dateNaissance; }
        }
        public void OnGet()
        {
            this.dateAjd = DateTime.Now.ToString("yyyy-MM-dd");
            this.dateNaissance = User.DateNaissance.ToString("yyyy-MM-dd");
        }

        public void OnPost()
        {
            string nom = Request.Form["_nom"];
            string prenom = Request.Form["_prenom"];
            string dateNaissance = Request.Form["_date_naissance"];
            string email = Request.Form["_email"];
            //Modification de l'utilisateur
            User.Nom = nom;
            User.Prenom = prenom;
            User.Mail = email;
            User.DateNaissance = Convert.ToDateTime(dateNaissance);

            UtilisateurManager.UpdateInfo(User);
            Response.Redirect("Index");

        }
    }
}
