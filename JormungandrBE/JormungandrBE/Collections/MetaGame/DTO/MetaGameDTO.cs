namespace JormungandrBE.Collections.MetaGame.DTO
{
    public class MetaGameDTO
    {
        public SeasonEvent.Models.SeasonEvent SeasonEvent { get; set; } = new SeasonEvent.Models.SeasonEvent();
        public List<Deck.Models.Deck> Decks { get; set; } = new List<Deck.Models.Deck>();
    }
}
