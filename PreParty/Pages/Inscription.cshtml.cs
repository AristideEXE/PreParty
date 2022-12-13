using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PreParty.Pages
{
    public class InscriptionModel : PageModel
    {
        private string dateAjd;
        public string DateAjd
        {
            get { return dateAjd; }
            set
            {
                this.dateAjd = value;
            }
        }
        public void OnGet()
        {
            this.dateAjd = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public void OnPost()
        {
            string nom = Request.Form["_nom"];
            string prenom = Request.Form["_prenom"];
            string dateNaissance = Request.Form["_date_naissance"];
            string email = Request.Form["_email"];
            string password = Request.Form["_password"];
            string passwordConfirm = Request.Form["_passwordConfirm"];


            //Insertion de la base de donn�e � faire
            if((password == passwordConfirm) && (password.Length >= 8)) {
                Utilisateur user = new Utilisateur(nom, prenom, Convert.ToDateTime(dateNaissance), email, Utilisateur.GetHashString(password));
                UtilisateurCRUD.CreateWithoutId(user); 
            }
            else
            {
                // to do
            }
        }
    }
}
