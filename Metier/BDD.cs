using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class BDD
    {
        private static BDD instance;
        private static BDD Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BDD();
                }
                return instance;
            }
        }

        private string connexionString;
        private MySqlConnection connexion;

        public BDD(){
            string server = "localhost";
            string user = "root";
            string database = "preparty";
            this.connexionString = "server=" + server + ";user id=" + user + ";database=" + database + ";";
        }

        public static void Open()
        {
            Instance.connexion = new MySqlConnection(Instance.connexionString);
            Instance.connexion.Open();
        }

        public static void Close()
        {
            Instance.connexion.Close();
        }

        public static MySqlDataReader Select(string selection)
        {
            MySqlCommand cmd = new MySqlCommand(selection, Instance.connexion);
            return cmd.ExecuteReader();
        }
    }
}
