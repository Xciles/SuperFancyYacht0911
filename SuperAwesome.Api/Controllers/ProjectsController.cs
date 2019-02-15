using SuperAwesome.Api.Business;

namespace SuperAwesome.Api.Controllers
{
    public class ProjectsController : GenericBaseController<Domain.Project, int>
    {
        public ProjectsController(IProject project) : base(project)
        {
        }
    }
}