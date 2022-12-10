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
            Console.WriteLine("======================== Ajout d'un utilisateur ========================");

            Utilisateur toto = new Utilisateur(7);
            toto.Nom = "Dupont";
            toto.Prenom = "Toto";
            toto.DateNaissance = new DateTime(2008, 05, 15);
            toto.Mail = "toto@gmail.com";
            toto.Password = "azerty";

            UtilisateurCRUD.Create(toto);
            foreach (Utilisateur utilisateur in UtilisateurCRUD.ReadAll())
            {
                Console.WriteLine(utilisateur);
            }


            Console.WriteLine();
            Console.WriteLine("======================== Modification d'un utilisateur ========================");
            toto.Prenom = "Polo";
            UtilisateurCRUD.Update(toto);
            foreach (Utilisateur utilisateur in UtilisateurCRUD.ReadAll())
            {
                Console.WriteLine(utilisateur);
            }

            Console.WriteLine();
            Console.WriteLine("======================== Utilisateur numéro 2 :  ========================");
            Console.WriteLine(UtilisateurCRUD.GetById(2));


            Console.WriteLine();
            Console.WriteLine("======================== Affichage des fêtes ========================");
            foreach (Fete fete in FeteCRUD.ReadAll())
            {
                Console.WriteLine(fete);
            }

            Console.WriteLine();
            Console.WriteLine("======================== Ajout de toto à la fête ========================");
            FeteCRUD.AddInvite(1, toto.IdUtilisateur);
            Console.WriteLine(FeteCRUD.GetById(1));

            Console.WriteLine();
            Console.WriteLine("======================== Suppression de toto àa la fête ========================");
            FeteCRUD.RemoveInvite(1, toto.IdUtilisateur);
            Console.WriteLine(FeteCRUD.GetById(1));

            Console.WriteLine();
            Console.WriteLine("======================== Suppression de l'utilisateur ========================");
            UtilisateurCRUD.Delete(7);
            foreach (Utilisateur utilisateur in UtilisateurCRUD.ReadAll())
            {
                Console.WriteLine(utilisateur);
            }
        }
    }
}