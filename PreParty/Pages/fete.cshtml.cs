using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.Intrinsics.Arm;

namespace PreParty.Pages
{
    public class FeteModel : PageModel
    {
        private Fete fete = FeteCRUD.GetById(1);
        public Fete Fete
        {
            get { return fete; }
        }

        public void OnLoad()
        {
            Console.WriteLine("test");
        }

        public void OnGet()
        {
            try
            {
                // J'essaye de récupérer l'identifiant de la fête à laquelle on veut accéder
                if (HttpContext.Request.Query.ContainsKey("fete")){
                    int idFete = int.Parse(HttpContext.Request.Query["fete"]);
                    if (FeteCRUD.FeteExists(idFete))
                    {
                        this.fete = FeteCRUD.GetById(idFete);
                        // Je vérifie que la personne soit invitée à la fête ou qu'elle en soit l'organisateur
                        if (UtilisateurLogin.Instance.IsConnected)
                        {
                            if (Fete.Invites.Contains(UtilisateurLogin.Instance.GetUtilisateur()) || fete.Organisateur.Equals(UtilisateurLogin.Instance.GetUtilisateur()))
                            {
                                // Tout va bien
                            }
                            else
                            {
                                Response.Redirect("Index");
                            }
                        }
                        else
                        {
                            Response.Redirect("Index");
                        }
                    }
                    else
                    {
                        Response.Redirect("Index");
                    }
                }
                else
                {
                    Response.Redirect("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
