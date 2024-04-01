namespace JormungandrBE.Collections.EventResult.DTO
{
    public class EventResultDTO
    {
        public string EventId { get; set; } = string.Empty;
        public string PlayerId { get; set; } = string.Empty;
        public int Points { get; set; }
        public decimal OMW { get; set; }
        public decimal GW { get; set; }
        public decimal OGW { get; set; }
        public int Placement { get; set; }
        public string PlayerName { get; set; } = string.Empty;
    }
}
