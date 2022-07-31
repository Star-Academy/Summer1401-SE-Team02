using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;

namespace SimpleCalculator.ConsoleApp
{
    internal class UiManager
    {
        private static readonly Dictionary<string, OperatorEnum> s_operatorSigns = new()
        {
            {"+", OperatorEnum.sum },
            {"-", OperatorEnum.sub },
            {"*", OperatorEnum.multiply },
            {"/", OperatorEnum.division }
        };

        private readonly Calculator _calculator;

        public UiManager(Calculator calculator)
        {
            _calculator = calculator;
        }

        public void StartUI()
        {
            SayHi();
            var operatorType = GetOperator();
            var firstOperand = GetOperand("first");
            var secondOperand = GetOperand("second");
            Calculate(operatorType, firstOperand, secondOperand);
        }

        private static string? GetNumberString(string name)
        {
            Console.WriteLine($"Write a non-decimal number for '{name} operand:");
            return Console.ReadLine();
        }

        private static int GetOperand(string name)
        {
            var numberString = GetNumberString(name);
            while (!int.TryParse(numberString, out _))
            {
                Console.WriteLine($"Cannot parse given number '{numberString}'");
                numberString = GetNumberString(name);
            }
            return int.Parse(numberString);
        }

        private static OperatorEnum GetOperator()
        {
            var operatorSign = GetOperatorSign();
            while (!s_operatorSigns.ContainsKey(operatorSign))
            {
                Console.WriteLine($"Given operator '{operatorSign}' is not valid!");
                operatorSign = GetOperatorSign();
            }
            return s_operatorSigns[operatorSign];
        }

        private static string GetOperatorSign()
        {
            Console.WriteLine($"Write operator sign ({string.Join(',', s_operatorSigns.Keys)}):");
            return Console.ReadLine().Trim();
        }

        private static void SayHi()
        {
            Console.WriteLine("Hi user");
            Console.WriteLine("How you doing?");
        }

        private void Calculate(OperatorEnum operatorType, int firstOperand, int secondOperand)
        {
            var result = _calculator.Calculate(firstOperand, secondOperand, operatorType);
            Console.WriteLine($"{operatorType}({firstOperand}, {secondOperand}) = {result}");
        }
    }
}