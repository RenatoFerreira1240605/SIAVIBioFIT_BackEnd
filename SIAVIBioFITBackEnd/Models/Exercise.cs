using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIAVIBioFITBackEnd.Models
{
    [Table("exercises")]
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MinRepetitions { get; set; } = 5;
    }
}