using MyLibrary.Business;

namespace MyLibrary.Domain
{
    public abstract class Book : IBook
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EGenre Genre { get; set; }
        public int AvailableFromAge { get; set; } = 0;
    }
}