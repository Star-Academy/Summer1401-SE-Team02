using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;

namespace SimpleCalculator.Test;

public class OperationsTest
{
     private readonly Calculator _calculator;
     public OperationsTest()
     {
          _calculator = new Calculator();
     }

     [Theory]
     [InlineData(50, 30, 20)]
     [InlineData(12, 9, 3)]
     public void SumOperationCalculation_Integer_ReturnAsIs(int expected, int firstNum, int secondNum)
     {
          var result = _calculator.Calculate(firstNum, secondNum, OperatorEnum.sum);
          Assert.Equal(expected, result);
     }

     [Theory]
     [InlineData(-5, 7, 12)]
     [InlineData(3, 27, 24)]
     public void SubOperationCalculation_Integers_ReturnAsIs(int expected, int firstNum, int secondNum)
     {
          var result = _calculator.Calculate(firstNum, secondNum, OperatorEnum.sub);

          Assert.Equal(expected, result);
     }

     [Theory]
     [InlineData(99, 11, 9)]
     [InlineData(-120, -5, 24)]
     [InlineData(0, 1234, 0)]
     public void MultiplicationOperationCalculation_Integers_ReturnAsIs(int expected, int firstNum, int secondNum)
     {
          var result = _calculator.Calculate(firstNum, secondNum, OperatorEnum.multiply);

          Assert.Equal(expected, result);
     }

     [Theory]
     [InlineData(4, 32, 8)]
     [InlineData(-5, 125, -25)]
     public void DivisionOperationCalculation_NonZeroDividableArguments_ReturnAsIs(int expected, int firstNum, int secondNum)
     {
          var result = _calculator.Calculate(firstNum, secondNum, OperatorEnum.division);

          Assert.Equal(expected, result);
     }


     [Theory]
     [InlineData(32)]
     public void DivisionOperationCalculation_ByZero_ReturnDivideByZeroException(int firstNum)
     {
          Assert.Throws<DivideByZeroException>(() => _calculator.Calculate(firstNum, 0, OperatorEnum.division));
     }
}