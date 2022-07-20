using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
}