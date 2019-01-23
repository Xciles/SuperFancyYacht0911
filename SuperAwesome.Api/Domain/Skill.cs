using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperAwesome.Api.Domain
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public IList<SkillToProject> Projects { get; set; }
    }
}