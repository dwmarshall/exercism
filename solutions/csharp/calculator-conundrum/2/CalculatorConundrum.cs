public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        try
        {
            int result = 0;

            if (operation == null)
            {
                throw new ArgumentNullException();
            }
            else if (operation == string.Empty)
            {
                throw new ArgumentException();
            }
            switch (operation)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    result = operand1 / operand2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return $"{operand1} {operation} {operand2} = {result}";
        }
        catch (DivideByZeroException)
        {
            return "Division by zero is not allowed.";
        }
    }
}
