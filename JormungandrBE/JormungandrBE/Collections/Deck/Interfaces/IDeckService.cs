using System.Reflection;

namespace JormungandrBE.Collections.Deck.Interfaces
{
    public interface IDeckService
    {
        Models.Deck CreateDeck(Models.Deck deck);
        Models.Deck GetDeck(string name);
        List<Models.Deck> GetDecks();
        bool UpdateDeck(string name, Models.Deck deckIn);
        bool DeleteDeck(string name);
    }
}
