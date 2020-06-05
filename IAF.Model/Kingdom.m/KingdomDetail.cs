using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Model.Kingdom.m
{
    public class KingdomDetail
    {
        public Guid KingdomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal AverageEstatePrice { get; set; }
        public int RegionId { get; set; }
    }
}
