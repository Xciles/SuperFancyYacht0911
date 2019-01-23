using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperAwesome.Api.Business
{
    public interface ISkill
    {
        IEnumerable<Domain.Skill> GetSkills();
        Task<Domain.Skill> GetById(int id);
        Task Update(int id, Domain.Skill skill);
    }
}