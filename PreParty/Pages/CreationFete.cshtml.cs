using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PreParty.Pages
{
    public class CreationFeteModel : PageModel
    {
        /*
        private string dateAjd;
        public string DateAjd
        {
            get { return dateAjd; }
            set
            {
                this.dateAjd = value;
            }
        }*/
        public void OnGet()
        {
            //this.dateAjd = DateTime.Now.ToString("o");
        }

        public void OnPost()
        {
            string nomFete = Request.Form["_nom_fete"];
            string adresse = Request.Form["_adresse"];
            string gps = Request.Form["_gps"];
            string dateDebut = Request.Form["_dateDebut"];
            string dateFin = Request.Form["_dateFin"];
            string description = Request.Form["_description"];
            var prix = Request.Form["_prix"];

            Console.WriteLine(nomFete);
            Console.WriteLine(adresse);
            Console.WriteLine(gps);     //vérifier not null à vérifier
            Console.WriteLine(dateDebut);
            Console.WriteLine(dateFin);
            Console.WriteLine(description);  //description not null àvérifier
            Console.WriteLine(prix);

            if (gps != null)
            {
                //To do
            }

            if (description != null)
            {
                //To do
            }

            //Insert les données
        }
    }
}
