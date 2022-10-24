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
        public static BDD Instance
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

        public BDD(){
            this.server = "localhost";
            this.user = "root";
            this.database = "preparty";
            this.connexion = new MySqlConnection("server=" + server + ";user id=" + user + ";database=" + database + ";");
        }

        private string server;
        private string user;
        private string database;

        private MySqlConnection connexion;

        public static void Open()
        {
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
