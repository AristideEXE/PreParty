using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Utilisateur
    {
        public int IdUtilisateur { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateOnly DateNaissance { get; set; }
        public string Mail { get; set; }
        public string MotDePasse { get; }

        public Utilisateur(int idUtilisateur, string nom, string prenom, DateOnly dateNaissance, string mail, string motDePasse)
        {
            this.IdUtilisateur = idUtilisateur;
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
            this.Mail = mail;
            this.MotDePasse = motDePasse;
        }
    }
}
