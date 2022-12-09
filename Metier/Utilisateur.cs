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
        public int IdUtilisateur { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Mail { get; set; }
        public string Hash { get; set; }

        /// <summary>
        /// Permet de créer le hash du mot de passe
        /// </summary>
        public string Password
        {
            set
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    Hash = builder.ToString();
                }
            }
        }


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

        /// <summary>
        /// Vérifie le mot de passe de l'utilisateur
        /// </summary>
        /// <param name="password">Le mot de passe rentré</param>
        /// <returns>True si le mot de passe est valide, False sinon</returns>
        public bool PasswordVerify(string password)
        {
            string hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                hash = builder.ToString();
            }
            return hash == Hash;
        }

        /// <summary>
        /// To String de l'utilisateur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Prenom} {Nom}, né le {DateNaissance}, {Hash}";
        }
    }
}
