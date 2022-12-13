using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class UtilisateurLogin
    {
        /// <summary>
        /// Singleton
        /// </summary>
        private static UtilisateurLogin instance;
        public static UtilisateurLogin Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UtilisateurLogin();
                }
                return instance;
            }
        }

        /// <summary>
        /// L'utilisateur connecté
        /// </summary>
        private Utilisateur login;

        /// <summary>
        /// Connecte un utilisateur
        /// </summary>
        /// <param name="utilisateur">L'utilisateur à connecter</param>
        public void Connect(Utilisateur utilisateur)
        {
            login = utilisateur;
        }

        /// <summary>
        /// Déconnecte l'utilisateur
        /// </summary>
        public void Disconnect()
        {
            login = null;
        }

        /// <summary>
        /// Renvoie si un utilisateur est connecté ou non
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return login != null;
            }
        }

        /// <summary>
        /// Renvoie l'utilisateur connecté, null si la personne n'est pas connectée
        /// </summary>
        /// <returns></returns>
        public Utilisateur GetUtilisateur()
        {
            return login;
        }

        /// <summary>
        /// Constructeur du singleton
        /// </summary>
        private UtilisateurLogin()
        {

        }
    }
}
