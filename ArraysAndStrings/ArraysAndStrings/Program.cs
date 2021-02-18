using System;
using System.Collections;

namespace ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Array is a data structure consisting of a collection of elements, each identified by an index.
            The simplest type of this data structure is a linear array, also called one-dimensional array.

            It means that accessing an element in the array by its index is an O(1) runtime operation.

            But how can we calculate the element position in the array from its index?
             */

            /*
                Imagine that the computer emmory is organized as a continuous sequence of cells, and each cell has an address.

                Imagine that each element in the array occupies one cell in memory, and the array itself does mpt jave amu additional information.

                If there is additional data for the array, or an array element takes more than one memory cell, it just changes the formula.
                The idea remains the same - we can calculate the item location in memory (which looks like an array as well!)

                The drawback is that an array has to occupy a continuous space inside the memory

                We cannot create an array of 4 elements, though there are 5 elements free

             */

            /*
                Multi-dimensional arrays have more than one index

                int[] x = new int[10];
                int a = x[4];

                int[,] y = new int[2, 3];
                int b = y[0, 2];


                // l = 2*3 = 6
                int l = y.Length;



                Jagged arrays are different. They are arrays of arrays.

                int[][] y = new int[2][];
                y[0] = new int[3];

                int b = y[0][2];
                // y.Length is 2
                // l = 3
                int l = y[0].Length;

                // null reference excetion
                l = y[1].Length;

                
             */

            ArrayTest();

        }


        static void ArrayTest()
        {
            int[] array = new int[] { 1, 2, 3 };

            Console.WriteLine(array);
            array[1] = 10;
            Console.WriteLine(array);

            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // A multi-dimensional array, 2D space,
            // a table in this case
            int[,] a =
            {
                    { 1, 2, 3 },
                    { 4, 5, 6 }
                };

            Console.WriteLine($"A multi-dimensional array length: {a.Length}");

            // A jagged array. It's an arary of arrays, so you
            // need to initialize nested arrays afterwards

            int[][] b =
            {
                    new int[] { 1, 2, 3 },
                    new int[] { 10, 20, 30, 40, 50 },
                    new int[] {5, 6}
                };



            Console.WriteLine($"The jagged array length: {b.Length}");
            Console.WriteLine($"The nested array length: {b[1].Length}");

            // an element in the first row, first column
            a[0, 0] = 10;

            // The first element's first element
            b[0][0] = 10;

            int[][][] c = new int[2][][];
            // int[2][2][2] or int[2][2][] is not possible
            // you can initialize only the first rank
            // Also, nested arrays are not initialized,
            // c[0].Length will give null reference exception

        }


    }
}
