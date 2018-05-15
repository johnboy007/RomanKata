namespace RomanNumeralConverter.Services
{
    /// <inheritdoc />
    /// <summary>
    ///     Roman Numeral class with return Generate method inherited from IGenerate
    /// </summary>
    public class RomanNumeral : IGenerator
    {
        /// <summary>
        ///     Error message string
        /// </summary>
        public string ErrorMessage;

        /// <summary>
        ///     Min value to pass to get Roman Numeral
        /// </summary>
        private const int Min = 1;

        /// <summary>
        ///     Max Value to pass to get Max Value
        /// </summary>
        private const int Max = 3999;

        /// <summary>
        ///     Thousands string array
        /// </summary>
        private readonly string[] _thousands = {"", "M", "MM", "MMM"};

        /// <summary>
        ///     Hundreds string array
        /// </summary
        private readonly string[] _hundreds = {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};

        /// <summary>
        ///     Tens string array
        /// </summary
        private readonly string[] _tens = {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};

        /// <summary>
        ///     Ones string array
        /// </summary
        private readonly string[] _ones = {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};

        public string generate(int number)
        {
            //Lets check to see if the number is in range
            if (!MathHelper.IsNumberInRange(number, Min, Max, out ErrorMessage))
                return null;

            // Process the letters.
            var result = "";

            // Thousands.
            var numberTemp = number / 1000;
            result += _thousands[numberTemp];
            number %= 1000;

            // Hundreds.
            numberTemp = number / 100;
            result += _hundreds[numberTemp];
            number %= 100;

            // Tens.
            numberTemp = number / 10;
            result += _tens[numberTemp];
            number %= 10;

            // Ones.
            result += _ones[number];

            return result;
        }
    }
}