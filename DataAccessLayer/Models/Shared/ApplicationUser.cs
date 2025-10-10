using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models.Shared
{
    public class ApplicationUser : IdentityUser
    {
        public string FristName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
