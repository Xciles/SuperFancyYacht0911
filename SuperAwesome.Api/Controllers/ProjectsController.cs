using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperAwesome.Api.Data;
using SuperAwesome.Api.Domain;

namespace SuperAwesome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private static Task _initialize;
        private static string _googleResult;

        public ProjectsController(ApiDbContext context)
        {
            _context = context;
        }

        static ProjectsController()
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

        // GET: api/Projects
        /// <summary>
        /// Wat een mooie documentatie!
        /// </summary>
        /// <returns><see cref="Project"/>Projects!</returns>
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects;
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;
            await _initialize;

            var enLinq = (from p in _context.Set<Project>()
                                    .Include(x => x.Skills).ThenInclude(x => x.Project)
                                where p.Id == 1
                                select p).FirstOrDefaultAsync();

            await enLinq;
            

            var entity = _context
                                .Set<Project>()
                                //.ToList()
                                .FirstOrDefault(x => x.Id == 1);

            var entity2 = await _context
                                .Set<Project>()
                                .Where(x => x.Id == 1 && x.Name.Equals(""))
                                    //.All(x => x.Name.StartsWith("E"))
                                    //.Any()
                                    //.Count()
                                .OrderBy(x => x.EndDate).ThenBy(x => x.Name)
                                .FirstOrDefaultAsync();

            // order by id, date


            //var p = new Project
            //{
            //    Id = 1,
            //    Name = "Test",
            //};

            //var skill = new Skill
            //{
            //    Name = "wyeguyweht",
            //    ProjectId = 1
            //};
            //_context.Set<Skill>().Add(skill);

            var project = await _context.Projects
                //.Include(x => x.Skills).ThenInclude(x => x.Skill)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            var skills = await _context.Set<SkillToProject>()
                                .Where(x => x.ProjectId == project.Id)
                                .Select(x => x.Skill)
                                .ToListAsync();

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        //// GET: api/Projects/5
        //[HttpGet("skills/{id}")]
        //public async Task<IActionResult> GetProjectSkills([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //var skills = await _context.Set<Skill>().Where(x => x.ProjectId.Equals(id)).ToListAsync();

        //    return Ok(skills);
        //}

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject([FromRoute] int id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return Ok(project);
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}