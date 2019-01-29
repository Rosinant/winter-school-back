using DataRecognition.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        { }
        public DbSet<Passport> Passports { get; set; }
    }
}
