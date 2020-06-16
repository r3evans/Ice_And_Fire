using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAF.Data;

namespace IAF.Model.UserEstate.m
{
    public class UserEstateDetail
    {

        public int UserId { get; set; }
        public int EstateId { get; set; }
        public Data.Estate Estate { get; set; }
    }
}
