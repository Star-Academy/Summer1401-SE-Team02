using Moq;
using FluentAssertions;
using SimpleCalculator.Business;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Tests;

public class CalculatorTests
{
    [Theory]
    [MemberData(nameof(CalculationData))]
    public void Calculate_SumOperation_ReturnSum(int firstNum, int secondNum, int expected, OperatorEnum @enum,
        IOperator operatorClass)
    {
        var providerMock = new Mock<IOperatorProvider>();
        providerMock.Setup(p => p.GetOperator(@enum)).Returns(operatorClass);
        var calculator = new Calculator(providerMock.Object);
        var result = calculator.Calculate(firstNum, secondNum, @enum);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> CalculationData =>
        new List<object[]>
        {
            new object[] { 10, 20, 30, OperatorEnum.sum, new SumOperator() },
            new object[] { 45, 15, 30, OperatorEnum.sub, new SubOperator() },
            new object[] { -2, 2, -4, OperatorEnum.multiply, new MultiplyOperator() },
            new object[] { 75, -25, -3, OperatorEnum.division, new DivisionOperator() },
        };
}