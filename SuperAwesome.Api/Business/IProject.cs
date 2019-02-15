using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperAwesome.Api.Business
{
    public interface IProject
    {
        Task<List<Domain.Project>> GetProjects();
        Task<Domain.Project> GetById(int id);
        Task Update(int id, Domain.Project project);
        Task Add(Domain.Project project);
        Task<Domain.Project> Delete(int id);
    }
}