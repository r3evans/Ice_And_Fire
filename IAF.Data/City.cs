using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Data
{
    public class City
    {
        public Guid OwnerId { get; set; }

        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int RegionId { get; set; }
        public Region Region { get; set; }
       
        public ICollection<Estate> Estates { get; set; }
    }
}
