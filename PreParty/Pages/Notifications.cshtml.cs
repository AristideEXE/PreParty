using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Metier;

namespace PreParty.Pages
{
    public class NotificationsModel : PageModel
    {
        private List<Notification> notifications = new List<Notification>();
        public List<Notification> Notifications
        {
            get => notifications;
        }

        public void OnGet()
        {
            if (UtilisateurLogin.Instance.IsConnected)
            {
                notifications = UtilisateurManager.GetAllNotifications(UtilisateurLogin.Instance.GetUtilisateur().IdUtilisateur);
                UtilisateurManager.ReadAllNotifications(UtilisateurLogin.Instance.GetUtilisateur().IdUtilisateur);
            }
            else
            {
                Response.Redirect("Index");
            }
        }
    }
}
