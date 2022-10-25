using MySqlConnector;

namespace Metier
{
    public class Fete
    {
        public int IdFete { get; }
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

        public Fete(Dictionary<string, string> dic)
        {
            this.IdFete = int.Parse(dic["idFete"]);
            int idUtilisateur = int.Parse(dic["idUtilisateur"]);
            this.Nom = dic["nom"];
            this.Description = dic["description"];
            this.Lieu = dic["lieu"];
            //this.CoordonneesGPS = dic["CoordonnesGPS"];
            //this.DateFete = DateOnly.Parse(dic["dateFete"]);

            this.Organisateur = new Utilisateur(BDD.SelectSingleLine("SELECT * FROM utilisateur WHERE idUtilisateur= " + idUtilisateur));
        }
    }
}