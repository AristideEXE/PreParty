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
        public DateTime datePost { get; set; }
        public string Contenu { get; set; }

        public Post(int idPost, string titre, DateTime datePost, string contenu)
        {
            IdPost = idPost;
            Titre = titre;
            this.datePost = datePost;
            Contenu = contenu;
        }
    }
}
