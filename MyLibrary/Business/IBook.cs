namespace MyLibrary.Business
{
    public interface IBook
    {
        string Title { get; set; }
        string Description { get; set; }
        EGenre Genre { get; set; }
        int AvailableFromAge { get; set; }
    }
}