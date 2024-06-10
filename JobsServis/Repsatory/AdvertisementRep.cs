using Jops.Context.Database;
using Jops.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsServis.Repsatory
{
    public class AdvertisementRep
    {
        private readonly JopsContext db;
        public AdvertisementRep(JopsContext db) 
        {
            this.db = db;

        }

        public async Task Creat(Advertisement model)
        {
            var data = db.advertisements.Where(a => a.Id == model.Id);
            //var data = db.Rooms.FirstOrDefault(a => a.Id == model.Id);

            if (data == null)
            {
                db.advertisements.Add(model);
                db.SaveChanges();

            }
        }

        public async Task Delete(Advertisement model)
        {
            var data = db.advertisements.FirstOrDefault(a => a.Id == model.Id);
            if (data == null)
            {
                db.advertisements.Remove(model);
                db.SaveChanges();
            }
        }


        public async Task<List<Advertisement>> GetAll()
        {

            return [.. await db.advertisements.ToListAsync()];
        }

        public async Task<Advertisement?> GetById(int id)
        {
            var data = db.advertisements.FirstOrDefault(a => a.Id == id);
            return data;
        }



        public async Task<List<Advertisement>> Sarche(int id)
        {
            var data = db.advertisements.Where(a => a.Id == id);
            return await (Task<List<Advertisement>>)data;
        }

        public async Task Update(Advertisement model)
        {
            var data = db.advertisements.FirstOrDefault(db => db.Id == model.Id);
            if (data == null)
            {
                data.Approved = model.Approved;
                data.Hours = model.Hours;
                data.Location = model.Location;
                data.Valid = model.Valid;
                data.Approved = model.Approved;
                db.SaveChanges();

            }
        }
    }
}
