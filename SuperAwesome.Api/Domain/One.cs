using System.Collections.Generic;

namespace SuperAwesome.Api.Domain
{
    public class One
    {
        public int Id { get; set; }

        public IList<Many> Manies { get; set; }
    }
}