using Jops.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jops.Context.Database
{
    public class JopsContext : DbContext
    {
        public JopsContext(DbContextOptions<JopsContext> opts) : base(opts)
        {

        }

        public DbSet<Advertisement> advertisements { get; set; }
       public DbSet<Company> companies {  get; set; }
    }
}
