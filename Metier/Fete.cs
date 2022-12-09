namespace Metier
{
    public class Fete
    {
        public int IdFete { get; set; }
        public Utilisateur Organisateur { get; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Lieu { get; set; }
        public string CoordonneesGPS { get; set; }
        public DateOnly DateFete { get; set; }

        public Fete(int idFete, Utilisateur utilisateur, string nom, string description, string lieu, string coordonneesGPS, DateOnly dateDebut)
        {
            IdFete = idFete;
            Organisateur = utilisateur;
            Nom = nom;
            Description = description;
            Lieu = lieu;
            CoordonneesGPS = coordonneesGPS;
            this.DateFete = dateDebut;
        }

        public Fete()
        {

        }
    }
}