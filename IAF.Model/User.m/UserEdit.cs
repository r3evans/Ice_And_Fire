using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Model.User.m
{
    public class UserEdit
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        //[Required]
        //public int UserRole {get; set;}
    }
}
