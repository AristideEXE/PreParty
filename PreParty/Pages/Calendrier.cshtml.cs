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
        private string dateAjd = "";

        public string DateAjd => dateAjd;

        private int mois = 0;
        public int Mois => mois;

        private string annee = "";
        public string Annee => annee;

        private List<int> moisListe = new List<int>() {31,28,31,30,31,30,31,31,30,31,30,31 };

        private List<int> jours = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
        public List<int> Jours => jours; 

        public List<int> MoisListe => moisListe;

        private Dictionary<string, int> jjjj = new Dictionary<string, int>() { { "lundi", 1 },
            { "mardi", 2 },{"mercredi",3 },{"jeudi",4 },{"vendredi",5 },{"samedi",6 },{"dimanche",7 } };

        private List<string> jjjj1 = new List<string>() { "lundi" , "mardi", "mercredi" ,
        "jeudi","vendredi","samedi","dimanche"};


        public List<string> JJJJ1 => jjjj1;
        private List<int> djmd = new List<int>();

        public List<int> DJMD => djmd;


        private List<Fete> fetes = new List<Fete>();

        private Dictionary<List<DateTime>, string> feteschargesI = new Dictionary<List<DateTime>, string>();

        public Dictionary<List<DateTime>, string> FeteschargesI => feteschargesI;

        private Dictionary<List<DateTime>, string> feteschargesO = new Dictionary<List<DateTime>, string>();

        public Dictionary<List<DateTime>, string> FeteschargesO => feteschargesO;

        public List<Fete> Fetes => fetes; 

        private int jourStart;

        public int JourStart => jourStart;

        private int jourFin;

        public int JourFin => jourFin;

        

        public void OnGet()
        {
            this.dateAjd = DateTime.Now.ToString("dd/mm/yyyy");
            this.mois = Int32.Parse(DateTime.Now.ToString("MM"));
            this.annee = DateTime.Now.ToString("yyyy");
            fetes = FeteManager.ReadAll();
            chargeFete();
            if (DateTime.IsLeapYear(Int32.Parse(annee)))
            {
                moisListe[1] = 29;
            }
            this.jourStart = jjjj[jjjj1[jjjj[DateTime.Now.ToString("dddd")]-((Int32.Parse(DateTime.Now.ToString("dd")) % 7) - 1)-1]] ;
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
                    feteschargesO.Add(list, fete.Nom);
                }
                else if (fete.Invites.Contains(UtilisateurLogin.Instance.GetUtilisateur()))
                {
                    List<DateTime> list = new List<DateTime>() { fete.DebutFete.Date, fete.FinFete.Date };
                    feteschargesI.Add(list, fete.Nom);
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
    }
}
