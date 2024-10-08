namespace Domain;

public class Movie
{
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Movie(string title, string director, DateTime releaseDate)
    {
        Title = title;
        Director = director;
        ReleaseDate = releaseDate;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Director: {Director}, ReleaseDate: {ReleaseDate}";
    }
}