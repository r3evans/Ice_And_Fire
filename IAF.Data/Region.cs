﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Data
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Kingdom> Kingdoms { get; set; }

    }
}
