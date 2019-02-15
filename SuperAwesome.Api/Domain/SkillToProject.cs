using System.ComponentModel.DataAnnotations;

namespace SuperAwesome.Api.Domain
{
    public class SkillToProject : BaseDomain<int>
    {
        public Skill Skill { get; set; }
        public int SkillId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}