using AutoMapper;
using Dotnet_Assessment.BAL;
using Dotnet_Assessment.DTO;
using Dotnet_Assessment.Models;
using Dotnet_Assessment.Utils;

namespace Dotnet_Assessment.Mappings
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, StockDto>()
                .ForMember(dest => dest.FormattedPrice, 
                        opt => opt.MapFrom(src => StockUtils.FormatPrice(src.Price)))
                .ForMember(dest => dest.CarName,
                        opt => opt.MapFrom(src => StockUtils.GetCarName(src.MakeYear, src.MakeName, src.ModelName)))
                .ForMember(dest => dest.IsValueForMoney, 
                        opt => opt.MapFrom(src => StockUtils.IsValueForMoney(src.Price, src.Km)));
        }
    }
}