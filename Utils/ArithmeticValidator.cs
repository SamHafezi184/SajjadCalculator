namespace SajjadCalculator.Utils
{
    public class ArithmeticValidator
    {
        /// <summary>
        /// Validates that a double value is within acceptable bounds.
        /// </summary>
        /// <param name="result">The result to validate.</param>
        /// <exception cref="ArithmeticException">Thrown if the result is Infinity or NaN.</exception>
        public static void ValidateResult(double result)
        {
            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                throw new ArithmeticException("The result exceeds the maximum allowed value for a double.");
            }
        }
    }
}
