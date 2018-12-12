using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAwesome.Api.Domain;

namespace SuperAwesome.Api.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<SuperAwesome.Api.Domain.Skill> Skill { get; set; }
    }
}
