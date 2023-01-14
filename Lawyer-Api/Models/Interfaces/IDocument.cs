namespace Lawyer_Api.Models.Interfaces;

public interface IDocument : IWithId
{
	string Name { get; set; }
	string Body { get; set; }
}