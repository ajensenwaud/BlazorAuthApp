using System.ComponentModel.DataAnnotations;
using TxB.Shared.Components;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace TxB.Data;

public class Proposition
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public Word? Adjective0 { get; set; } 
    public Word? Adjective1 { get; set; } 
    public Word? Adjective2 { get; set; }
    public Word? Noun { get; set; }
    [Required] public DateTime Created { get; set; }
    [Required] public Topic Topic { get; set; }

    public override string ToString()
    {
        var ti = CultureInfo.CurrentCulture.TextInfo;
        return ti.ToTitleCase($"{Adjective0.Text} {Adjective1.Text} {Adjective2.Text} {Noun.Text}");
    }
}