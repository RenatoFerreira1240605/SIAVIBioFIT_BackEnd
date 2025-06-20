using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SIAVIBioFITBackEnd.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
        public int Score { get; set; } = 0;
        public int LoginCount { get; set; } = 1;
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public List<Session> Sessions { get; set; } = new();
        public byte[]? FaceImage { get; set; }
    }

}
