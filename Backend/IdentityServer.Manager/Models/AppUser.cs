using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Manager.Models;

public class AppUser : IdentityUser
{
    public string? DisplayName { get; set; }
}
