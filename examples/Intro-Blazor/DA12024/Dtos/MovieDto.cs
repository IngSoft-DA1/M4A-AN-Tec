using Domain;

namespace Dtos;

public class MovieDto
{
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }

    public MovieDto(Movie movie)
    {
        Title = movie.Title;
        Director = movie.Director;
        ReleaseDate = movie.ReleaseDate;
    }
    
    public MovieDto(string title, string director, DateTime releaseDate)
    {
        Title = title;
        Director = director;
        ReleaseDate = releaseDate;
    }
}
