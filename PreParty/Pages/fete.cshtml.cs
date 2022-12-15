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

        public bool EstOrganisateur
        {
            get
            {
                return fete.Organisateur.Equals(UtilisateurLogin.Instance.GetUtilisateur());
            }
        }

        public void OnLoad()
        {
            Console.WriteLine("test");
        }

        public void OnGet()
        {
            try
            {
                // J'essaye de r�cup�rer l'identifiant de la f�te � laquelle on veut acc�der
                if (HttpContext.Request.Query.ContainsKey("fete")){
                    int idFete = int.Parse(HttpContext.Request.Query["fete"]);
                    if (FeteCRUD.FeteExists(idFete))
                    {
                        this.fete = FeteCRUD.GetById(idFete);
                        // Je v�rifie que la personne soit invit�e � la f�te ou qu'elle en soit l'organisateur
                        if (UtilisateurLogin.Instance.IsConnected)
                        {
                            if (Fete.Invites.Contains(UtilisateurLogin.Instance.GetUtilisateur()) || fete.Organisateur.Equals(UtilisateurLogin.Instance.GetUtilisateur()))
                            {
                                // Si on essaye de supprimer un invit� de la f�te
                                if (HttpContext.Request.Query.ContainsKey("removeInvite"))
                                {
                                    int idInvite = int.Parse(HttpContext.Request.Query["removeInvite"]);
                                    if (EstOrganisateur)
                                    {
                                        fete.RemoveInvite(idInvite);
                                    }
                                }
                                // Si on essaye de quitter la f�te (sans �tre organisateur)
                                if (HttpContext.Request.Query.ContainsKey("quitterFete"))
                                {
                                    if (!EstOrganisateur)
                                    {
                                        fete.QuitterFete(UtilisateurLogin.Instance.GetUtilisateur().IdUtilisateur);
                                        Response.Redirect("Index");
                                    }
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
