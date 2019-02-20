using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SuperAwesome.Api.Business;
using SuperAwesome.Api.Domain;

namespace SuperAwesome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericBaseController<T, TId> : ControllerBase 
        where T : BaseDomain<TId>
    {
        private readonly IMemoryCache _cache;
        protected IBaseEntity<T, TId> Entity { get; set; }

        protected static List<T> InMemoryCache { get; set; }

        protected GenericBaseController(IBaseEntity<T, TId> entity, IMemoryCache cache)
        {
            _cache = cache;
            Entity = entity;
        }

        // GET: api/Projects
        /// <summary>
        /// Wat een mooie documentatie!
        /// </summary>
        /// <returns><see cref="T"/>Projects!</returns>
        [HttpGet]
        public virtual Task<List<T>> GetAll()
        {
            return Entity.GetAll();

            //// Look for cache key.
            //object cacheEntry;
            //if (!_cache.TryGetValue("GetAll", out cacheEntry))
            //{
            //    // Key not in cache, so get data.
            //    cacheEntry = await Entity.GetAll();

            //    // Set cache options.
            //    var cacheEntryOptions = new MemoryCacheEntryOptions()
            //        // Keep in cache for this time, reset time if accessed.
            //        .SetSlidingExpiration(TimeSpan.FromSeconds(3));

            //    // Save data in cache.
            //    _cache.Set("GetAll", cacheEntry, cacheEntryOptions);
            //}

            //return (List<T>)cacheEntry;

            ////if (InMemoryCache == null)
            ////{
            ////    InMemoryCache = await Entity.GetAll();
            ////}

            ////return InMemoryCache;
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await Entity.GetById(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] T model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!id.Equals(model.Id))
            {
                return BadRequest();
            }

            try
            {
                await Entity.Update(id, model);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Projects
        [HttpPost]
        public virtual async Task<IActionResult> PostProject([FromBody] T model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await Entity.Add(model);

            return CreatedAtAction("Get", new { id = model.Id }, model);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var project = await Entity.Delete(id);
                return Ok(project);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}