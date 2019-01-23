namespace SuperAwesome.Api.Domain
{
    public class Many
    {
        public int Id { get; set; }

        public One One { get; set; }
        public int OneId { get; set; }
    }
}