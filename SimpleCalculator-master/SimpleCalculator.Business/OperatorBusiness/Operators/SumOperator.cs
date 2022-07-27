using SimpleCalculator.Business.Abstraction;

namespace SimpleCalculator.Business.OperatorBusiness.Operators
{
    internal class SumOperator : IOperator
    {
        public int Calculate(int first, int second)
        {
            return first + second;
        }
    }
}