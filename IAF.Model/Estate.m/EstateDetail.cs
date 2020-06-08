using IAF.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Model.Estate.m
{
   public  class EstateDetail
    {
       //public Guid Id { get => string.IsNullOrEmpty(EstateId) ? Guid.Empty : Guid.Parse(EstateId); }
        [Required]
        public string Name { get; set; }
       // public Status Status { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public int EstateId { get; set; }

        [Required]
        public int KingdomId { get; set; }
    }
}
