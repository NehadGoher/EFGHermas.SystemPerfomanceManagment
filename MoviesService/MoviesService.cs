using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesService
{
    public class MoviesServiceClass : IMoviesService
    {
        public string GetMovies()
        {
            return "Movie";
        }
    }
}
