using System;
using System.Linq;

namespace TasksLibrary
{
    public class TaskWorker
    {
        private const double Error = 1e-2;

        /// <summary>
        /// Method for searching the maximum element of array.
        /// </summary>
        /// <param name="array">>Array in which we search maximum</param>
        /// <returns>Maximum element of an integer array</returns>
        public int FindMaxElementInArray(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            return DoRecursiveSearch(array, int.MinValue, 0);
        }

        /// <summary>
        /// Method for recursively searching the maximum element of array.
        /// </summary>
        /// <param name="array">Array in which we search maximum</param>
        /// <param name="maxElement">Maximum element of the array</param>
        /// <param name="index">Index of current element</param>
        /// <returns></returns>
        private int DoRecursiveSearch(int[] array, int maxElement, int index)
        {
            if (index < array.Length)
            {
                if (array[index] > maxElement)
                    maxElement = array[index];

                return DoRecursiveSearch(array, maxElement, ++index);
            }
            else
                return maxElement;
        }

        /// <summary>
        /// Method for finding index of element, for which the sum of the elements on the left and right are equal.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int FindElementIndexBetweenEqualSums(double[] array)
        {
            var totalSum = array.Sum();
            var leftSum = 0.0;

            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(totalSum - array[i] - 2 * leftSum) < Error) //difference of the sums on the left and on the right is less than the error
                    return i;
                leftSum += array[i];
            }
            return -1;
        }
    }
}
