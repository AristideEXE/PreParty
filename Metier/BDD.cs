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
        private static string connexionString = "server=localhost;user id=root; database=preparty";
        private static MySqlConnection connexion = new MySqlConnection(BDD.connexionString);

        public BDD(){
        }

        public static void Open()
        {
            BDD.connexion.Open();
        }

        public static void Close()
        {
            BDD.connexion.Close();
        }

        public static Dictionary<string, string> SelectSingleLine(string selection)
        {
            Open();
            MySqlCommand cmd = new MySqlCommand(selection, BDD.connexion);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Dictionary<string, string> result = DataReaderLigneToDictionnary(rdr);
            Close();
            return result;
        }

        private static Dictionary<string,string> DataReaderLigneToDictionnary(MySqlDataReader rdr)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            rdr.Read();
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                result[rdr.GetName(i)] = rdr.GetValue(i).ToString();
            }
            return result;
        }
    }
}
