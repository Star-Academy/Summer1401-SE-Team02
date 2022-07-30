using SimpleCalculator.Business.Abstraction;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("SimpleCalculator.Tests")]

namespace SimpleCalculator.Business.OperatorBusiness.Operators
{
    internal class MultiplyOperator : IOperator
    {
        public int Calculate(int first, int second)
        {
            return first * second;
        }
    }
}