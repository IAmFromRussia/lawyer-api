using Lawyer_Api.Models.DTO;
using Lawyer_Api.Models.Entities;
using Lawyer_Api.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentController : Controller
{
	private readonly ILogger<DocumentController> _logger;
	private readonly IService<Document, DocumentDto> _service;


	public DocumentController(ILogger<DocumentController> logger,
		IService<Document, DocumentDto> service)
	{
		_logger = logger;
		_service = service;
	}

	[HttpPost("/uploadDocument")]
	[EndpointName("something")]
	public async Task<ActionResult> UploadDocumentTemplate([FromBody] DocumentDto documentDto)
	{
		try
		{
			if (!ModelState.IsValid)
				return BadRequest("Document name or body cannot be empty");

			await _service.SaveAsync(documentDto);
		}
		catch (Exception e)
		{
			_logger.LogError("Document saved error \n Name: {Name} \n Body: {Body} \n  {Message}", documentDto.Name,
				documentDto.Body, e.Message);
		}

		return Ok("Document saved successfully");
	}
}