using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuperAwesome.Api.Domain
{
    public class One
    {
        public int Id { get; set; }

        public IList<Many> Manies { get; set; }
    }

    public class Many
    {
        public int Id { get; set; }

        public One One { get; set; }
        public int OneId { get; set; }
    }

    public class User
    {
        public IList<UserToProject> Projects { get; set; }
    }

    public class UserToProject
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public Project2 Project2 { get; set; }
        public int Project2Id { get; set; }
    }

    public class Project2
    {
        public IList<UserToProject> Users { get; set; }
    }
    

    public class Skill
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public IList<SkillToProject> Projects { get; set; }
    }

    public class SkillToProject
    {
        [Key]
        public int Id { get; set; }
        public Skill Skill { get; set; }
        public int SkillId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
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
        public IList<SkillToProject> Skills { get; set; }
    }

    public enum EProjectType
    {
        FullTime,
        PartTime,
        Freelance
    }
}
