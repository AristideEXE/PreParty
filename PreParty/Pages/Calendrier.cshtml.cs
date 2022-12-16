using Metier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using NuGet.Protocol;
using System.Runtime.Intrinsics.Arm;
namespace PreParty.Pages
{
    public class CalendrierModel : PageModel
    {
        private DateTime dateAjd ;

        public DateTime DateAjd => dateAjd;

        private int mois = 0;
        public int Mois => mois;

        private string annee = "";
        public string Annee => annee;

        private List<int> moisListe = new List<int>() {31,28,31,30,31,30,31,31,30,31,30,31 };

        private List<int> jours = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
        public List<int> Jours => jours; 

        public List<int> MoisListe => moisListe;

        private Dictionary<string, int> jjjj = new Dictionary<string, int>() { { "Monday", 1 },
            { "Tuesday", 2 },{"Wednesday",3 },{"Thursday",4 },{"Friday",5 },{"Saturday",6 },{"Sunday",7 } };

        private List<string> jjjj1 = new List<string>() { "lundi" , "mardi", "mercredi" ,
        "jeudi","vendredi","samedi","dimanche"};


        public List<string> JJJJ1 => jjjj1;
        private List<int> djmd = new List<int>();

        public List<int> DJMD => djmd;


        private List<Fete> fetes = new List<Fete>();

        private Dictionary<List<DateTime>, List<string>> feteschargesI = new Dictionary<List<DateTime>, List<string>>();

        public Dictionary<List<DateTime>, List<string>> FeteschargesI => feteschargesI;

        private Dictionary<List<DateTime>, List<string>> feteschargesO = new Dictionary<List<DateTime>, List<string>>();

        public Dictionary<List<DateTime>, List<string>> FeteschargesO => feteschargesO;

        public List<Fete> Fetes => fetes; 

        private int jourStart;

        public int JourStart => jourStart;

        private int jourFin;

        public int JourFin => jourFin;

        private string moisE; 

        public string MoisE => moisE;

        public void OnLoad()
        {
            Console.WriteLine("test");
        }

        public void OnGet()
        {
            if (HttpContext.Request.Query.ContainsKey("date"))
            {
                string brut = HttpContext.Request.Query["date"].ToString();
                this.dateAjd = DateTime.Parse(brut).Date;
            }
            else
            {
                this.dateAjd = DateTime.Now;
            }
               
            this.mois = dateAjd.Month;
            this.moisE = dateAjd.ToString("MMMM");
            this.annee = dateAjd.ToString("yyyy");
            fetes = FeteManager.ReadAll();
            chargeFete();
            if (DateTime.IsLeapYear(Int32.Parse(annee)))
            {
                moisListe[1] = 29;
            }
            DateTime datepremier = new DateTime(dateAjd.Year, dateAjd.Month, 1);
            this.jourStart = jjjj[datepremier.DayOfWeek.ToString()] ;
            this.jourFin = jourStart + mois - 1; 
            for(int i = 0; i < jourStart - 1; i++)
            {
                djmd.Add(MoisListe[(((Mois - 2) % 7) + 7) % 7] - (JourStart - 2 - i));
            }
            
            
        }

        private void chargeFete()
        {
            foreach(Fete fete in fetes)
            {
                if(fete.Organisateur.IdUtilisateur.Equals(UtilisateurLogin.Instance.GetUtilisateur().IdUtilisateur))
                {
                    List<DateTime> list = new List<DateTime>() { fete.DebutFete.Date , fete.FinFete.Date };
                    feteschargesO.Add(list,new List<string>(){ fete.Nom,fete.IdFete.ToString()});
                }
                else if (fete.Invites.Contains(UtilisateurLogin.Instance.GetUtilisateur()))
                {
                    List<DateTime> list = new List<DateTime>() { fete.DebutFete.Date, fete.FinFete.Date };
                    feteschargesI.Add(list, new List<string>() { fete.Nom, fete.IdFete.ToString() });
                }

            }
        }

        public bool estDans(DateTime debut, DateTime fin, DateTime encours)
        {
            if(DateTime.Compare(debut, encours) <= 0 && DateTime.Compare(fin,encours)>= 0)
            {
                return true;
            }
            return false;
             
        }


        public void OnPost()
        {
            if (Request.Form.ContainsKey("submitAvancer"))
            {
                DateTime add1;
                if (HttpContext.Request.Query.ContainsKey("date"))
                {
                    string brut = HttpContext.Request.Query["date"].ToString();
                    add1 = DateTime.Parse(brut).Date;
                    add1 = add1.AddMonths(1);
                }
                else {
                    add1 = DateTime.Now.Date;
                    add1 = add1.AddMonths(1);
                }
                string add = add1.ToString("yyyy/MM/dd");
                Response.Redirect("Calendrier?date=" + add);
            }
            if (Request.Form.ContainsKey("submitReculer"))
            {
                DateTime add1;
                if (HttpContext.Request.Query.ContainsKey("date"))
                {
                    string brut = HttpContext.Request.Query["date"].ToString();
                    add1 = DateTime.Parse(brut).Date;
                    add1 = add1.AddMonths(-1);
                }
                else
                {
                    add1 = DateTime.Now.Date;
                    add1 = add1.AddMonths(-1);
                }
                string add = add1.ToString("yyyy/MM/dd");
                Response.Redirect("Calendrier?date=" + add);
            }

        }
    }
}
