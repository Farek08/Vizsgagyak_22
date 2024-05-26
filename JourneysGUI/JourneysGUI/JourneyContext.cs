using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneysGUI
{
    class JourneyContext : DbContext
    {
        public DbSet<JourneyModel> Journey { get; set; }
        public DbSet<VehicleModel> Vehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=utazasok;Uid=root;Pwd=;", ServerVersion.AutoDetect("Server=localhost;Database=utazasok;Uid=root;Pwd=;"));
        }
    }
}
