using JormungandrBE.Collections.EventResult.DTO;

namespace JormungandrBE.Collections.SeasonEvent.DTO
{
    public class SeasonEventDTO
    {
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int EventNumber { get; set; }
        public List<EventResultDTO> EventResults { get; set; } = new List<EventResultDTO>();
    }
}
