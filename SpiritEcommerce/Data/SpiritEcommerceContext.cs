using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpiritEcommerce.Models;

namespace SpiritEcommerce.Data
{
    public class SpiritEcommerceContext : DbContext
    {
        public SpiritEcommerceContext (DbContextOptions<SpiritEcommerceContext> options)
            : base(options)
        {
        }

        public DbSet<SpiritEcommerce.Models.User> User { get; set; }
    }
}
