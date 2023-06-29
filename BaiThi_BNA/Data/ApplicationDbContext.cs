using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaiThi_BNA;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaiThi_BNA.BNA_Cau3> BNA_Cau3 { get; set; } = default!;

        public DbSet<BaiThi_BNA.BNA_Cau3KeThua> BNA_Cau3KeThua { get; set; } = default!;
    }
