using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Metier;

namespace PreParty.Pages
{
    public class disconnectModel : PageModel
    {
        public void OnGet()
        {
            UtilisateurLogin.Instance.Disconnect();
            Response.Redirect("Index");
        }
    }
}
