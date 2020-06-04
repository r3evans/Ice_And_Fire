using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAF.Data;
using IAF.Model.Region.m;

namespace IAF.Model.Kingdom.m
{
    public class KingdomCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int RegionId { get; set; }
       
    }
}
