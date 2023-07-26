namespace GamePlatform.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform
                {
                    Id = 1,
                    Name = "PC"
                },
                new Platform
                {
                    Id = 2,
                    Name = "Playstation 5"
                },
                new Platform
                {
                    Id = 3,
                    Name = "Xbox One"
                },
                new Platform
                {
                    Id = 4,
                    Name = "Nintendo Switch"
                },
                new Platform
                {
                    Id = 5,
                    Name = "Android"
                },
                new Platform
                {
                    Id = 6,
                    Name = "iOS"
                },
                new Platform
                {
                    Id = 7,
                    Name = "MacOS"
                },
                new Platform
                {
                    Id = 8,
                    Name = "Nintendo 3DS"
                },
                new Platform
                {
                    Id = 9,
                    Name = "Nintendo DS"
                },
                             new Platform
                {
                    Id = 10,
                    Name = "Playstation 4"
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Adventure"
                },
                new Genre
                {
                    Id = 3,
                    Name = "RPG"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Strategy"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Simulation"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Sports"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Racing"
                },
                new Genre
                {
                    Id = 8,
                    Name = "Puzzle"
                },
                new Genre
                {
                    Id = 9,
                    Name = "Shooter"
                },
                new Genre
                {
                    Id = 10,
                    Name = "Fighting"
                },
                new Genre
                {
                    Id = 11,
                    Name = "Family"
                },
                new Genre
                {
                    Id = 12,
                    Name = "Board Games"
                },
                new Genre
                {
                    Id = 13,
                    Name = "Educational"
                },
                new Genre
                {
                    Id = 14,
                    Name = "Card"
                },
                new Genre
                {
                    Id = 15,
                    Name = "Casual"
                },
                new Genre
                {
                    Id = 16,
                    Name = "Indie"
                },
                new Genre
                {
                    Id = 17,
                    Name = "Massively Multiplayer"
                }
            );
        }    
        public DbSet<SuperHero> SuperHeroes { get; set; }

        public DbSet<Comic> Comics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PlatformForGame> GamePlatforms { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
