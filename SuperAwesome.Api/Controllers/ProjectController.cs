using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAwesome.Api.Domain;

namespace SuperAwesome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<Project>
            {
                new Project()
                {
                    Name = "TYest"
                },
                new Project()
                {
                    Name = "TYest 2"
                }
            };
            return Ok(list);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new Project()
            {
                Name = "TYest"
            });
        }
    }
}
