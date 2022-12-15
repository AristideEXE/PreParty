using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.Intrinsics.Arm;

namespace PreParty.Pages
{
    public class FeteModel : PageModel
    {
        private Fete fete = FeteManager.GetById(1);
        public Fete Fete
        {
            get { return fete; }
        }

        private List<Utilisateur> searchInvites = new List<Utilisateur>();
        public List<Utilisateur> SearchInvites
        {
            get { return searchInvites; }
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
                    if (FeteManager.FeteExists(idFete))
                    {
                        this.fete = FeteManager.GetById(idFete);
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
                                    Response.Redirect("Fete?fete=" + idFete);
                                }
                                // Si on essaye d'ajouter un invit� � la f�te
                                else if (HttpContext.Request.Query.ContainsKey("addInvite"))
                                {
                                    int idInvite = int.Parse(HttpContext.Request.Query["addInvite"]);
                                    if (EstOrganisateur)
                                    {
                                        fete.AddInvite(idInvite);
                                    }
                                    Response.Redirect("Fete?fete=" + idFete);
                                }
                                // Si on essaye de quitter la f�te (sans �tre organisateur)
                                else if (HttpContext.Request.Query.ContainsKey("quitterFete"))
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

        public void OnPost()
        {
            // Si on ajoute un post
            if (Request.Form.ContainsKey("submitAddPost"))
            {
                int idFete = int.Parse(HttpContext.Request.Query["fete"]);
                string titre = Request.Form["titre"];
                string contenu = Request.Form["contenu"];

                Post post = new Post(titre, contenu);
                FeteManager.CreatePostWithoutId(post, idFete);
                Response.Redirect("Fete?fete=" + idFete);
            }
            // Si on rajoute un invit�
            if (Request.Form.ContainsKey("submitAddInvite"))
            {
                string recherche = Request.Form["recherche"];
                searchInvites = UtilisateurManager.Recherche(recherche);
                int idFete = int.Parse(HttpContext.Request.Query["fete"]);
                this.fete = FeteManager.GetById(idFete);
            }
        }
    }
}
