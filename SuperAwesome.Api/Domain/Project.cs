using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuperAwesome.Api.Domain
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public EProjectType ProjectType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //[JsonIgnore]
        public IList<SkillToProject> Skills { get; set; }
    }
}
