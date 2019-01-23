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

        public IEnumerable<Domain.Project> GetProjects()
        {
            return _context.Set<Domain.Project>();
        }

        // Old example method for initializing
        //public async Task<Domain.Project> GetByIdOld(int id)
        //{
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;
        //    await _initialize;

        //    var enLinq = (from p in _context.Set<Domain.Project>()
        //                            .Include(x => x.Skills).ThenInclude(x => x.Project)
        //                  where p.Id == 1
        //                  select p).FirstOrDefaultAsync();

        //    await enLinq;


        //    var entity = _context
        //                        .Set<Domain.Project>()
        //                        //.ToList()
        //                        .FirstOrDefault(x => x.Id == 1);

        //    var entity2 = await _context
        //                        .Set<Domain.Project>()
        //                        .Where(x => x.Id == 1 && x.Name.Equals(""))
        //                        //.All(x => x.Name.StartsWith("E"))
        //                        //.Any()
        //                        //.Count()
        //                        .OrderBy(x => x.EndDate).ThenBy(x => x.Name)
        //                        .FirstOrDefaultAsync();

        //    // order by id, date


        //    //var p = new Project
        //    //{
        //    //    Id = 1,
        //    //    Name = "Test",
        //    //};

        //    //var skill = new Skill
        //    //{
        //    //    Name = "wyeguyweht",
        //    //    ProjectId = 1
        //    //};
        //    //_context.Set<Skill>().Add(skill);

        //    var project = await _context.Set<Domain.Project>()
        //        //.Include(x => x.Skills).ThenInclude(x => x.Skill)
        //        .FirstOrDefaultAsync(x => x.Id.Equals(id));

        //    var skills = await _context.Set<Domain.SkillToProject>()
        //                        .Where(x => x.ProjectId == project.Id)
        //                        .Select(x => x.Skill)
        //                        .ToListAsync();

        //    if (project == null)
        //    {
        //        throw new EntityNotFoundException();
        //    }

        //    return project;
        //}

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
