using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRecognition.Domain.Model;
using Domain.Interfaces;

namespace Domain.Logic
{
    public class PassportRepository : IRepository<Passport>
    {
        private DataContext db;

        public PassportRepository()
        {
            this.db = new DataContext();
        }

        public void Create(Passport passport)
        {
            db.Passports.Add(passport);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
