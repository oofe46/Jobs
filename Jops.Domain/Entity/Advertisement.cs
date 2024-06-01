using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jops.Domain.Entity
{
    public class Advertisement
    {

        public int Id { get; set; }
        public string Discerioton{ get; set; }

        public string Location { get; set; }

        public int Salary { get; set; }

        public int Hours { get; set; }

        public bool Valid { get; set; }

        public string Approved { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

    }
}
