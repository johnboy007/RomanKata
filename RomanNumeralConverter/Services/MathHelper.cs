namespace RomanNumeralConverter.Services
{
    /// <summary>
    ///     Math Helper class
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        ///     Checks if a number is within a certain range
        /// </summary>
        /// <param name="number"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool IsNumberInRange(int number, int min, int max, out string errorMessage)
        {
            errorMessage = null;
            if (number < min)
            {
                errorMessage = $"The number {number} is below {min}";
                return false;
            }

            if (number <= max) return true;
            errorMessage = $"The number {number} is above {max}";
            return false;
        }
    }
}