using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PreParty.Pages
{
    public class CreationFeteModel : PageModel
    {
        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                this.date = value;
            }
        }
        public void OnGet()
        {
            this.date = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public void OnPost()
        {
            string nomFete = Request.Form["_nom_fete"];
            string adresse = Request.Form["_adresse"];
            string gps = Request.Form["_gps"];
            string date = Request.Form["_date"];
            var hDebut = Request.Form["_hdebut"];
            var hFin = Request.Form["_hfin"];
            string description = Request.Form["_description"];
            var prix = Request.Form["_prix"];

            Console.WriteLine(nomFete);
            Console.WriteLine(adresse);
            Console.WriteLine(gps);     //vérifier not null à vérifier
            Console.WriteLine(date);
            Console.WriteLine(hDebut);
            Console.WriteLine(hFin);
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
