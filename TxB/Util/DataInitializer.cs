using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using TxB.Data;

namespace TxB.Util;

public class DataInitializer
{
    private static string TXB_ADJ_FILE = @".\TxBAdjectives.txt";
    private static string TXB_NOUN_FILE = @".\TxBNouns.txt";
    
    public static void SeedTxBData(IdentityContext context)
    {
        context.Database.EnsureCreated();
        try
        {
            // Find an admin user: 
            var admin = context.Users.First();

            // Find TxB topic: 
            var txbTopic = context.Topics.First(x => x.TopicName == "TxB");

            var adjectives = File.ReadLines(TXB_ADJ_FILE);
            foreach (var adjective in adjectives)
            {
                var w = new Word();
                w.WordType = WordType.Adjective;
                w.Text = adjective;
                w.Topic = txbTopic;
                w.SubmittedBy = admin;
                w.Status = WordStatus.Published;
                context.Words.Add(w);
            }

            var nouns = File.ReadLines(TXB_NOUN_FILE);
            foreach (var noun in nouns)
            {
                var w = new Word();
                w.WordType = WordType.Noun;
                w.Text = noun;
                w.Topic = txbTopic;
                w.SubmittedBy = admin;
                w.Status = WordStatus.Published;
                context.Words.Add(w);
            }

            int saved = context.SaveChanges();
            
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Data seeding failed.", ex);
        }


    }
}