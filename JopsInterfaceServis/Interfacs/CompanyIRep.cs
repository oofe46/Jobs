using Jops.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JopsInterfaceServis.Interfacs
{
    public class CompanyIRep
    {
        public Task<List<Company>> GetAll();
        public Task<Company> GetById(int id);
        public Task<List<Company>> Sarche(int id);
        public Task Creat(Company model);
        public Task Update(Company model);
        public Task Delete(Company model);
    }
}
