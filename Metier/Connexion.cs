using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Connexion
    {
        private static MySqlConnection instance;
        public static MySqlConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    string connexionString = "Data Source=localhost;Initial Catalog=preparty;User ID=root;Password=";
                    instance = new MySqlConnection(connexionString);
                    Connexion.Instance.Open();
                    Console.WriteLine("Connecté à la base de données");
                }
                return instance;
            }
        }

        private Connexion() { }
    }
}
