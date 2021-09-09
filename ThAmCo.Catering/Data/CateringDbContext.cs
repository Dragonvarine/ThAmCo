using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Models;

namespace ThAmCo.Catering.Data
{
    public class CateringDbContext : DbContext
    {
        public CateringDbContext (DbContextOptions<CateringDbContext> options)
            : base(options)
        {
        }
        public DbSet<ThAmCo.Catering.Models.FoodBooking> FoodBooking { get; set; }
    }
}
