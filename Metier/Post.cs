using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Post
    {
        public int IdPost { get; set; }
        public string Titre { get; set; }
        public DateTime DatePost { get; set; }
        public string Contenu { get; set; }

        public Post(int idPost, string titre, DateTime datePost, string contenu)
        {
            IdPost = idPost;
            Titre = titre;
            DatePost = datePost;
            Contenu = contenu;
        }

        public Post(string titre, string contenu)
        {
            Titre = titre;
            Contenu = contenu;
            DatePost = DateTime.Now;
        }
    }
}
