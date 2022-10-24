namespace Metier
{
    public class Fete
    {
        public int IdFete { get; }
        public int IdUtilisateur { get; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Lieu { get; set; }
        public string CoordonneesGPS { get; set; }
        public DateOnly dateDebut { get; set; }
    }
}