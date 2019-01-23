using System.ComponentModel.DataAnnotations;

namespace SuperAwesome.Api.Domain
{
    public class SkillToProject
    {
        [Key]
        public int Id { get; set; }
        public Skill Skill { get; set; }
        public int SkillId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}