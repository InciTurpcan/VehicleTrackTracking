using AutoMapper;
using Domain.DataTransferObjects;
using Domain.Entities;
using Dtos.CarDtos;

namespace Vechicle_Track_WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarDtoForUpdate, Car>();
            CreateMap<ResultCarWithPartsDto, Car>().ReverseMap();
            CreateMap<CarDtoForInsertion, Car>();
            CreateMap<PartDtoForInsertion, Part>();
            CreateMap<PartDtoForUpdate, Part>();
            CreateMap<PartCategoryDtoForInsertion, PartCategory>();
            CreateMap<PartCategoryDtoForUpdate, PartCategory>();
        }
    }
}
