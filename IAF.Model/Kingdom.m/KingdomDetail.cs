using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Model.Kingdom.m
{
    public class KingdomDetail
    {
        //public Guid Id { get => string.IsNullOrEmpty(KingdomId) ? Guid.Empty : Guid.Parse(KingdomId); }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal AverageEstatePrice { get; set; }
        public string RegionName { get; set; }
        public int KingdomId { get; set; }
    }
}
