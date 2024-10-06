using BusinessLogic.Interfaces;
using Domain;
using Dtos;

namespace BusinessLogic;

public class MovieLogic: IMovieLogic
{
    private List<Movie> _movies;

    public MovieLogic()
    {
        _movies = new List<Movie>();
    }
    
    public List<MovieDto> GetMovies()
    {
        var movies = _movies.Select((x)=>new MovieDto(x)).ToList();
        return movies;
    }

    public void AddMovie(MovieDto movie)
    {
        ValidateMovieTitle(movie.Title);
        var newMovie = new Movie(movie.Title, movie.Director, movie.ReleaseDate);
        _movies.Add(newMovie);
    }

    public void DeleteMovie(string title)
    {
        MovieDto movie = SearchMovieByTitle(title);

        var movieToDelete =_movies.Find(x => x.Title == movie.Title);
        if (movieToDelete != null) _movies.Remove(movieToDelete);
    }

    public void UpdateMovie(MovieDto movieToUpdateDto)
    {
        var movieToUpdate = new Movie(movieToUpdateDto.Title, movieToUpdateDto.Director, movieToUpdateDto.ReleaseDate);
        var movieToUpdateIndex = _movies.IndexOf(_movies.Find(m => m.Title == movieToUpdate.Title));
        _movies[movieToUpdateIndex] = movieToUpdate;
    }

    public MovieDto SearchMovieByTitle(String title)
        {
            Movie? movie = _movies.FirstOrDefault(movie => movie.Title == title);
            if (movie == null)
            {
                throw new ArgumentException("Cannot find movie with this title");
            }
            return new MovieDto( movie);
        }

    private void ValidateMovieTitle(String title)
    {
        foreach (var m in _movies)
        {
            if (m.Title == title)
            {
                throw new ArgumentException("Movie title already exists");
            }
        }
    }
}