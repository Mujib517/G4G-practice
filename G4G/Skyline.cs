using System;
using System.Linq;

namespace G4G
{
    public class Skyline
    {

        /*
         *  Console.WriteLine(ComputeNumberOfStrokes(skyline1));
            Console.WriteLine(ComputeNumberOfStrokes(skyline2));
            Console.WriteLine(ComputeNumberOfStrokes(skyline3));

            Console.WriteLine(GetStrokeCount(skyline1));
            Console.WriteLine(GetStrokeCount(skyline2));
            Console.WriteLine(GetStrokeCount(skyline3));
         * */

        //method 1
        public static int ComputeNumberOfStrokes(int[] skyline)
        {
            const int MAX = 1000000001;
            var strokes = skyline.Zip(skyline.Skip(1), (a, b) => b - a)
                                   .Where(d => d > 0)
                                   .Aggregate(skyline[0], (a, b) => Math.Min(a + b, MAX));
            return strokes >= MAX ? -1 : strokes;
        }

        //method 2
        public static int GetStrokeCount(int[] skyline)
        {
            var currentLevel = 0;
            var strokes = 0;

            foreach (var currentHeight in skyline)
            {
                if (currentHeight > currentLevel)
                {
                    var extraStrokes = currentHeight - currentLevel;
                    strokes += extraStrokes;
                    currentLevel = currentHeight;
                }
                else if (currentHeight < currentLevel)
                    currentLevel = currentHeight;
            }
            return strokes > 1000000000 ? -1 : strokes;
        }
    }
}
