using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Data
{
    public class UserEstate
    {
        public Guid OwnerId { get; set; }

        public int EstateId { get; set; }
        public Estate Estate { get; set; }

        [Key]
        public int UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
