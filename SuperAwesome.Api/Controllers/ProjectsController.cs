using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperAwesome.Api.Business;
using SuperAwesome.Api.Data;
using SuperAwesome.Api.Domain;
using Project = SuperAwesome.Api.Domain.Project;

namespace SuperAwesome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProject _project;

        public ProjectsController(IProject project)
        {
            _project = project;
        }

        // GET: api/Projects
        /// <summary>
        /// Wat een mooie documentatie!
        /// </summary>
        /// <returns><see cref="Domain.Project"/>Projects!</returns>
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _project.GetProjects();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _project.GetById(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
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

            try
            {
                await _project.Update(id, project);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
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

            await _project.Add(project);

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

            try
            {

                var project = await _project.Delete(id);
                return Ok(project);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}