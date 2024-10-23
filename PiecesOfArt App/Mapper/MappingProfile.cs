using AutoMapper;
using PiecesOfArt_App.Models;
using PiecesOfArt_App.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.LoyaltyCardName, opt => opt.MapFrom(src => src.loyaltyCard.Name))
            .ForMember(dest => dest.PieceOfArtsNames, opt => opt.MapFrom(src => src.PieceOfArts.
            Select(art => new {art.Title, art.category.Name}).ToList()));

        CreateMap<UserDTO, UpdateUserRequest>();
    }
}
