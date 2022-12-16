using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Notification
    {
        public string Notif { get; set; }
        public bool Lu { get; set; }

        public Notification(string notif, bool lu)
        {
            Notif = notif;
            Lu = lu;
        }
    }
}
