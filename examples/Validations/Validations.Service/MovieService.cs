using Validations.DataAccess;
using Validations.Domain;
using Validations.DTOs;

namespace Validations.Service;

public class MovieService
{
    private readonly MoviesDataAccess _dataAccess;

    public MovieService(MoviesDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public string? ValidateAndSaveMovie(MovieDTO movieDTO)
    {
        try
        {
            var movie = new Movie
            {
                Title = movieDTO.Title,
                Year = movieDTO.Year
            };

            _dataAccess.AddMovie(movie);

            return null; // No hay errores
        }
        catch (Exception ex)
        {
            // Devolver el mensaje de error
            return ex.Message; 
        }
    }

    public List<Movie> GetMovies()
    {
        return _dataAccess.GetMovies();
    }
}