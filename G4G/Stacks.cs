using System;
using System.Collections.Generic;

namespace G4G
{
    class Stacks
    {
        public static void PrintReverse(Stack<int> stack)
        {
            if (stack.Count == 0) return;
            var pop = stack.Pop();
            PrintReverse(stack);
            Console.Write(pop + " ");
        }

        /*
         Find next greater element. O(n)+ space O(n)
         * [4,5,2,25]
         * output
         * 4 -- 5
         * 5 -- 25
         * 2 -- 25
         * 25 -- -1
         */

        public static void NextGreaterElement(int[] arr)
        {
            var stack = new Stack<int>();
            stack.Push(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                int elem, next;

                next = arr[i];

                if (stack.Count > 0)
                {
                    elem = stack.Pop();

                    while (elem < next)
                    {
                        Console.WriteLine("{0} ==> {1} ", elem, next);
                        if (stack.Count == 0) break;
                        next = stack.Pop();
                    }

                    if (elem > next) stack.Push(next);

                }
                else stack.Push(next);
            }


            while (stack.Count != 0) Console.WriteLine(stack.Pop() + "-->-1");
        }
    }
}
