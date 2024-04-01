using JormungandrBE.Collections.EventResult.DTO;
using JormungandrBE.Database;

namespace JormungandrBE.DTO
{
    public class CreateEventDTO : ResponseBase
    {
        public DateTime Date { get; set; }
        public int EventNumber { get; set; }
        public string SeasonId { get; set; } = string.Empty;
        public List<EventResultDTO> EventResults { get; set; } = new List<EventResultDTO>();
    }
}
