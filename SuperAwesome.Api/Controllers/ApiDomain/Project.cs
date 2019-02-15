using System;
using SuperAwesome.Api.Domain;

namespace SuperAwesome.Api.Controllers.ApiDomain
{
    public class Project
    {
        public EProjectType ProjectType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
