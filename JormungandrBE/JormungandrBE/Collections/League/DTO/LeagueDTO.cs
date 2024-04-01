using JormungandrBE.Elements;

namespace JormungandrBE.Collections.League.DTO
{
    public class LeagueDTO
    {
        public string Format { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Preamble { get; set; } = string.Empty;
        public Ulist Prizes { get; set; } = new Ulist();
        public Ulist TieBreakers { get; set; } = new Ulist();
        public StatBox PointLeaders { get; set; } = new StatBox();
        public MetaGame.Models.MetaGame MetaGame { get; set; } = new MetaGame.Models.MetaGame();
    }
}
