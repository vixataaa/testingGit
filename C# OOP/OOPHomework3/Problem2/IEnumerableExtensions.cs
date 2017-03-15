using System;
using System.Collections.Generic;

namespace Problem2
{
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> enumerable)
        {
            T sum = (dynamic)0;

            foreach (T item in enumerable)
            {
                sum += (dynamic)item;
            }

            return sum;
        }//Sum extension

        public static T Product<T>(this IEnumerable<T> enumerable)
        {
            T product = (dynamic)1;

            foreach (T item in enumerable)
            {
                product *= (dynamic)item;
            }

            return product;
        }//Product extension

        public static T Min<T>(this IEnumerable<T> enumerable)
            where T : IComparable<T>
        {
            T min = (dynamic)int.MaxValue;

            foreach (var item in enumerable)
            {
                if(item.CompareTo(min) == -1)
                {
                    min = item;
                }
            }

            return min;
        }//Min extension

        public static T Max<T>(this IEnumerable<T> enumerable)
    where T : IComparable<T>
        {
            T max = (dynamic)int.MinValue;

            foreach (var item in enumerable)
            {
                if (item.CompareTo(max) == 1)
                {
                    max = item;
                }
            }

            return max;
        }//Max extension

        public static double Average<T>(this IEnumerable<T> enumerable)
        {
            int elementsCount = 0;
            double sum = 0;

            foreach (T item in enumerable)
            {
                sum += (dynamic)item;
                elementsCount++;
            }

            return (sum / elementsCount);
        }//Average extension

        //using dynamic in order to return the same type
        //ex. the average of List<int> should not be a fractional number
    }
}
