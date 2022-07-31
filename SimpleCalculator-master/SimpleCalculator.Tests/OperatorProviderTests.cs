using FluentAssertions;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Tests;

public class OperatorProviderTests
{
     private readonly OperatorProvider _operatorProvider;

     public OperatorProviderTests()
     {
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

}