using System;
using System.Linq;
using System.Collections.Generic;

namespace Hermes
{
    class Algorithm
    {

        // compare objects by their value
        private static bool compareObjects(object leftValue, object rightValue, bool ascending) 
        {
            // check if the left object is smaller than right object based on their datatype
            if (leftValue.GetType() == typeof(string))
            {
                bool result = string.Compare((string)leftValue, (string)rightValue) < 0;
                return ascending ? result : !result;
            }
            else if (leftValue.GetType() == typeof(int))
            {
                bool result = (int)leftValue < (int)rightValue;
                return ascending ? result : !result;
            }
            else if (leftValue.GetType() == typeof(ulong))
            {
                bool result = (ulong)leftValue < (ulong)rightValue;
                return ascending ? result : !result;
            }
            else if (leftValue.GetType() == typeof(float))
            {
                bool result = (float)leftValue < (float)rightValue;
                return ascending ? result : !result;
            }
            else if (leftValue.GetType() == typeof(uint))
            {
                bool result = (uint)leftValue < (uint)rightValue;
                return ascending ? result : !result;
            }
            else if (leftValue.GetType() == typeof(DateTime))
            {
                bool result = (DateTime)leftValue < (DateTime)rightValue;
                return ascending ? result : !result;
            }
            else
            {
                return false;
            }
            
        }

        // create merge sort algorithm
        public static List<object> MergeSort(List<object> data, string columnName, bool ascending)
        {
            // if the list is empty or has only one item, return
            if (data.Count <= 1)
            {
                return data;
            }

            // create two lists
            List<object> left = new List<object>();
            List<object> right = new List<object>();

            // split the list into two
            int middle = data.Count / 2;

            // add the first half of the list to the left list
            for (int i = 0; i < middle; i++)
            {
                left.Add(data[i]);
            }

            // add the second half of the list to the right list
            for (int i = 0; i < data.Count - middle; i++)
            {
                right.Add(data[middle + i]);
            }

            // sort the left list
            left = MergeSort(left, columnName, ascending);

            // sort the right list
            right = MergeSort(right, columnName, ascending);

            // merge the two lists
            List<object> sorted = new List<object>();
            int leftCounter = 0;
            int rightCounter = 0;

            while (leftCounter < left.Count && rightCounter < right.Count)
            {
                // get the values from both sides
                object leftValue = left[leftCounter].GetType().GetProperty(columnName).GetValue(left[leftCounter], null);
                object rightValue = right[rightCounter].GetType().GetProperty(columnName).GetValue(right[rightCounter], null);

                // if the left item is less than the right item
                if (compareObjects(leftValue, rightValue, ascending))
                {
                    // add the left item to the sorted list
                    sorted.Add(left[leftCounter]);
                    leftCounter++;
                }
                else
                {
                    // add the right item to the sorted list
                    sorted.Add(right[rightCounter]);
                    rightCounter++;
                }
            }

            // add the remaining items to the sorted list
            while (leftCounter < left.Count)
            {
                sorted.Add(left[leftCounter]);
                leftCounter++;
            }

            while (rightCounter < right.Count)
            {
                sorted.Add(right[rightCounter]);
                rightCounter++;
            }

            // return the sorted list
            return sorted;
            
        }

    }
}
