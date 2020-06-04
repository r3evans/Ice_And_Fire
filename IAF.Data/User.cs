using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Data
{
   public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

       // [ForeignKey("RoleId")]             //Stretch Goal to add these at a later date
       // public int Role { get; set;}

       // public virtual List<UserEstate>Favorites { get; set; }
    }
}
