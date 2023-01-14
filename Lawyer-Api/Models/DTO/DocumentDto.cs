using System.ComponentModel.DataAnnotations;

namespace Lawyer_Api.Models.DTO;

public class DocumentDto
{
	[Required]
	public string Name { get; set; }

	[Required]
	public string Body { get; set; }
}