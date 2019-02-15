using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperAwesome.Api.Domain
{
    public class Skill : BaseDomain<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<SkillToProject> Projects { get; set; }
    }
}