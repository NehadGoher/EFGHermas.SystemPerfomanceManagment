using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = false,
        AddressFilterMode = AddressFilterMode.Any,
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class Calculator : ICalculator
    {
        public CalculationResult Add(string n1, string n2)
        {
            Console.WriteLine("received request to Add " + n1 + " to " + n2);
            Func<double, double, double> add = (value1, value2)
                  => (value1 + value2);
            return Calculate(n1, n2, add);
        }

        public CalculationResult Subtract(string n1, string n2)
        {
            Console.WriteLine("received request to Subtract " + n2 + " from " + n1);
            Func<double, double, double> subtract = (value1, value2)
                  => (value1 - value2);
            return Calculate(n1, n2, subtract);
        }

        public CalculationResult Multiply(string n1, string n2)
        {
            Console.WriteLine("received request to Multiply " + n1 + " by " + n2);
            Func<double, double, double> multiply = (value1, value2)
                  => (value1 * value2);
            return Calculate(n1, n2, multiply);
        }

        public CalculationResult Divide(string n1, string n2)
        {
            Console.WriteLine("received request to Divide " + n1 + " by " + n2);
            Func<double, double, double> divide = (value1, value2)
                  => value2 == 0 ? Double.NaN : (value1 / value2);
            return Calculate(n1, n2, divide);
        }

        private static CalculationResult Calculate(
            string n1,
            string n2,
            Func<double, double, double> calculate)
        {
            var value1 = Double.Parse(n1);
            //if (!value1.HasValue)
            //{
            //    return GetCouldNotConvertToDoubleResult(n1);
            //}

            var value2 = Double.Parse(n2);
            //if (!value2.HasValue)
            //{
            //    return GetCouldNotConvertToDoubleResult(n2);
            //}

            double result = calculate(value1, value2);
            return new CalculationResult
            {
                Answer = result
            };
        }

        private static CalculationResult GetCouldNotConvertToDoubleResult(string input)
        {
            return new CalculationResult
            {
                Message = "Could not convert '" + input + "' to a double"
            };
        }
    }
}
