using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuperAwesome.Api.Domain
{

    public class Skill
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Project Project { get; set; }
        public int? ProjectId { get; set; }
    }

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
        public IList<Skill> Skills { get; set; }
    }

    public enum EProjectType
    {
        FullTime,
        PartTime,
        Freelance
    }
}
