using IAF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Model.Estate.m
{
    public class EstateEdit
    {
        public Guid EstateId { get; set; }
        public string Name { get; set; }
       // public Status Status { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
    }
}
