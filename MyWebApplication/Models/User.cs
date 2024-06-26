using Microsoft.AspNetCore.Identity;

namespace MyWebApplication.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
