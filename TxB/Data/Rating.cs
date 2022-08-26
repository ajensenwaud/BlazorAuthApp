using Microsoft.Build.Framework;

namespace TxB.Data;

public class Rating
{
    public long Id { get; set; }
    [Required]
    public Proposition Proposition { get; set; }
    public ApplicationUser? User { get; set; }
    [Required] public int Score { get; set; } = 1;
    [Required]
    public DateTime Created { get; set; } = DateTime.Now;
}