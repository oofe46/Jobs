 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Jops.Domain.Entity
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Locaton { get; set; }
         
        public bool State { get; set;}  
        public string Specialty { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
     }
}
