using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TxB.Data;

public class Rating
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [System.ComponentModel.DataAnnotations.Required]
    public Proposition Proposition { get; set; }
    public ApplicationUser? User { get; set; }
    [Required] public int Score { get; set; } = 1;
    [Required]
    public DateTime Created { get; set; } = DateTime.Now;
}