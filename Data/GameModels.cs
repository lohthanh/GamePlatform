using System.Text.Json.Serialization;

public record class Games(
    [property: JsonPropertyName("results")] GameResults[] Results,
    [property: JsonPropertyName("next")] string Next
);

public record class GameResults(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("background_image")] string Image,
    [property: JsonPropertyName("genres")] GetGenre[] Genre
);

public record class GetGenre(
    [property: JsonPropertyName("name")] string Name
);

public record class Game(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("released")] string ReleasedDate,
    [property: JsonPropertyName("background_image")] string Image,
    [property: JsonPropertyName("platforms")] GetPlatformsSet[] Platforms,
    [property: JsonPropertyName("genres")] GetGenre[] Genre,
    [property: JsonPropertyName("website")] string Website
);

public record class GetPlatformsSet(
    [property: JsonPropertyName("platform")] GetPlatform Platform
);

public record class GetPlatform(
    [property: JsonPropertyName("name")] string Name
);