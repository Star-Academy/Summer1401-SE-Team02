using FluentAssertions;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Tests;

public class OperatorsTests
{
    private readonly SumOperator _sumOperator;
    private readonly OperatorProvider _operatorProvider;
    private readonly SubOperator _subOperator;
    private readonly MultiplyOperator _multiplyOperator;
    private readonly DivisionOperator _divisionOperator;

    public OperatorsTests()
    {
        _subOperator = new SubOperator();
        _sumOperator = new SumOperator();
        _multiplyOperator = new MultiplyOperator();
        _divisionOperator = new DivisionOperator();
        _operatorProvider = new OperatorProvider();
    }
    

    #region OperatorProvider tests

    [Fact]
    public void OperatorProviderGetMethod_SumOperator_ReturnSumOperatorInstance()
    {
        var result = _operatorProvider.GetOperator(OperatorEnum.sum);
        result.Should().BeOfType<SumOperator>();
    }

    [Fact]
    public void OperatorProviderGetMethod_SubOperator_ReturnSumOperatorInstance()
    {
        var result = _operatorProvider.GetOperator(OperatorEnum.sub);
        result.Should().BeOfType<SubOperator>();
    }

    [Fact]
    public void OperatorProviderGetMethod_DivisionOperator_ReturnSumOperatorInstance()
    {
        var result = _operatorProvider.GetOperator(OperatorEnum.division);
        result.Should().BeOfType<DivisionOperator>();
    }

    [Fact]
    public void OperatorProviderGetMethod_MultiplyOperator_ReturnSumOperatorInstance()
    {
        var result = _operatorProvider.GetOperator(OperatorEnum.division);
        result.Should().BeOfType<DivisionOperator>();
    }

    [Fact]
    public void OperatorProviderGetMethod_InvalidOperator_ThrowException()
    {
        Action action = () => _operatorProvider.GetOperator((OperatorEnum)(-1));
        action.Should().Throw<NotSupportedException>();
    }

    #endregion

    #region Operators Calculation tests for simple situations

    [Theory]
    [InlineData(5, 12, 17)]
    [InlineData(-152, 22, -130)]
    [InlineData(59, -79, -20)]
    [InlineData(-59, -111, -170)]
    public void SumCalculation_SmallIntegers_ReturnSum(int firstNum, int secondNum, int expected)
    {
        var result = _sumOperator.Calculate(firstNum, secondNum);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, 12, -7)]
    [InlineData(-152, 22, -174)]
    [InlineData(59, -79, 138)]
    [InlineData(-51, -111, 60)]
    public void SubCalculation_SmallIntegers_ReturnSubtraction(int firstNum, int secondNum, int expected)
    {
        var result = _subOperator.Calculate(firstNum, secondNum);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, 12, 60)]
    [InlineData(-54, 23, -1242)]
    [InlineData(13, -71, -923)]
    [InlineData(-51, -111, 5661)]
    public void MultiplyCalculation_SmallIntegers_ReturnProduct(int firstNum, int secondNum, int expected)
    {
        var result = _multiplyOperator.Calculate(firstNum, secondNum);
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(60, 12, 5)]
    [InlineData(-1242, -54, 23)]
    [InlineData(-923, 13, -71)]
    [InlineData(5661, -51, -111)]
    public void DivisionCalculation_SmallIntegers_ReturnDivision(int firstNum, int secondNum, int expected)
    {
        var result = _divisionOperator.Calculate(firstNum, secondNum);
        result.Should().Be(expected);
    }


    #endregion

    #region Operations edge cases testing
    [Theory]
    [InlineData(Int32.MaxValue, 1, Int32.MinValue)]
    [InlineData(Int32.MinValue, -1, Int32.MaxValue)]
    [InlineData(Int32.MaxValue, Int32.MaxValue, -2)]
    public void SumCalculation_OverFlowing_ReturnOverflowedSum(int firstNum, int secondNum, int expected)
    {
        var result = _sumOperator.Calculate(firstNum, secondNum);
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(Int32.MinValue, 1, Int32.MaxValue)]
    [InlineData(Int32.MaxValue, -1, Int32.MinValue)]
    [InlineData(Int32.MinValue, Int32.MinValue, 0)]
    public void SubtractCalculation_OverFlowing_ReturnOverflowedSubtraction(int firstNum, int secondNum, int expected)
    {
        var result = _subOperator.Calculate(firstNum, secondNum);
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(72)]
    [InlineData(Int32.MaxValue)]
    [InlineData(-56)]
    public void DivisionCalculation_OverFlowing_ReturnOverflowedSubtraction(int firstNum)
    {
        Action action = () => _divisionOperator.Calculate(firstNum, 0);
        action.Should().Throw<DivideByZeroException>();
    }
    #endregion
}