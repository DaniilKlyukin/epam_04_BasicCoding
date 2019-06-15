namespace TasksLibrary
{
    using System;
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
