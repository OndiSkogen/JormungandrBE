using JormungandrBE.Collections.SeasonEvent.DTO;

namespace JormungandrBE.Collections.Season.DTO
{
    public class SeasonDTO
    {
        public string Name { get; set; } = string.Empty;
        public string LeagueChampion { get; set; } = string.Empty;
        public string GroupStageWinner { get; set; } = string.Empty;
        public List<SeasonEventDTO> SeasonEvents { get; set; } = new List<SeasonEventDTO>();
    }
}
