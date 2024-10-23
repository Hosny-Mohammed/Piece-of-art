using AutoMapper;
using PiecesOfArt_App.Models;
using PiecesOfArt_App.DTOs;

public class MappingProfile : Profile
{
    // sorry for using ai tool bcuz it was so hard to map the data from object to another
    public MappingProfile()
    {
        // Map from UserDTO to User (for creating a new User)
        CreateMap<UserDTO, User>()
            .ForMember(dest => dest.loyaltyCardId, opt => opt.Ignore()) // LoyaltyCardId will be set in the controller
            .ForMember(dest => dest.loyaltyCard, opt => opt.Ignore()) // LoyaltyCard will be set after mapping
            .ForMember(dest => dest.PieceOfArts, opt => opt.Ignore()); // PieceOfArts will be set after mapping

        // Map from User to UserDTO (for returning user data)
        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.LoyaltyCardName, opt => opt.MapFrom(src => src.loyaltyCard.Name))
            .ForMember(dest => dest.PieceOfArtsNames, opt => opt.MapFrom(src => src.PieceOfArts.Select(a => a.Title).ToList()));


        CreateMap<ArtDTO, Art>()
            .ForMember(dest => dest.user, opt => opt.Ignore()) // User will be set in the controller
            .ForMember(dest => dest.category, opt => opt.Ignore()); // Category will be set in the controller

        // Map from Art to ArtDTO (for returning Art data)
        CreateMap<Art, ArtDTO>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.category.Name));


        CreateMap<LoyaltyCardDTO, LoyaltyCard>();
        CreateMap<LoyaltyCard, LoyaltyCardDTO>();

        // Category Mappings
        CreateMap<CategoryDTO, Category>();
        CreateMap<Category, CategoryDTO>();

    }
}
