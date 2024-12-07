using AutoMapper;
using InnovateFuture.Application.DTOs;
using InnovateFuture.Application.Orders.Commands;
using InnovateFuture.Domain.Entities;

namespace InnovateFuture.Application.Profiles;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        // Mapping CreateOrderCommand to Order entity
        CreateMap<CreateOrderCommand, Order>()
            .ConstructUsing(request => new Order(request.CustomerName)) // Use constructor for CustomerName
            .ForMember(dest => dest.Items, opt => opt.Ignore()) // Ignore Items for manual mapping
            .AfterMap((src, dest) =>
            {
                // Manually map Items after constructing Order
                foreach (var item in src.Items)
                {
                    dest.AddItem(item.ProductName, item.Quantity, item.UnitPrice);
                }
            });
        
        // Mapping Order entity to OrderDto
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
    }
}