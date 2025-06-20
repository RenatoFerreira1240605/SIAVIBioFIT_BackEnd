using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIAVIBioFITBackEnd.Models
{
    [Table("exerciselogs")]
    public class ExerciseLog
    {
        [Key]
        public int Id { get; set; }

        public int SessionId { get; set; }
        [ForeignKey("SessionId")]
        public Session? Session { get; set; }

        public int ExerciseId { get; set; }
        [ForeignKey("ExerciseId")]
        public Exercise? Exercise { get; set; }

        public int RepetitionsCompleted { get; set; }
        public bool Success { get; set; }
        public DateTime LoggedAt { get; set; } = DateTime.UtcNow;
    }
}