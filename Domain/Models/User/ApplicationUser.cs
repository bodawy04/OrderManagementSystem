using Domain.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models.IdentityModule;

public class ApplicationUser : IdentityUser
{
   public Customer? Customer { get; set; }
}
