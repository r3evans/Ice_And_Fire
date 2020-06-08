using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Data
{
    public class Region
    {
        public Guid OwnerId { get; set; }

        [Key]
        public int RegionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Kingdom> Kingdoms { get; set; }

       // public int KingdomId { get; set; }
    }
}
