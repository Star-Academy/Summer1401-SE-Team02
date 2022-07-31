using SimpleCalculator.Business.Abstraction;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("SimpleCalculator.Tests")]

namespace SimpleCalculator.Business.OperatorBusiness.Operators
{
    internal class DivisionOperator : IOperator
    {
        public int Calculate(int first, int second)
        {
            if (second == 0)
            {
                throw new DivideByZeroException();
            }
            return first / second;
        }
    }
}