using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Megventory_API.Models;

namespace Megventory_API.Data
{
    public class Megventory_APIContext : DbContext
    {
        public Megventory_APIContext (DbContextOptions<Megventory_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Megventory_API.Models.mvSupplierClients> mvSupplierClients { get; set; }

        public DbSet<Megventory_API.Models.mvProducts> mvProducts { get; set; }

        public DbSet<Megventory_API.Models.Taxes> Taxes { get; set; }

        public DbSet<Megventory_API.Models.mvDiscounts> mvDiscounts { get; set; }
    }
}
