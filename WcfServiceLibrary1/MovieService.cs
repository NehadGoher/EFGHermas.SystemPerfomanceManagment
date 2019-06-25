using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MovieService : IMovieService
    {
        public List<Movie> Movies = new List<Movie>()
        {
            new Movie(){ Id=1,Name="Heba"},
            new Movie(){ Id=1,Name="Amany"}
        };
        public Movie GetMovie(int id)
        {
            return Movies.Find((x) => x.Id == id);
        }

        public List<Movie> GetMovies()
        {
            return Movies;
        }
    }
}
