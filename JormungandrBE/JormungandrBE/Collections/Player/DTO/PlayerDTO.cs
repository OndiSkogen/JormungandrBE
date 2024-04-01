namespace JormungandrBE.Collections.Player.DTO
{
    public class PlayerDTO
    {
        public string PlayerName { get; set; } = string.Empty;
        public int Events { get; set; } = 0;
        public int Points { get; set; } = 0;
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int Ties { get; set; } = 0;
    }
}
