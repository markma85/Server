using AutoMapper;
using InnovateFuture.Api.Models.Requests;
using InnovateFuture.Application.Commands.Orders;

namespace InnovateFuture.Api.Profiles;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        // Mapping CreateOrderRequest to CreateOrderCommand
        CreateMap<CreateOrderRequest, CreateOrderCommand>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

        // Mapping CreateOrderRequest.CreateOrderItem to CreateOrderCommand.CreateOrderItem
        CreateMap<CreateOrderRequest.CreateOrderItem, CreateOrderCommand.CreateOrderItem>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));
            
    }
}