using InfoMallWebService.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoMallWebService.Models
{
	public class ContactInformation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ContactId { get; set; }

		[Required]
		public string Message { get; set; }

		public bool ContactType { get; set; }

		[ForeignKey("UserId")]
		public ApplicationUser User { get; set; }
		public string UserId { get; set; }

	}
}