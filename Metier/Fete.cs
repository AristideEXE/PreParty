namespace Metier
{
    public class Fete
    {
        #region attributs

        public int IdFete { get; set; }
        public Utilisateur Organisateur { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Lieu { get; set; }
        public string CoordonneesGPS { get; set; }
        public DateTime DebutFete { get; set; }
        public DateTime FinFete { get; set; }

        public int Prix { get; set; }

        public List<Utilisateur> Invites { get; set; }
        public List<Post> Posts { get; set; }

        #endregion

        #region constructeur

        public Fete(int idFete)
        {
            IdFete = idFete;
        }

        public Fete(int idFete, Utilisateur organisateur, string nom, string description, string lieu, string coordonneesGPS, DateTime debutFete, DateTime finFete)
        {
            IdFete = idFete;
            Organisateur = organisateur;
            Nom = nom;
            Description = description;
            Lieu = lieu;
            CoordonneesGPS = coordonneesGPS;
            DebutFete = debutFete;
            FinFete = finFete;
        }

        public Fete(string nom, Utilisateur organisateur, string adresse, string gps, DateTime debutFete, DateTime finFete, string description,int prix)
        {
            Nom = nom;
            Organisateur = organisateur;
            Lieu = adresse;
            CoordonneesGPS = gps;
            DebutFete = debutFete;
            FinFete = finFete;
            Description = description;
            Prix = prix;
        }

        #endregion

        #region methodes

        public void AddInvite(int idInvite)
        {
            Invites.Add(UtilisateurManager.GetById(idInvite));
            FeteManager.AddInvite(IdFete, idInvite);

            // Notification
            string notif = "Vous avez été invité à " + Nom;
            string redirection = "/Fete?fete=" + IdFete;
            UtilisateurManager.CreateNotification(notif, idInvite, redirection);
        }

        public void RemoveInvite(int idInvite)
        {
            Invites.Remove(UtilisateurManager.GetById(idInvite));
            FeteManager.RemoveInvite(IdFete, idInvite);
            
            // Notification
            string notif = "Vous avez été retiré de la liste des invités de " + Nom;
            UtilisateurManager.CreateNotification(notif, idInvite);
        }

        public void QuitterFete(int idInvite)
        {
            Utilisateur invite = UtilisateurManager.GetById(idInvite);
            Invites.Remove(invite);
            FeteManager.RemoveInvite(IdFete, idInvite);

            // Notification
            string notif = invite.Prenom + " " + invite.Nom + " a quitté " + Nom;
            UtilisateurManager.CreateNotification(notif, Organisateur.IdUtilisateur);
        }

        public void AjouterPoste(Post post)
        {
            Posts.Add(post);
            FeteManager.CreatePostWithoutId(post, IdFete);

            // Notifications à tous les invités
            string notif = "Un post a été ajouté à " + Nom;
            string redirection = "/Fete?fete=" + IdFete;
            foreach (Utilisateur invite in Invites)
            {
                UtilisateurManager.CreateNotification(notif, invite.IdUtilisateur, redirection);
            }
        }

        public override string ToString()
        {
            return $"{Nom}, {Description}, {Lieu}, {Invites.Count} invités";
        }

        #endregion
    }
}