using System.ComponentModel.DataAnnotations.Schema;

namespace TASİNMAZ.Entities.Concrete
{
    public class Neigborhood
    {
        public int Id { get; set; }
        public string NeigborhoodName { get; set; }
        [ForeignKey("DistrictId")]
        public int DistrictId { get; set; }
        public virtual District District {get; set;}
    }
}
