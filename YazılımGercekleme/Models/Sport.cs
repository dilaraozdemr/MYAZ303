using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YazılımGercekleme.Models
{
    public class Sport
    {
        [Key]
        public int AthleteId { get; set; }
        [Column(TypeName = "nvarchar(12)")]
        public string AthleteNum { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string AthleteName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string AthleteSurname { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string TeamName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Country { get; set; }
        public DateTime Dates { get; set; }
    }
}
