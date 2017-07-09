using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4G
{
    class Arrays
    {
        /*
         
         * 1. Missing elements 
         * 2. Odd number of times occurence
         * 3. Majority Occurence Element
         * 4. search an element in rotated array in O(Log n)
         * 5. Reverse an array
         * 6. Seggregate 0s and 1s
         */


        /// <summary>
        /// Find missing element from consecutive array
        /// input [1,2,,4,5,6,7]
        /// output 3
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>missing element</returns>
        public static int MissingElement(int[] arr)
        {
            //method 1
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    if (arr[i] < arr[i - 1]) return arr[i - 1] + 1;
            //}
            // return -1;

            //method2 
            // calcualte total using n*n+1/2 and negate actual total
            //int total = (arr.Length * (arr.Length + 1)) / 2;
            //int actualTotal = 0;

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    actualTotal += arr[i];
            //}

            //return total - actualTotal;


            //method3
            //use xor
            // xor of all elements of array X1
            // xor all all elements till n X2
            // result is X1^X2

            var x1 = arr[0];
            var x2 = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                x1 ^= arr[i];
            }

            for (int i = 2; i < arr.Length + 1; i++)
            {
                x2 ^= i;
            }

            return x1 ^ x2;
        }

        /// <summary>
        /// input [1,2,3,2,3,1,3]
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int OddOccurence(int[] arr)
        {
            //best solution
            //use XOR. XOR of two same numbers is zero. ex: 123^123=0
            // XOR of 123^0=123 (which helps to find odd occurence)
            var x = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                x ^= arr[i];
            }
            return x;


            //Method 2: O(n^2) solution with two loops ....

            //Method 3: O(n) solution with O(n) extra space. use dictionary
        }

        /// <summary>
        /// Majority occurence if it occurs more than n/2 times
        /// input [3, 3, 4, 2, 4, 4, 2, 4, 4 ]
        /// output 4
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int MajorityOccurence(int[] arr)
        {
            var n = arr.Length;
            //method 1: O(n) time and O(n) space. Use dictionary
            //method 2: O(n^2) time run two loops

            //method 3: Moore's voting algorithm
            //O(N) and O(1) space

            int cnt = 1, maj_inx = 0;

            for (int i = 1; i < n; i++)
            {
                if (arr[maj_inx] == arr[i])
                {
                    cnt++;
                    maj_inx = i;
                }
                else cnt--;

                if (cnt == 0)
                {
                    maj_inx = i;
                    cnt = 1;
                }
            }

            //step 2 verify if the maj_index is really occuring n/2 times

            var occurence = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[maj_inx] == arr[i]) occurence++;
            }

            return occurence > n / 2 ? arr[maj_inx] : -1;
        }

        //incomplete
        /// <summary>
        /// Use binary search. Before search find the pivot point
        /// original array: [1,2,3,4,5] ==> rotated array==> [3,4,5,1,2]
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindInRotatedArr(int[] arr, int key)
        {
            var pivot = FindPivot(arr, 0, arr.Length);

            if (arr[pivot] == key) return pivot;
            if (arr[pivot] <= key) return BinarySearch(arr, 0, pivot - 1, key);
            return BinarySearch(arr, pivot + 1, arr.Length, key);

        }

        /// <summary>
        /// Reverse an array
        /// input new []{1,2,3,4,5}
        /// output {5,4,3,2,1}
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Reverse(int[] arr)
        {
            //method 1: O(n)+ O(n) space using recursion
            //var n = arr.Length;
            //var newArr = new int[n];
            //return Reverse(arr, newArr, arr.Length - 1);

            //method 2: calculate mid and swap elements. Similar to palindrome
            //O(n/2) and O(1) space
            var n = arr.Length;
            var mid = n / 2;

            for (int i = 0; i < mid; i++)
            {
                var temp = arr[i];
                arr[i] = arr[n - i - 1];
                arr[n - i - 1] = temp;
            }

            return arr;
        }

        /// <summary>
        /// input [1,0,1,1,0,0,1,0,1]
        /// output [0,0,0,0,1,1,1,1,1]
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Seggregate(int[] arr)
        {
            var left = 0;
            var right = arr.Length - 1;

            while (left < right)
            {
                if (arr[left] == 0) left++;
                if (arr[right] == 1) right--;
                if (arr[left] > arr[right])
                {
                    var temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }
            }

            return arr;
        }

        private static int[] Reverse(int[] arr, int[] newArr, int index)
        {
            if (index < 0) return newArr;
            newArr[arr.Length - 1 - index] = arr[index];
            index--;
            return Reverse(arr, newArr, index);
        }

        private static int BinarySearch(int[] arr, int start, int end, int key)
        {
            if (start < end) return -1;
            var mid = (start + end) / 2;
            if (arr[mid] == key) return mid;
            if (arr[mid] > key) return BinarySearch(arr, mid + 1, end, key);
            return BinarySearch(arr, start, mid - 1, key);
        }

        private static int FindPivot(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                if (mid < end - 1 && arr[mid] > arr[mid + 1]) return mid;
                if (mid < end - 1 && arr[mid] < arr[mid + 1]) return FindPivot(arr, mid + 1, end);
                return FindPivot(arr, start, mid + 1);
            }
            return -1;
        }
    }
}
