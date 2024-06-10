using Jops.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JopsInterfaceServis.Interfacs
{
    public class AdvertisementIRep
    {
        public Task<List<Advertisement>> GetAll();
        public Task<Advertisement> GetById(int id);
        public Task<List<Advertisement>> Sarche(int id);
        public Task Creat(Advertisement model);
        public Task Update(Advertisement model);
        public Task Delete(Advertisement model);
    }
}
