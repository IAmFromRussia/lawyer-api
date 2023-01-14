using Lawyer_Api.Models.Interfaces;

namespace Lawyer_Api.Models.Entities;

public class Document : IDocument
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Body { get; set; }
}