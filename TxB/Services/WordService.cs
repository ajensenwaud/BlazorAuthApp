using Microsoft.EntityFrameworkCore;
using TxB.Data;

namespace TxB.Services;

public class WordService
{
    private readonly IdentityContext _identityContext;

    public WordService(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public IEnumerable<Word> GetWordsNot(WordStatus status)
    {
        return _identityContext.Words.Where(x => x.Status != status).Include(x => x.SubmittedBy).ToList();
    }

    public Topic FindTopic(string topic)
    {
        var topics = _identityContext.Topics.Where(t => t.TopicName == topic.Trim());
        return topics.Count() == 0 ? throw new ArgumentException($"Could not find topic '{topic}") : topics.ToList()[0];

    }
    
    
    public IEnumerable<Word> GetWords()
    {
        return _identityContext.Words.Include(x => x.SubmittedBy).OrderBy(x => x.Status).ThenBy(x => x.Id).ToList();
    }

    public Word GetWord(long id)
    {
        return _identityContext.Words.Include(x => x.SubmittedBy).First(x => x.Id == id);
    }

    public Proposition GenerateProposition()
    {
        Proposition prop = new Proposition();
        
        // TxB topic: 
        var txbTopic = _identityContext.Topics.First(x => x.TopicName == "TxB");
        // Select 3 random adjectives
        var randomAdjectives = _identityContext.Words
            .Where(x => x.Status == WordStatus.Published && x.WordType == WordType.Adjective)
            .AsEnumerable()
            .OrderBy(r => Guid.NewGuid())
            .Take(3).ToArray();
        var randomNouns = _identityContext.Words
            .Where(w => w.Status == WordStatus.Published && w.WordType == WordType.Noun)
            .AsEnumerable()
            .OrderBy(r => Guid.NewGuid())
            .Take(1).ToArray();

        prop.Adjective0 = randomAdjectives[0];
        prop.Adjective1 = randomAdjectives[1];
        prop.Adjective2 = randomAdjectives[2];
        prop.Noun = randomNouns[0];
        prop.Topic = txbTopic;
        _identityContext.Propositions.Add(prop);
        _identityContext.SaveChanges();
        return prop;
    }

    public int SaveWord(Word w)
    {
        _identityContext.Database.BeginTransaction();
        _identityContext.Words.Add(w);
        var c = _identityContext.SaveChanges();
        _identityContext.Database.CommitTransaction();
        return c;
    }
    
    
    public int UpdateWord(Word w)
    {
        _identityContext.Database.BeginTransaction();
        _identityContext.Words.Update(w);
        var c = _identityContext.SaveChanges();
        _identityContext.Database.CommitTransaction();
        return c;
    }


    public void SetStatus(long id, WordStatus stat)
    {
        var w = _identityContext.Words.First(x => x.Id == id);
        w.Status = stat;
        UpdateWord(w);
    }
}