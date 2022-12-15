using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PreParty.Pages
{
    public class PageErreurModel : PageModel
    {
        private string message = "";
        public string Message
        {
            get { return message; } 
        }

        private string pageDest = "";

        public string PageDest
        {
            get { return pageDest; } 
        }
        public void OnGet()
        {
            if (HttpContext.Request.Query.ContainsKey("idMessage"))
            {
                //Récup le message
            }
            if (HttpContext.Request.Query.ContainsKey("pageDest"))
            {
                //Récup la page dest
            }
            this.message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\r\n";
            this.pageDest = "Index";
        }

        public void OnPost()
        {
            string p = Request.Form["_pageDest"];
            Response.Redirect(p);
        }
    }
}
