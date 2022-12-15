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

        #endregion

        #region methodes

        public void AddInvite(int idInvite)
        {
            Invites.Add(UtilisateurManager.GetById(idInvite));
            FeteManager.AddInvite(IdFete, idInvite);
            // Envoyer notification
        }

        public void RemoveInvite(int idInvite)
        {
            Invites.Remove(UtilisateurManager.GetById(idInvite));
            FeteManager.RemoveInvite(IdFete, idInvite);
            // Envoyer notification
        }

        public void QuitterFete(int idInvite)
        {
            Invites.Remove(UtilisateurManager.GetById(idInvite));
            FeteManager.RemoveInvite(IdFete, idInvite);
            // Envoyer notification à l'organisateur 
        }

        public override string ToString()
        {
            return $"{Nom}, {Description}, {Lieu}, {Invites.Count} invités";
        }

        #endregion
    }
}