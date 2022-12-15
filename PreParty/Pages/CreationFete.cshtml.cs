using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PreParty.Pages
{
    public class CreationFeteModel : PageModel
    {
        
        private string dateAjd="";
        public string DateAjd
        {
            get { return dateAjd; }
            set
            {
                this.dateAjd = value;
            }
        }
        public void OnGet()
        {
            this.dateAjd = DateTime.Now.ToString("o");
            string dateTemp = "";
            for (int i = 0; i < 16; i++)
            {
                dateTemp += dateAjd[i];
            }
            this.dateAjd = dateTemp;
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

            //Convertion des données
            DateTime dDebut = Convert.ToDateTime(dateDebut);
            DateTime dFin = Convert.ToDateTime(dateFin);
            
            int p = Convert.ToInt32(prix);

            int result = DateTime.Compare(dDebut, dFin);
            //Si la date de fin est plus tôt que la date de début
            if(result > 0)
            {
                string dTemp = dateFin;
                dateFin = dateDebut;
                dateDebut = dTemp;
            }

            dDebut = Convert.ToDateTime(dateDebut);
            dFin = Convert.ToDateTime(dateFin);

            //Création de la fête (objet)
            Fete fete = new Fete(nomFete,UtilisateurLogin.Instance.GetUtilisateur(), adresse, gps, dDebut, dFin, description, p);
            FeteManager.CreateWithoutId(fete);
            Response.Redirect("Index");



            //Insert les données
        }
    }
}
