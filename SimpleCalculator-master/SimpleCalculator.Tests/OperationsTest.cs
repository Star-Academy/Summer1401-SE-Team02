using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;
using FluentAssertions;

namespace SimpleCalculator.Tests;

public class OperationsTest
{
    private readonly Calculator _calculator;

    public OperationsTest()
    {
        _calculator = new Calculator();
    }
    
    // intentionally commented :)
    // [Theory]
    // [InlineData(OperatorEnum.sum, new SumOperator())]
    // [InlineData(OperatorEnum.sub, new SubOperator())]
    // [InlineData(OperatorEnum.division, new DivisionOperator())]
    // [InlineData(OperatorEnum.multiply, new MultiplyOperator())]
    // public void OperatorProviderGetMethod_ValidOperators_ReturnItself(OperatorEnum operation, IOperator expected)
    // {
    //    var result = _operatorProvider.GetOperator(operation);
    //    result.Should().Be(expected);
    // }

    [Theory]
    [InlineData(50, 30, 20)]
    [InlineData(12, 9, 3)]
    public void SumOperationCalculation_Integers_ReturnAsIs(int expected, int firstNum, int secondNum)
    {
        var result = _calculator.Calculate(firstNum, secondNum, OperatorEnum.sum);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-5, 7, 12)]
    [InlineData(3, 27, 24)]
    public void SubOperationCalculation_Integers_ReturnAsIs(int expected, int firstNum, int secondNum)
    {
        var result = _calculator.Calculate(firstNum, secondNum, OperatorEnum.sub);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(99, 11, 9)]
    [InlineData(-120, -5, 24)]
    [InlineData(0, 1234, 0)]
    public void MultiplicationOperationCalculation_Integers_ReturnAsIs(int expected, int firstNum, int secondNum)
    {
        var result = _calculator.Calculate(firstNum, secondNum, OperatorEnum.multiply);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(4, 32, 8)]
    [InlineData(-5, 125, -25)]
    public void DivisionOperationCalculation_NonZeroDividableArguments_ReturnAsIs(int expected, int firstNum,
        int secondNum)
    {
        var result = _calculator.Calculate(firstNum, secondNum, OperatorEnum.division);
        result.Should().Be(expected);
    }


    [Theory]
    [InlineData(32)]
    public void DivisionOperationCalculation_ByZero_ReturnDivideByZeroException(int firstNum)
    {
        _calculator.Invoking(c => c.Calculate(firstNum, 0, OperatorEnum.division))
            .Should().Throw<DivideByZeroException>();
    }
}