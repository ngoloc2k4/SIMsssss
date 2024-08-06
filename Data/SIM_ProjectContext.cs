using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIM_Project.Models;

namespace SIM_Project.Data
{
    public class SIM_ProjectContext : DbContext
    {
        public SIM_ProjectContext (DbContextOptions<SIM_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SIM_Project.Models.Admin> Admin { get; set; } = default!;
    }
}
