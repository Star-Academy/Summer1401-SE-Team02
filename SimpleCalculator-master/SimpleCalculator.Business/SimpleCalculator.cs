using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness;

namespace SimpleCalculator.Business
{
    public class Calculator
    {
        private readonly IOperatorProvider _operatorProvider;

        public Calculator(IOperatorProvider operatorProvider)
        {
            _operatorProvider = operatorProvider;
        }

        public Calculator() : this(new OperatorProvider())
        {
        }

        public int Calculate(int first, int second, OperatorEnum operatorType)
        {
            var @operator = _operatorProvider.GetOperator(operatorType);
            return @operator.Calculate(first, second);
        }
    }
}