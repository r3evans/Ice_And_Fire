﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Data
{
   // public enum EstateType { Shack, }    //Stretch Goal
    public enum Status { Active, Pending, Withdrawn, Closed, Under_Siege}
    public class Estate
    {
        [Key]
        public int  EstateId { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }

        [ForeignKey("KingdomId")] //for annotation purposes
        public int KingdomId { get; set; }

        //public EstateType EstateType {get; set;}        //Stretch Goal

    }
}