using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAwesome.Api.Data;

namespace SuperAwesome.Api.Business
{
    public class Project : BaseEntity<Domain.Project, int>, IProject
    {
        public Project(ApiDbContext context) : base(context)
        {
        }

        protected override IQueryable<Domain.Project> GetAllWhere(IQueryable<Domain.Project> query)
        {
            //if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            //{
            //    query = query.Where(x => x.Name.StartsWith("a"));
            //}
            //else
            //{
            //    query = query.Where(x => x.Name.StartsWith("b"));
            //}

            query = query.OrderBy(x => x.Description);

            //query.Include(x => x.Skills).ThenInclude(x => x.Skill).ThenInclude(x => x.Projects)
            //    .Include(x => x.Users).ThenInclude(x => x.Projects);


            return query;
        }

        protected override async Task<Domain.Project> GetByIdQuery(int id)
        {
            return await Context.Set<Domain.Project>()
                                        .Include(x => x.Skills).ThenInclude(x => x.Skill)
                                    .Where(x => x.CreatedDate > DateTime.MaxValue)
                                    .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
