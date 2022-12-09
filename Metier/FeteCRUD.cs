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
            //List<Fete> fetes = new List<Fete>();
            //try
            //{
            //    string query = "SELECT idFete, organisateur, nom, description, lieu, coordonneesGPS, debutFete, finFete FROM fete";
            //    MySqlCommand cmd = Connexion.Instance.CreateCommand();
            //    cmd.CommandText = query;

            //    using (DbDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            int idFete = reader.GetInt32(0);
            //            int idOrganisateur = reader.GetInt32(1);
            //            Utilisateur organisateur = UtilisateurCRUD.GetById(idOrganisateur);
            //            string nom = reader.GetString(2);
            //            string description = reader.GetString(3);
            //            string lieu = reader.GetString(4);
            //            string coordonneesGPS = reader.GetString(5);
            //            DateTime debutFete = reader.GetDateTime(6);
            //            DateTime finFete = reader.GetDateTime(7);

            //            Fete fete = new Fete(idFete, organisateur, nom, description, lieu, coordonneesGPS, debutFete, finFete);
            //            fetes.Add(fete);
            //        }
            //    }
            //    foreach (Fete fete in fetes)
            //    {
            //        fete.Invites = FeteCRUD.GetInvites(fete.IdFete);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Une erreur est survenue : " + e);
            //}
            //return fetes;
            return null;
        }

        public static List<Utilisateur> GetInvites(int idFete)
        {
            List<Utilisateur> invites = new List<Utilisateur>();
            try
            {
                string query = "SELECT idUtilisateur FROM invites WHERE idFete = @idFEte";
                MySqlCommand cmd = Connexion.Instance.CreateCommand();

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@idFEte", idFete);

                List<int> idInvites = new List<int>();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idInvites.Add(reader.GetInt32(0));
                    }
                }
                foreach(int idInvite in idInvites)
                {
                    Utilisateur invite = UtilisateurCRUD.GetById(idInvite);
                    invites.Add(invite);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e);
            }
            return invites;
        }
    }
}
