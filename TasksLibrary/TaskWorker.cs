namespace TasksLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TaskWorker
    {
        private const double Error = 1e-2;
        private const int BitsCount = 32;

        /// <summary>
        /// Method for searching the maximum element of array.
        /// </summary>
        /// <param name="array">>Array in which we search maximum.</param>
        /// <returns>Maximum element of an integer array.</returns>
        public int FindMaxElementInArray(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            return this.DoRecursiveSearch(array, int.MinValue, 0);
        }

        /// <summary>
        /// Method for finding index of element, for which the sum of the elements on the left and right are equal.
        /// </summary>
        /// <param name="array">Input array of real numbers.</param>
        /// <returns>Index of element, which placed between equal sums of element on left and right sides.</returns>
        public int FindElementIndexBetweenEqualSums(double[] array)
        {
            var totalSum = array.Sum();
            var leftSum = 0.0;

            for (int i = 0; i < array.Length; i++)
            {
                // difference of the sums on the left and on the right is less than the error
                if (Math.Abs(totalSum - array[i] - (2 * leftSum)) < Error)
                    return i;

                leftSum += array[i];
            }

            return -1;
        }

        /// <summary>
        /// Inserts bits of second number in first number, between i and j indexes.
        /// </summary>
        /// <param name="numberSource">First 4-bites number.</param>
        /// <param name="numberIn">Second 4-bites number.</param>
        /// <param name="i">Start index.</param>
        /// <param name="j">End index.</param>
        /// <returns>Int number after insertion.</returns>
        public int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            var sourceBitArr = this.ConvertNumberToBitArray(numberSource);
            var inBitArr = this.ConvertNumberToBitArray(numberIn);

            var resultBitArray = new bool[BitsCount];

            for (int k = 0; k < BitsCount; k++)
            {
                var index = BitsCount - k - 1;

                if (k >= i && k <= j)
                    resultBitArray[index] = inBitArr[index + i];
                else
                    resultBitArray[index] = sourceBitArr[index];
            }

            return this.ConvertBitArrayToNumber(resultBitArray);
        }

        /// <summary>
        /// Connects the strings, removing from the second string the characters that are in the first.
        /// </summary>
        /// <param name="str1">First string.</param>
        /// <param name="str2">Second string.</param>
        /// <returns>Connected strings.</returns>
        public string ConcatStrings(string str1, string str2)
        {
            return str1 + string.Join(string.Empty, str2.Where(x => !str1.Contains(x)));
        }

        public int FindNextBiggerNumber(int inputNumber)
        {
            if (!HasNextBiggerNumber(inputNumber))
                return -1;

            var digitsArray = ConvertNumberToDigitsArray(inputNumber);

            return GetCombinations(digitsArray)
                .Select(x => ConvertDigitsArrayToNumber(x))
                .Where(x => x > inputNumber)
                .OrderBy(x => Math.Abs(x - inputNumber))
                .First();
        }

        public static IEnumerable<int[]> GetCombinations(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                yield return new int[0];
            }
            else
            {
                for (int i = 0; i < array.Length; ++i)
                {
                    var item = array[i];
                    int j = -1;
                    var rest = Array.FindAll(
                        array, p => ++j != i);

                    foreach (int[] restPermuted in GetCombinations(rest))
                    {
                        j = -1;
                        yield return Array.ConvertAll(
                            array,
                            p => ++j == 0 ? item : restPermuted[j - 1]);
                    }
                }
            }
        }

        private bool HasNextBiggerNumber(int number)
        {
            var digitsArray = ConvertNumberToDigitsArray(number);

            var zerosCount = 0;
            var digitsDescending = true;
            for (int i = 1; i < digitsArray.Length; i++)
            {
                if (i > 0 && digitsArray[i - 1] < digitsArray[i])
                    digitsDescending = false;

                if (digitsArray[i] == 0)
                    zerosCount++;
            }

            return zerosCount < digitsArray.Length - 1 && !digitsDescending;
        }

        private int[] SwapAndReturnNewArray(int[] arr, int i, int j)
        {
            var result = new int[arr.Length];
            Array.Copy(arr, result, arr.Length);

            var temp = result[i];
            result[i] = result[j];
            result[j] = temp;

            return result;
        }

        private int[] ConvertNumberToDigitsArray(int number)
        {
            var digitsCount = (int)Math.Log10(number) + 1;
            var digitsArray = new int[digitsCount];

            var minNextRankNumber = 10;
            var numberOnRight = 0;
            for (int i = 0; i < digitsCount; i++)
            {
                digitsArray[digitsCount - i - 1] = ((number % minNextRankNumber) - numberOnRight) / (minNextRankNumber / 10);
                minNextRankNumber *= 10;
            }

            return digitsArray;
        }

        private int ConvertDigitsArrayToNumber(int[] digits)
        {
            var result = 0;
            var rank = 1;
            var digitsCount = digits.Length;

            for (int i = 0; i < digitsCount; i++)
            {
                result += digits[digitsCount - i - 1] * rank;
                rank *= 10;
            }

            return result;
        }

        /// <summary>
        /// Method for recursively searching the maximum element of array.
        /// </summary>
        /// <param name="array">Array in which we search maximum.</param>
        /// <param name="maxElement">Maximum element of the array.</param>
        /// <param name="index">Index of current element.</param>
        /// <returns>Maximum of array.</returns>
        private int DoRecursiveSearch(int[] array, int maxElement, int index)
        {
            if (index < array.Length)
            {
                if (array[index] > maxElement)
                    maxElement = array[index];

                return this.DoRecursiveSearch(array, maxElement, ++index);
            }
            else
                return maxElement;
        }

        private bool[] ConvertNumberToBitArray(int number)
        {
            var bitArray = new bool[BitsCount];
            var index = BitsCount;

            if (number < 0)
            {
                number *= -1;
                bitArray[0] = true;
            }

            do
            {
                index--;

                if (index == 0)
                    break;

                bitArray[index] = number % 2 == 1;
                number /= 2;
            }
            while (number != 0);

            return bitArray;
        }

        private int ConvertBitArrayToNumber(bool[] array)
        {
            int result = 0;

            for (int i = 1; i < BitsCount; i++)
            {
                if (array[i])
                    result += Convert.ToInt32(Math.Pow(2, BitsCount - i - 1));
            }

            if (array[0])
                result *= -1;

            return result;
        }
    }
}
