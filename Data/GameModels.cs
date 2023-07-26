using System.Text.Json.Serialization;

public record class Games(
    [property: JsonPropertyName("results")] GameResults[] Results,
    [property: JsonPropertyName("next")] string Next
);

public record class GameResults(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("background_image")] string Image,
    [property: JsonPropertyName("genres")] GetGenre[] Genre
);

public record class GetGenre(
    [property: JsonPropertyName("name")] string Name
);
