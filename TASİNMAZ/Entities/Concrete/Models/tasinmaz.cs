using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TASİNMAZ.Entities.Concrete.Models
{
    public class tasinmaz
    {
        public int Id { get; set; }

        [ForeignKey("NeigborhoodId")]
        public int NeigborhoodId { get; set; }
        public virtual Neigborhood Neigborhood { get; set; }
        public string Island { get; set; }

        public string Parcel { get; set; }

        public string Quality { get; set; }

        public string CoordinateInformation { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; } // User sınıfına referans
    }
}

