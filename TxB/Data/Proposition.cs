using System.ComponentModel.DataAnnotations;
using TxB.Shared.Components;
using System.Globalization;

namespace TxB.Data;

public class Proposition
{
    public long Id { get; set; }
    [Required] public Word Adjective0 { get; set; } 
    [Required] public Word Adjective1 { get; set; } 
    [Required] public Word Adjective2 { get; set; }
    [Required] public Word Noun { get; set; }
    [Required] public DateTime Created { get; set; }
    [Required] public Topic Topic { get; set; }

    public override string ToString()
    {
        var ti = CultureInfo.CurrentCulture.TextInfo;
        return ti.ToTitleCase($"{Adjective0.Text} {Adjective1.Text} {Adjective2.Text} {Noun.Text}");
    }
}