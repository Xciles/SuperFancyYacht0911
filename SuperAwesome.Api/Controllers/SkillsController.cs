﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperAwesome.Api.Business;
using SuperAwesome.Api.Data;
using Skill = SuperAwesome.Api.Domain.Skill;

namespace SuperAwesome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkill _skill;

        public SkillsController(ISkill skill)
        {
            _skill = skill;
        }

        // GET: api/Skills
        /// <summary>
        /// Wat een mooie documentatie!
        /// </summary>
        /// <returns><see cref="Domain.Skill"/>Skills!</returns>
        [HttpGet]
        public virtual Task<List<Skill>> GetSkills()
        {
            return _skill.GetAll();
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _skill.GetById(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Skills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill([FromRoute] int id, [FromBody] Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skill.Id)
            {
                return BadRequest();
            }

            try
            {
                await _skill.Update(id, skill);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Skills
        [HttpPost]
        public async Task<IActionResult> PostSkill([FromBody] Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _skill.Add(skill);

            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var skill = await _skill.Delete(id);
                return Ok(skill);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}