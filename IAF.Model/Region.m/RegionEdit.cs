using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Model.Region.m
{
    public class RegionEdit
    {
        public Guid Id { get => string.IsNullOrEmpty(RegionId)? Guid.Empty: Guid.Parse(RegionId); }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegionId { get; set; }
    }
}
