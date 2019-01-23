using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAwesome.Api.Data;

namespace SuperAwesome.Api.Business
{
    public class Skill : ISkill
    {
        private readonly DbContext _context;

        public Skill(ApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Domain.Skill> GetSkills()
        {
            return _context.Set<Domain.Skill>();
        }

        public async Task<Domain.Skill> GetById(int id)
        {
            var project = await _context.Set<Domain.Skill>()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (project == null)
            {
                throw new EntityNotFoundException();
            }

            return project;
        }

        public async Task Update(int id, Domain.Skill project)
        {
            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    throw new EntityNotFoundException();
                }
                throw;
            }
        }

        private bool ProjectExists(int id)
        {
            return _context.Set<Domain.Skill>().Any(e => e.Id == id);
        }
    }
}