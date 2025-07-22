namespace WalksAPI.Models.Domain.DTOs
{
    public class UpdateRegionRequestDTO
    {
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; } // Optional, can be null if not updating the image
    }
}
