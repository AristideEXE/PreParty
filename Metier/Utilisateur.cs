using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.Pkcs;
using Google.Protobuf.WellKnownTypes;

namespace Metier
{
    public class Utilisateur
    {
        #region attributs

        public int IdUtilisateur { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Mail { get; set; }
        public string Hash { get; set; }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        /// <summary>
        /// Permet de créer le hash du mot de passe
        /// </summary>
        public string Password
        {
            set
            {
                Hash = GetHashString(value);
            }
        }

        #endregion

        #region constructeurs
        public Utilisateur(int idUtilisateur, string nom, string prenom, DateTime dateNaissance, string mail, string hash)
        {
            this.IdUtilisateur = idUtilisateur;
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
            this.Mail = mail;
            this.Hash = hash;
        }

        /// <summary>
        /// Construire un utilisateur sans id
        /// </summary>
        /// <param name="nom">nom de l'utilisateur</param>
        /// <param name="prenom">prenom de l'utilisateur</param>
        /// <param name="dateNaissance">sa date de naissance</param>
        /// <param name="mail">son mail</param>
        /// <param name="hash">son mot de passe hashé</param>
        public Utilisateur(string nom, string prenom, DateTime dateNaissance, string mail, string hash)
        {
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

        #endregion

        #region methodes
        /// <summary>
        /// Vérifie le mot de passe de l'utilisateur
        /// </summary>
        /// <param name="password">Le mot de passe rentré</param>
        /// <returns>True si le mot de passe est valide, False sinon</returns>
        public bool PasswordVerify(string password)
        {
            string hash = GetHashString(password);
            return hash == Hash;
        }

        /// <summary>
        /// To String de l'utilisateur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Prenom} {Nom}, né le {DateNaissance.Date}, {Hash}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Utilisateur utilisateur &&
                   IdUtilisateur == utilisateur.IdUtilisateur &&
                   Nom == utilisateur.Nom &&
                   Prenom == utilisateur.Prenom &&
                   DateNaissance == utilisateur.DateNaissance &&
                   Mail == utilisateur.Mail &&
                   Hash == utilisateur.Hash;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdUtilisateur, Nom, Prenom, DateNaissance, Mail, Hash);
        }

        #endregion
    }
}
