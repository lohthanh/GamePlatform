#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GamePlatform.Models;

public class UserGames
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int GameId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}