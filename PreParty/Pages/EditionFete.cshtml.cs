using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PreParty.Pages
{
    public class EditionFeteModel : PageModel
    {
        private Fete fete = FeteManager.GetById(7);

        public Fete Fete
        {
            get { return fete; }
        }

        private string dateAjd = "";
        public string DateAjd
        {
            get { return dateAjd; }
            set
            {
                this.dateAjd = value;
            }
        }

        private string dateDebut = "";
        public string DateDebut
        {
            get { return dateDebut; }
            
        }

        private string dateFin = "";
        public string DateFin
        {
            get { return dateFin; }

        }

        private string prix;
        public string Prix { get { return Fete.Prix.ToString(); } }

        public void OnGet()
        {
            this.dateAjd = DateTime.Now.ToString("o");
            string dateTemp = "";
            for (int i = 0; i < 16; i++)
            {
                dateTemp += dateAjd[i];
            }
            this.dateAjd = dateTemp;

            dateDebut = Fete.DebutFete.ToString("o");
            dateTemp = "";
            for (int i = 0; i < 16; i++)
            {
                dateTemp += dateDebut[i];
            }
            this.dateDebut = dateTemp;

            dateFin = Fete.FinFete.ToString("o");
            dateTemp = "";
            for (int i = 0; i < 16; i++)
            {
                dateTemp += dateFin[i];
            }
            this.dateFin = dateTemp;

        }

        public void OnPost()
        {
            string nomFete = Request.Form["_nom_fete"];
            string adresse = Request.Form["_adresse"];
            string gps = Request.Form["_gps"];
            string dateDebut = Request.Form["_dateDebut"];
            string dateFin = Request.Form["_dateFin"];
            string description = Request.Form["_description"];
            var prixInsert = Request.Form["_prix"];

            //Convertion des données
            DateTime dDebut = Convert.ToDateTime(dateDebut);
            DateTime dFin = Convert.ToDateTime(dateFin);

            int p = Convert.ToInt32(prixInsert);

            int result = DateTime.Compare(dDebut, dFin);
            //Si la date de fin est plus tôt que la date de début
            if (result > 0)
            {
                string dTemp = dateFin;
                dateFin = dateDebut;
                dateDebut = dTemp;
            }

            dDebut = Convert.ToDateTime(dateDebut);
            dFin = Convert.ToDateTime(dateFin);

            //Update de l'objet fete
            Fete.Nom = nomFete;
            Fete.Lieu = adresse;
            Fete.CoordonneesGPS = gps;
            Fete.DebutFete = dDebut;
            Fete.FinFete = dFin;
            Fete.Description = description;
            Fete.Prix = p;

            FeteManager.Update(Fete);
        }
    }
}
