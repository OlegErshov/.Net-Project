using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;

namespace WebClient.Pages.Users
{
    public class UserModel : PageModel
    {
        private Student user { get; set; }
        public void OnGet()
        {
        }
    }
}
