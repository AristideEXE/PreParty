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
        public static MySqlConnection GetConnection()
        {
            string connexionString = "Data Source=localhost;Initial Catalog=preparty;User ID=root;Password=";
            MySqlConnection conn = new MySqlConnection(connexionString);
            return conn;
        }

        private Connexion() { }
    }
}
