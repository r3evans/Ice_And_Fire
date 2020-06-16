﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Data
{
    public enum EstateType { Castle, Manor, Cottage, Hut }    //Stretch Goal
    public enum Status { Active, Pending, Withdrawn, Closed, Under_Siege }
    public class Estate
    {
        public Guid OwnerId { get; set; }
        [Key]
        public int EstateId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Address { get; set; }

        public EstateType EstateType { get; set; }
       

        
        public int CityId { get; set; }
        public City City { get; set; }

        //public EstateType EstateType {get; set;}        //Stretch Goal

    }
}
