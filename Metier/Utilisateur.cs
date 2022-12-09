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
        public DateTime DateNaissance { get; set; }
        public string Mail { get; set; }
        public string Hash { get; set; }

        public Utilisateur(int idUtilisateur, string nom, string prenom, DateTime dateNaissance, string mail, string hash)
        {
            this.IdUtilisateur = idUtilisateur;
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
            this.Mail = mail;
            this.Hash = hash;
        }

        public Utilisateur(int idUtilisateur)
        {
            this.IdUtilisateur = idUtilisateur;
        }

        public override string ToString()
        {
            return $"{Prenom} {Nom}, né le {DateNaissance}";
        }
    }
}
