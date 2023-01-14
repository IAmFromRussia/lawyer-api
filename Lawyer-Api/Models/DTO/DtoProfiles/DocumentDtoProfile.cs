using AutoMapper;
using Lawyer_Api.Models.Entities;

namespace Lawyer_Api.Models.DTO.DtoProfiles;

public class DocumentDtoProfile : Profile
{
	public DocumentDtoProfile()
	{
		CreateMap<Document, DocumentDto>()
			.ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name))
			.ForMember(destination => destination.Body, opt => opt.MapFrom(source => source.Body))
			.ReverseMap()
			.ForMember(destination => destination.Id, opt => opt.Ignore());
	}
}