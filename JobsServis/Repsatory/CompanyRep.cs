using Jops.Context.Database;
using Jops.Domain.Entity;
using JopsInterfaceServis.Interfacs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsServis.Repsatory
{
    public class CompanyRep : CompanyIRep
    {
        private readonly JopsContext db;
        public CompanyRep(JopsContext db)
        {
            this.db = db;

        }
        public async Task Creat(Company model)
        {
            var data = db.companies.Where(a => a.Id == model.Id);
            //var data = db.Rooms.FirstOrDefault(a => a.Id == model.Id);

            if (data == null)
            {
                db.companies.Add(model);
                db.SaveChanges();

            }
        }

        public async Task Delete(Company model)
        {
            var data = db.companies.FirstOrDefault(a => a.Id == model.Id);
            if (data == null)
            {
                db.companies.Remove(model);
                db.SaveChanges();
            }
        }


        public async Task<List<Company>> GetAll()
        {

            return [.. await db.companies.ToListAsync()];
        }

        public async Task<Company?> GetById(int id)
        {
            var data = db.companies.FirstOrDefault(a => a.Id == id);
            return data;
        }



        public async Task<List<Company>> Sarche(int id)
        {
            var data = db.companies.Where(a => a.Id == id);
            return await (Task<List<Company>>)data;
        }

        public async Task Update(Company model)
        {
            var data = db.companies.FirstOrDefault(db => db.Id == model.Id);
            if (data == null)
            {
                data.Email = model.Email;
                data.Name = model.Name;
                data.Locaton = model.Locaton;
                data.Phone = model.Phone;
                data.Specialty = model.Specialty;
                data.State = model.State;


                db.SaveChanges();

            }
        }
    }
}
