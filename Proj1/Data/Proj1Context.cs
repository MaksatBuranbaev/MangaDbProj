using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proj1.Models;

namespace Proj1.Data
{
    public class Proj1Context : DbContext
    {
        public Proj1Context (DbContextOptions<Proj1Context> options)
            : base(options)
        {
        }

        public DbSet<Proj1.Models.Manga> Manga { get; set; } = default!;
    }
}
