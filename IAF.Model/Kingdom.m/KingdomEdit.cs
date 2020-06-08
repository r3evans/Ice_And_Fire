using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Model.Kingdom.m
{
   public class KingdomEdit
    {
       // public Guid Id { get => string.IsNullOrEmpty(KingdomId) ? Guid.Empty : Guid.Parse(KingdomId); }
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string RegionId { get; set; }

        public int KingdomId { get; set; }
    }
}
