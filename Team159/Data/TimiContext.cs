using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team159.Models;

namespace Team159.Data
{
    public class TimiContext : DbContext
    {
        public TimiContext(DbContextOptions<TimiContext> options) : base(options)
        {

        }

        public DbSet<Arm> Arms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
