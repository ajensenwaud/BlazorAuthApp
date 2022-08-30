using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TxB.Data;

public enum WordType
{
    Adjective = 1,
    Noun = 100,
    Other = 1000
}

public enum WordStatus
{
    Draft = 1,
    Published = 10, 
    Deleted = 100
}

public class Topic
{
    public long Id { get; set; } = -1;
    
    public string TopicName { get; set; }

    

    public IEnumerable<Word> Words { get; set; } = new List<Word>();
    
    public IEnumerable<Proposition> Propositions { get; set; } = new List<Proposition>();
}

public class Word
{
    [Key]
    public long Id { get; set; }
    [Required] public WordType WordType { get; set; } = WordType.Other;

    
    [Required]
    [MinLength(3, ErrorMessage = "Suggestions must be at least three characters")]
    public string Text { get; set; }
    [Required] public Topic Topic { get; set; }
    
    [Required]
    public ApplicationUser SubmittedBy { get; set; }

    [Required] public WordStatus Status { get; set; } = WordStatus.Draft;
}