using Domain;
using Dtos;

namespace BusinessLogic.Interfaces;

public interface IMovieLogic
{
    List<MovieDto> GetMovies();
    void AddMovie(MovieDto movie);
    void DeleteMovie(String title);
    void UpdateMovie(MovieDto movie);
    MovieDto SearchMovieByTitle(String title);
}