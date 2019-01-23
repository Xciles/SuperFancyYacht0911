using System.Collections.Generic;

namespace SuperAwesome.Api.Domain
{
    public class User
    {
        public IList<UserToProject> Projects { get; set; }
    }
}