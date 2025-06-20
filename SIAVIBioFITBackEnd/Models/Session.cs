using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIAVIBioFITBackEnd.Models
{
    [Table("sessions")]
    public class Session
    {
        [Key]
        public int Id { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        [ForeignKey("UserEmail")]
        public User? User { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndedAt { get; set; }

        public List<ExerciseLog> Logs { get; set; } = new();
    }
}