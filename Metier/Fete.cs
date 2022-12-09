﻿namespace Metier
{
    public class Fete
    {
        public int IdFete { get; set; }
        public Utilisateur Organisateur { get; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Lieu { get; set; }
        public string CoordonneesGPS { get; set; }
        public DateTime DebutFete { get; set; }
        public DateTime FinFete { get; set; }

        public List<Utilisateur> Invites { get; set; }

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

        public override string ToString()
        {
            return $"{Nom}, {Description}, {Lieu}, {Invites.Count} invités";
        }
    }
}