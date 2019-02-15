using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperAwesome.Api.Business;

namespace SuperAwesome.Api.Controllers
{
    public class ProjectsController : GenericBaseController<Domain.Project, int>
    {
        public ProjectsController(IProject project) : base(project)
        {
        }

        //public override async Task<List<Domain.Project>> GetAll()
        //{
        //    var projects = await base.GetAll();

        //    var result = Mapper.Map<IList<Domain.Project>, IList<ApiDomain.Project>>(projects);

        //    return result;
        //}

        [HttpGet("Bla")]
        public async Task<List<ApiDomain.Project>> GetAll2()
        {
            var projects = await base.GetAll();


            var result = Mapper.Map<IList<Domain.Project>, List<ApiDomain.Project>>(projects);

            var apiProject = projects.Select(x => new ApiDomain.Project
            {
                Name = x.Name
            });

            var newList = new List<ApiDomain.Project>();
            foreach (var project in projects)
            {
                newList.Add(new ApiDomain.Project
                {
                    Name = project.Name
                });
            }

            return result;
        }
    }
}