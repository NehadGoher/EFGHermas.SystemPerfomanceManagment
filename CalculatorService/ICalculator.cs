using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface ICalculator
    {
        [WebGet(UriTemplate = "Add/{n1}/{n2}")]
        [OperationContract]
        CalculationResult Add(string n1, string n2);

        [WebGet(UriTemplate = "Subtract/{n1}/{n2}")]
        [OperationContract]
        CalculationResult Subtract(string n1, string n2);

        [WebGet(UriTemplate = "Multiply/{n1}/{n2}")]
        [OperationContract]
        CalculationResult Multiply(string n1, string n2);

        [WebGet(UriTemplate = "Divide/{n1}/{n2}")]
        [OperationContract]
        CalculationResult Divide(string n1, string n2);
    }

    [DataContract]
    public class CalculationResult
    {
        [DataMember] public double Answer;

        [DataMember] public string Message;
    }
}
