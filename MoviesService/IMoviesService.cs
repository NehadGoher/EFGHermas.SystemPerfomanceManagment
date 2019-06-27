using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MoviesService
{
    [ServiceContract]
    public interface IMoviesService
    {
        [OperationContract]
        string GetMovies();
    }
}
