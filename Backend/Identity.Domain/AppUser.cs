using Microsoft.AspNetCore.Identity;

namespace Identity.Domain;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
}