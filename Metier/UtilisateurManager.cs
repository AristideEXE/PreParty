using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class UtilisateurManager
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
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idUtilisateur", utilisateur.IdUtilisateur);
                    cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                    cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
                    cmd.Parameters.AddWithValue("@dateNaissance", utilisateur.DateNaissance);
                    cmd.Parameters.AddWithValue("@mail", utilisateur.Mail);
                    cmd.Parameters.AddWithValue("@hash", utilisateur.Hash);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
        }

        /// <summary>
        /// Insere un utilisateur qui n'a pas d'identifiant dans la base de données
        /// </summary>
        /// <param name="utilisateur">L'utilisateur à ajouter</param>
        public static void CreateWithoutId (Utilisateur utilisateur)
        {
            try
            {
                string query = "INSERT INTO utilisateur (nom, prenom, dateNaissance, mail, hash) VALUES (@nom, @prenom, @dateNaissance, @mail, @hash)";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                    cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
                    cmd.Parameters.AddWithValue("@dateNaissance", utilisateur.DateNaissance);
                    cmd.Parameters.AddWithValue("@mail", utilisateur.Mail);
                    cmd.Parameters.AddWithValue("@hash", utilisateur.Hash);

                    cmd.ExecuteNonQuery();
                }
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
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idUtilisateur = reader.GetInt32(0);
                            string nom = reader.GetString(1);
                            string prenom = reader.GetString(2);
                            DateTime dateNaissance = Convert.ToDateTime(reader.GetString(3));
                            string mail = reader.GetString(4);
                            string hash = reader.GetString(5);

                            Utilisateur utilisateur = new Utilisateur(idUtilisateur, nom, prenom, dateNaissance, mail, hash);
                            utilisateurs.Add(utilisateur);
                        }
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
        public static Utilisateur GetById(int idUtilisateur)
        {
            Utilisateur utilisateur = new Utilisateur(idUtilisateur);
            try
            {
                string query = "SELECT idUtilisateur, nom, prenom, dateNaissance, mail, hash FROM utilisateur WHERE idUtilisateur = @idUtilisateur";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        utilisateur.Nom = reader.GetString(1);
                        utilisateur.Prenom = reader.GetString(2);
                        utilisateur.DateNaissance = reader.GetDateTime(3);
                        utilisateur.Mail = reader.GetString(4);
                        utilisateur.Hash = reader.GetString(5);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return utilisateur;
        }

        /// <summary>
        /// Renvoie un utilisateur par son mail, et nul si l'utilisateur n'est pas trouvé
        /// </summary>
        /// <param name="mail">L'identifiant de la personne</param>
        /// <returns>L'utilisateur ou null</returns>
        public static Utilisateur GetByMail(string mail)
        {
            Utilisateur utilisateur = null;
            try
            {
                string query = "SELECT idUtilisateur, nom, prenom, dateNaissance, mail, hash FROM utilisateur WHERE mail = @mail";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@mail", mail);

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            utilisateur = new Utilisateur(reader.GetInt32(0));
                            utilisateur.Nom = reader.GetString(1);
                            utilisateur.Prenom = reader.GetString(2);
                            utilisateur.DateNaissance = reader.GetDateTime(3);
                            utilisateur.Mail = reader.GetString(4);
                            utilisateur.Hash = reader.GetString(5);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return utilisateur;
        }


        /// <summary>
        /// Renvoie true si l'utilisateur existe et false sinon
        /// </summary>
        /// <param name="idUtilisateur">L'identifiant de l'utilisateur</param>
        /// <returns></returns>
        public static bool UtilisateurExists(int idUtilisateur)
        {
            string query = "SELECT * FROM utilisateur WHERE idUtilisateur = @idUtilisateur";
            using (MySqlConnection conn = Connexion.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public static List<Fete> GetInvitations(int idUtilisateur)
        {
            List<Fete> fetes = new List<Fete>();
            try
            {
                string query = "SELECT idFete FROM invites WHERE idUtilisateur = @idUtilisateur";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idFete = reader.GetInt32(0);
                            fetes.Add(FeteManager.GetById(idFete));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return fetes;
        }

        public static List<Fete> GetOrganisations(int idUtilisateur)
        {
            List<Fete> fetes = new List<Fete>();
            try
            {
                string query = "SELECT idFete, organisateur, nom, description, lieu, coordonneesGPS, debutFete, finFete FROM fete WHERE organisateur=@idUtilisateur";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);


                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idFete = reader.GetInt32(0);
                            int idOrganisateur = reader.GetInt32(1);
                            Utilisateur organisateur = UtilisateurManager.GetById(idOrganisateur);
                            string nom = reader.GetString(2);
                            string description = reader.GetString(3);
                            string lieu = reader.GetString(4);
                            string coordonneesGPS = reader.GetString(5);
                            DateTime debutFete = reader.GetDateTime(6);
                            DateTime finFete = reader.GetDateTime(7);

                            Fete fete = new Fete(idFete, organisateur, nom, description, lieu, coordonneesGPS, debutFete, finFete);
                            fete.Invites = FeteManager.GetInvites(idFete);
                            fetes.Add(fete);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return fetes;
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
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idUtilisateur", utilisateur.IdUtilisateur);
                    cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                    cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
                    cmd.Parameters.AddWithValue("@dateNaissance", utilisateur.DateNaissance);
                    cmd.Parameters.AddWithValue("@mail", utilisateur.Mail);
                    cmd.Parameters.AddWithValue("@hash", utilisateur.Hash);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
        }

        public static void UpdateInfo(Utilisateur utilisateur)
        {
            try
            {
                string query = "UPDATE utilisateur SET nom = @nom, prenom = @prenom, dateNaissance = @dateNaissance, mail = @mail WHERE idUtilisateur = @idUtilisateur";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                    cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
                    cmd.Parameters.AddWithValue("@dateNaissance", utilisateur.DateNaissance);
                    cmd.Parameters.AddWithValue("@mail", utilisateur.Mail);
                    cmd.Parameters.AddWithValue("@idUtilisateur", utilisateur.IdUtilisateur);


                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
        }

        public static void UpdateMdp(Utilisateur utilisateur,string hash)
        {
            try
            {
                string query = "UPDATE utilisateur SET hash = @hash WHERE idUtilisateur = @idUtilisateur";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;

                    cmd.Parameters.AddWithValue("@hash", hash);
                    cmd.Parameters.AddWithValue("@idUtilisateur", utilisateur.IdUtilisateur);


                    cmd.ExecuteNonQuery();
                }
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
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
        }

        /// <summary>
        /// Permet une recherche par nom, prénom ou adresse mail
        /// </summary>
        /// <param name="recherche"></param>
        public static List<Utilisateur> Recherche (string recherche)
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();
            try
            {
                string query = "SELECT idUtilisateur, nom, prenom, dateNaissance, mail, hash FROM utilisateur WHERE prenom LIKE @recherche OR nom LIKE @recherche or mail LIKE @recherche";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@recherche", "%" + recherche + "%");

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idUtilisateur = reader.GetInt32(0);
                            string nom = reader.GetString(1);
                            string prenom = reader.GetString(2);
                            DateTime dateNaissance = Convert.ToDateTime(reader.GetString(3));
                            string mail = reader.GetString(4);
                            string hash = reader.GetString(5);

                            Utilisateur utilisateur = new Utilisateur(idUtilisateur, nom, prenom, dateNaissance, mail, hash);
                            utilisateurs.Add(utilisateur);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return utilisateurs;
        }
    }
}
