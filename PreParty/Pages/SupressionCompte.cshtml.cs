using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PreParty.Pages
{
    public class SupressionCompteModel : PageModel
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
            string choix = Request.Form["choix"];
            if(choix == "oui")
            {
                List < Fete > fetes= FeteManager.ReadAll();
                //Si il y a des f�tes
                if(fetes.Count > 0)
                {
                    List<Fete> fetesOrgansiteur = new List<Fete>();
                    List<Fete> fetesInvite = new List<Fete>();
                    foreach(Fete fete in fetes)
                    {
                        //Si on est organisateur
                        if(fete.Organisateur.IdUtilisateur == User.IdUtilisateur)
                        {
                            fetesOrgansiteur.Add(fete);
                        }
                        List<Utilisateur> utilisateurs = FeteManager.GetInvites(fete.IdFete);
                        //si il y des invit�
                        if(utilisateurs.Count > 0)
                        {
                            foreach(Utilisateur utilisateur in utilisateurs)
                            {
                                //Si on est invit� alors on se retire de la fete
                                if(utilisateur.IdUtilisateur == User.IdUtilisateur)
                                {
                                    FeteManager.RemoveInvite(fete.IdFete,User.IdUtilisateur);
                                }
                            }
                        }
                      
                    }
                    //On regarde si il y a des f�tes qui sont organis�es par l'utilisateur qui doit �tre supprimer
                    if (fetesOrgansiteur.Count > 0)
                    {
                        foreach (Fete fete in fetesOrgansiteur)
                        {
                            List<Utilisateur> invites = FeteManager.GetInvites(fete.IdFete);
                            //On regarde si il y a des invit�s dans cette f�te
                            if (invites.Count > 0)
                            {
                                //On les supprime
                                foreach(Utilisateur invite in invites)
                                {
                                    FeteManager.RemoveInvite(fete.IdFete,invite.IdUtilisateur);
                                }
                                //On supprime la f�te
                                FeteManager.Delete(fete.IdFete);

                                //On supprime le compte
                                UtilisateurManager.Delete(User.IdUtilisateur);
                                UtilisateurLogin.Instance.Disconnect();
                                Response.Redirect("Index");
                            }
                            else
                            {
                                //On supprime la f�te
                                FeteManager.Delete(fete.IdFete);

                                //On supprime le compte
                                UtilisateurManager.Delete(User.IdUtilisateur);
                                UtilisateurLogin.Instance.Disconnect();
                                Response.Redirect("Index");
                            }
                        }
                    }
                    else
                    {
                        UtilisateurManager.Delete(User.IdUtilisateur);
                        UtilisateurLogin.Instance.Disconnect();
                        Response.Redirect("Index");
                    }
                }
                else
                {
                    UtilisateurManager.Delete(User.IdUtilisateur);
                    UtilisateurLogin.Instance.Disconnect();
                    Response.Redirect("Index");
                }
                
            }
            else
            {
                Response.Redirect("Index");
            }
        }
    }
}
