using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PreParty.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Utilisateur toto = new Utilisateur(7);
            toto.Nom = "Dupont";
            toto.Prenom = "Toto";
            toto.DateNaissance = new DateTime(2008, 05, 22);
            toto.Mail = "toto@gmail.com";
            toto.Password = "azerty";

            Console.WriteLine(toto);
            Console.WriteLine(toto.PasswordVerify("test"));
            Console.WriteLine(toto.PasswordVerify("azerty"));

            //Console.WriteLine("Ajout d'un utilisateur");
            //Utilisateur toto = new Utilisateur(7, "Tata", "Toto", new DateTime(2008, 12, 4), "toto@gmail.com", "azerty");
            //UtilisateurCRUD.Create(toto);
            //foreach (Utilisateur utilisateur in UtilisateurCRUD.ReadAll())
            //{
            //    Console.WriteLine(utilisateur);
            //}

            //Console.WriteLine();

            //Console.WriteLine("Modification d'un utilisateur");
            //toto.Prenom = "Polo";
            //UtilisateurCRUD.Update(toto);
            //foreach (Utilisateur utilisateur in UtilisateurCRUD.ReadAll())
            //{
            //    Console.WriteLine(utilisateur);
            //}

            //Console.WriteLine();

            //Console.WriteLine("Suppression de l'utilisateur");
            //UtilisateurCRUD.Delete(7);
            //foreach(Utilisateur utilisateur in UtilisateurCRUD.ReadAll())
            //{
            //    Console.WriteLine(utilisateur);
            //}

            //Console.WriteLine();

            //Console.WriteLine("Utilisateur numéro 5 : ");
            //Console.WriteLine(UtilisateurCRUD.GetById(5));
        }
    }
}