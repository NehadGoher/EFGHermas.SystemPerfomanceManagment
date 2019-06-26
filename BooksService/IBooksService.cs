using System.ServiceModel;

namespace BooksService
{
    [ServiceContract]
    public interface IBooksService
    {
        [OperationContract]
        string GetBook();
    }
}