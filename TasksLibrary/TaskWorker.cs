using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TasksLibrary
{
    public class TaskWorker
    {
        /// <summary>
        /// Method for searching the maximum element of array
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
        /// Method for recursively searching the maximum element of array
        /// </summary>
        /// <param name="array">Array in which we search maximum</param>
        /// <param name="maxElement">Current maximum element of the array</param>
        /// <param name="index">Index of current max element</param>
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
    }
}
