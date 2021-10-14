using Microsoft.EntityFrameworkCore;
using SegundoParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {

        }
        public DbSet<Magic> Magic { get; set; }
    }
}
