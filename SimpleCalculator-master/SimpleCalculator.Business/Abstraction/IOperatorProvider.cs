using SimpleCalculator.Business.Enums;

namespace SimpleCalculator.Business.Abstraction
{
    public interface IOperatorProvider
    {
        IOperator GetOperator(OperatorEnum operatorType);
    }
}