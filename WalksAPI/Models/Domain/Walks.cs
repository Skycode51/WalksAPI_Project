﻿namespace WalksAPI.Models.Domain
{
    public class Walks
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        //Navigation Properties
        public Difficulty Difficulty { get; set; }
        public Regions Region { get; set; }
    }
}
