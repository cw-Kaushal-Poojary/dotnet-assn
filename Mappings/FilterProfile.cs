using AutoMapper;
using Dotnet_Assessment.DTO;
using Dotnet_Assessment.Models;

namespace Dotnet_Assessment.Mappings
{
    public class FilterProfile : Profile
    {
        public FilterProfile()
        {
            CreateMap<RequestDto, Filter>();
        }
    }
}