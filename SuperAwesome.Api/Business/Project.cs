using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperAwesome.Api.Data;

namespace SuperAwesome.Api.Business
{
    public class Project : IProject
    {
        private readonly DbContext _context;
        private static Task _initialize;
        private static string _googleResult;

        public Project(ApiDbContext context)
        {
            _context = context;
        }

        static Project()
        {
            _initialize = RetrieveData();
        }

        private static async Task RetrieveData()
        {
            await Task.Delay(2_000);
            using (var client = new HttpClient())
            {
                _googleResult = await client.GetStringAsync("https://www.google.com");
            }
        }

        public Task<List<Domain.Project>> GetProjects()
        {
            return _context.Set<Domain.Project>().ToListAsync();
        }

        public async Task<Domain.Project> GetById(int id)
        {
            var project = await _context.Set<Domain.Project>()
                                        .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (project == null)
            {
                throw new EntityNotFoundException();
            }

            return project;
        }

        public async Task Update(int id, Domain.Project project)
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

        public async Task Add(Domain.Project project)
        {
            _context.Set<Domain.Project>().Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Project> Delete(int id)
        {
            var project = await _context.Set<Domain.Project>().FindAsync(id);
            if (project == null)
            {
                throw new EntityNotFoundException();
            }

            _context.Set<Domain.Project>().Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }

        private bool ProjectExists(int id)
        {
            return _context.Set<Domain.Project>().Any(e => e.Id == id);
        }
    }
}
