using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class FeteCRUD
    {
        /// <summary>
        /// Ajoute une fête dans la BDD;
        /// </summary>
        /// <param name="fete">La fête à ajouter</param>
        public static void Create(Fete fete)
        {

        }

        /// <summary>
        /// Renvoie la liste de toutes les fêtes de la bdd
        /// </summary>
        /// <returns>La liste des utilisateurs</returns>
        public static List<Fete> ReadAll()
        {
            List<Fete> fetes = new List<Fete>();
            try
            {
                string query = "SELECT idFete, organisateur, nom, description, lieu, coordonneesGPS, debutFete, finFete FROM fete";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idFete = reader.GetInt32(0);
                            int idOrganisateur = reader.GetInt32(1);
                            Utilisateur organisateur = UtilisateurCRUD.GetById(idOrganisateur);
                            string nom = reader.GetString(2);
                            string description = reader.GetString(3);
                            string lieu = reader.GetString(4);
                            string coordonneesGPS = reader.GetString(5);
                            DateTime debutFete = reader.GetDateTime(6);
                            DateTime finFete = reader.GetDateTime(7);

                            Fete fete = new Fete(idFete, organisateur, nom, description, lieu, coordonneesGPS, debutFete, finFete);
                            fete.Invites = GetInvites(idFete);
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
        /// Renvoie une fête
        /// </summary>
        /// <param name="idFete">L'identifiant de la fête</param>
        /// <returns>La fête choisie</returns>
        public static Fete GetById(int idFete)
        {
            Fete fete = new Fete(idFete);
            try
            {
                string query = "SELECT organisateur, nom, description, lieu, coordonneesGPS, debutFete, finFete FROM fete WHERE idFete = @idFete";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idFete", idFete);

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        int idOrganisateur = reader.GetInt32(0);
                        fete.Organisateur = UtilisateurCRUD.GetById(idOrganisateur);
                        fete.Nom = reader.GetString(1);
                        fete.Description = reader.GetString(2);
                        fete.Lieu = reader.GetString(3);
                        fete.CoordonneesGPS = reader.GetString(4);
                        fete.DebutFete = reader.GetDateTime(5);
                        fete.FinFete = reader.GetDateTime(6);
                        fete.Invites = GetInvites(idFete);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return fete;
        }

        /// <summary>
        /// Renvoie la liste des invités d'une fête
        /// </summary>
        /// <param name="idFete">L'identifiant de la fête</param>
        /// <returns>La liste des invités</returns>
        public static List<Utilisateur> GetInvites(int idFete)
        {
            List<Utilisateur> invites = new List<Utilisateur>();
            try
            {
                string query = "SELECT idUtilisateur FROM invites WHERE idFete = @idFete";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idFete", idFete);

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idInvite = reader.GetInt32(0);
                            invites.Add(UtilisateurCRUD.GetById(idInvite));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return invites;
        }

        /// <summary>
        /// Supprim un invité d'une fête dans la base de données si il est bien invité
        /// </summary>
        /// <param name="idInvite"></param>
        /// <param name="idFete"></param>
        public static void RemoveInvite(int idFete,int idInvite)
        {
            try
            {
                string query = "DELETE FROM invites WHERE idUtilisateur = @idUtilisateur && idFete = @idFete";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idUtilisateur", idInvite);
                    cmd.Parameters.AddWithValue("@idFete", idFete);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
        }

        public static void AddInvite(int idFete, int idInvite)
        {
            try
            {
                string query = "INSERT INTO invites (idFete,idUtilisateur) VALUES (@idFete, @idUtilisateur)";
                using (MySqlConnection conn = Connexion.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idFete", idFete);
                    cmd.Parameters.AddWithValue("@idUtilisateur", idInvite);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
        }
    }
}
