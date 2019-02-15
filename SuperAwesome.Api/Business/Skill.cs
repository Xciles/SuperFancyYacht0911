using SuperAwesome.Api.Data;

namespace SuperAwesome.Api.Business
{
    public class Skill : BaseEntity<Domain.Skill, int>, ISkill
    {
        public Skill(ApiDbContext context) : base(context)
        {
        }
    }
}