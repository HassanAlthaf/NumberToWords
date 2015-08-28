/***
 *   Copyright © 2015, Hassan Althaf.
 **/

using System;

namespace NumberToWords
{
    public static class NumberToWordsConverter
    {
        private static readonly string[] numbers = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] tens = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        const int MinimumRange = -1000000;
        const int MaximumRange = 1000000;

        public static string ConvertToString(int number)
        {
            string words = null;

            if (number < MinimumRange || number > MaximumRange)
            {
                return "Only numbers between minus 1 million and positive 1 million inclusively are allowed";
            }

            if (number < 0)
            {
                words = words + "Minus ";
                number = number * -1;
            }

            char[] digits = number.ToString().ToCharArray();

            if (number >= 0 && number <= 19)
            {
                words = words + NumberToWordsConverter.numbers[number];
            }
            else if (number >= 20 && number <= 99)
            {
                int firstDigit = (int)Char.GetNumericValue(digits[0]);
                int secondPart = number % 10;

                words = words + NumberToWordsConverter.tens[firstDigit];

                if (secondPart > 0)
                {
                    words = words + " " + ConvertToString(secondPart);
                }
            }
            else if (number >= 100 && number <= 999)
            {
                int firstDigit = (int)Char.GetNumericValue(digits[0]);
                int secondPart = number % 100;

                words = words + NumberToWordsConverter.numbers[firstDigit] + " hundred";

                if (secondPart > 0)
                {
                    words = words + " and " + ConvertToString(secondPart);
                }
            }
            else if (number >= 1000 && number <= 19999)
            {
                int firstPart = (int)Char.GetNumericValue(digits[0]);
                if (number >= 10000)
                {
                    string twoDigits = digits[0].ToString() + digits[1].ToString();
                    firstPart = Convert.ToInt16(twoDigits);
                }
                int secondPart = number % 1000;

                words = words + NumberToWordsConverter.numbers[firstPart] + " thousand";

                if (secondPart > 0 && secondPart <= 99)
                {
                    words = words + " and " + ConvertToString(secondPart);
                } else if (secondPart >= 100)
                {
                    words = words + " " + ConvertToString(secondPart);
                }
            }
            else if (number >= 20000 && number <= 999999)
            {
                string firstStringPart = Char.GetNumericValue(digits[0]).ToString() + Char.GetNumericValue(digits[1]).ToString();

                if (number >= 100000)
                {
                    firstStringPart = firstStringPart + Char.GetNumericValue(digits[2]).ToString();
                }

                int firstPart = Convert.ToInt16(firstStringPart);
                int secondPart = number - (firstPart * 1000);

                words = words + ConvertToString(firstPart) + " thousand";

                if (secondPart > 0 && secondPart <= 99)
                {
                    words = words + " and " + ConvertToString(secondPart);
                } else if (secondPart >= 100)
                {
                    words = words + " " + ConvertToString(secondPart);
                }

            }
            else if (number == 1000000)
            {
                words = words + "One million";
            }

            return words;
        }
    }
}