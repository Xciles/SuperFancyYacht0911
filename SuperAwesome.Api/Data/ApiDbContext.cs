using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperAwesome.Api.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Domain.Project> Projects { get; set; }
        public DbSet<Domain.Car> Cars { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<SuperAwesome.Api.Domain.Skill> Skill { get; set; }
    }
}
