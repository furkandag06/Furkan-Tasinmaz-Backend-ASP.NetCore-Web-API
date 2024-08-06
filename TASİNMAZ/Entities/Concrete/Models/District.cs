using System.ComponentModel.DataAnnotations.Schema;

namespace TASİNMAZ.Entities.Concrete
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
    
}
