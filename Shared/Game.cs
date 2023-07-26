using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamePlatform.Shared
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string DeveloperName { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; }
        
        [StringLength(255)]
        public string CoverImagePath { get; set; }

        public ICollection<PlatformForGame> GamePlatforms { get; set; }
        public ICollection<GameGenre> GameGenres { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
