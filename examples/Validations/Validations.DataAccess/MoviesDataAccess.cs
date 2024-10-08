using Validations.Domain;

namespace Validations.DataAccess;

public class MoviesDataAccess
{
    private readonly List<Movie> _movies = new List<Movie>();
    
    public List<Movie> GetMovies()
    {
        return _movies;
    }

    public void AddMovie(Movie movie)
    {
        _movies.Add(movie);
    }
}