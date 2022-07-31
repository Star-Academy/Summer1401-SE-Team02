using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Business.OperatorBusiness
{
    public class OperatorProvider : IOperatorProvider
    {
        public IOperator GetOperator(OperatorEnum operatorType)
        {
            return operatorType switch
            {
                OperatorEnum.sum => new SumOperator(),
                OperatorEnum.sub => new SubOperator(),
                OperatorEnum.multiply => new MultiplyOperator(),
                OperatorEnum.division => new DivisionOperator(),
                _ => throw new NotSupportedException(),
            };
        }
    }
}