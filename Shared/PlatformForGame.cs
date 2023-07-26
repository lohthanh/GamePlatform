using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamePlatform.Shared
{
    public class PlatformForGame
    {
        [Key]
        public int Id { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
