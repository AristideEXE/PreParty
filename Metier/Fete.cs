using MySqlConnector;

namespace Metier
{
    public class Fete
    {
        public int IdFete { get; }
        public Utilisateur Utilisateur { get; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Lieu { get; set; }
        public string CoordonneesGPS { get; set; }
        public DateOnly dateDebut { get; set; }

        public Fete(int idFete, Utilisateur utilisateur, string nom, string description, string lieu, string coordonneesGPS, DateOnly dateDebut)
        {
            IdFete = idFete;
            Utilisateur = utilisateur;
            Nom = nom;
            Description = description;
            Lieu = lieu;
            CoordonneesGPS = coordonneesGPS;
            this.dateDebut = dateDebut;
        }

        public Fete(MySqlDataReader rdr)
        {
            rdr.Read();
            this.IdFete = rdr.GetInt32(0);
            int idUtilisateur = rdr.GetInt32(1);
            this.Nom = rdr.GetString(2);
            this.Description = rdr.GetString(3);
            this.Lieu = rdr.GetString(4);
            this.CoordonneesGPS = rdr.GetString(5);
            this.dateDebut = rdr.GetDateOnly(6);

            //this.Utilisateur = new Utilisateur(BDD.Select("SELECT * FROM utilisateur WHERE idUtilisateur= " + idUtilisateur));
        }
    }
}