using AutoMapper;
using WalksAPI.Models.Domain;
using WalksAPI.Models.Domain.DTOs;

namespace WalksAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
         //Constructor
         public AutoMapperProfiles()
         { 
            // Create a mapping between the Domain model and the DTO
            // CreateMap : Specifies the source and destination types for mapping
           CreateMap<Regions, RegionsDTO>().ReverseMap(); // This will create a reverse mapping from DTO to Domain model
           CreateMap<AddRegionRequestDTO, Regions>().ReverseMap();
           CreateMap<UpdateRegionRequestDTO, Regions>().ReverseMap();
        
         }
    }
}
