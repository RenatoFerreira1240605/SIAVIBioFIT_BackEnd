namespace SIAVIBioFITBackEnd.Models
{
    public class RepetitionData
    {
        public string Exercise { get; set; }
        public int Repetitions { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
