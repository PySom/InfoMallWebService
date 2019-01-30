using Microsoft.AspNetCore.Identity;

namespace InfoMallWebService.Models
{
	public class ApplicationUser : IdentityUser
	{
		public bool UserLikesMail { get; set; }
	}
}
