using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Models.Data
{
    public class Apppdbcontext:DbContext
    {
        public DbSet<Task1> Tasks { get; set; }
        public Apppdbcontext(DbContextOptions options):base(options) { }
      

    }
}
