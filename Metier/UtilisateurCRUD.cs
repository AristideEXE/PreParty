using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class UtilisateurCRUD
    {
        /// <summary>
        /// Insere un utilisateur dans la base de données
        /// </summary>
        /// <param name="utilisateur"></param>
        public static void Create (Utilisateur utilisateur)
        {
            try
            {
                string query = "INSERT INTO utilisateur (idUtilisateur, nom, prenom, dateNaissance, mail, hash) VALUES (@idUtilisateur, @nom, @prenom, @dateNaissance, @mail, @hash)";
                MySqlCommand cmd = Connexion.Instance.CreateCommand();

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@idUtilisateur", utilisateur.IdUtilisateur);
                cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
                cmd.Parameters.AddWithValue("@dateNaissance", utilisateur.DateNaissance);
                cmd.Parameters.AddWithValue("@mail", utilisateur.Mail);
                cmd.Parameters.AddWithValue("@hash", utilisateur.Hash);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
        }

        /// <summary>
        /// Renvoie la liste de tous les utilisateurs de la bdd
        /// </summary>
        /// <returns>La liste des utilisateurs</returns>
        public static List<Utilisateur> ReadAll()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();
            try
            {
                string query = "SELECT idUtilisateur, nom, prenom, dateNaissance, mail, hash FROM utilisateur";
                MySqlCommand cmd = Connexion.Instance.CreateCommand();
                cmd.CommandText = query;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idUtilisateur = reader.GetInt32(0);
                        string nom = reader.GetString(1);
                        string prenom = reader.GetString(2);
                        DateTime dateNaissance = reader.GetDateTime(3);
                        string mail = reader.GetString(4);
                        string hash = reader.GetString(5);

                        Utilisateur utilisateur = new Utilisateur(idUtilisateur, nom, prenom, dateNaissance, mail, hash);
                        utilisateurs.Add(utilisateur);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return utilisateurs;
        }


        /// <summary>
        /// Renvoie un utilisateur par son identifiant
        /// </summary>
        /// <param name="id">L'identifiant de la personne</param>
        /// <returns>L'utilisateur</returns>
        public static Utilisateur GetById(int id)
        {
            Utilisateur utilisateur = new Utilisateur(id);
            try
            {
                string query = "SELECT idUtilisateur, nom, prenom, dateNaissance, mail, hash FROM utilisateur WHERE idUtilisateur = @idUtilisateur";
                MySqlCommand cmd = Connexion.Instance.CreateCommand();     
                
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@idUtilisateur", id);

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    utilisateur.Nom = reader.GetString(1);
                    utilisateur.Prenom = reader.GetString(2);
                    DateTime dateNaissance = reader.GetDateTime(3);
                    utilisateur.Mail = reader.GetString(4);
                    utilisateur.Hash = reader.GetString(5);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return utilisateur;
        }


        /// <summary>
        /// Modifie l'utilisateur dans la base de données
        /// </summary>
        /// <param name="utilisateur">L'utilisateur à modifier</param>
        public static void Update(Utilisateur utilisateur)
        {
            try
            {
                string query = "UPDATE utilisateur SET idUtilisateur = @idUtilisateur, nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance, mail = @mail, hash = @hash WHERE idUtilisateur = @idUtilisateur";
                MySqlCommand cmd = Connexion.Instance.CreateCommand();

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@idUtilisateur", utilisateur.IdUtilisateur);
                cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
                cmd.Parameters.AddWithValue("@dateNaissance", utilisateur.DateNaissance);
                cmd.Parameters.AddWithValue("@mail", utilisateur.Mail);
                cmd.Parameters.AddWithValue("@hash", utilisateur.Hash);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
        }

        /// <summary>
        /// Supprime un utilisateur de la base de données
        /// </summary>
        /// <param name="idUtilisateur">Identifiant de l'utilisateur à supprimer</param>
        public static void Delete (int idUtilisateur)
        {
            try
            {
                string query = "DELETE FROM utilisateur WHERE idUtilisateur = @idUtilisateur";
                MySqlCommand cmd = Connexion.Instance.CreateCommand();

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
        }
    }
}
