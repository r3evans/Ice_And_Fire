using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Model.City.m
{
   public class CityEdit
    {
  
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string RegionId { get; set; }

        public int CityId { get; set; }
    }
}
