using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic.IEnumerable;
using System.Runtime.InteropServices;

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




            /*
                Strings look like an array of characters in C#


                However, understanding how strings work in C# is very important, because
                processing strings is what an average program in C# does very often

                C# strings are immutable, which means that any change to a string
                leads to creating a copy of the string

                In the code sample, you will see what can be done the optimize this
             */


            string message = "Hello, World!";

            // string is an arra yof chars
            for(int i = 0; i < message.Length; i++)
            {
                if(i > 6 && i < 12)
                {
                    Console.Write(message[i]);
                }
            }
            Console.WriteLine();

            message = "The number to be parsed is: 123";
            // this creates a new string
            // Substring, Trim, IsNullOrWhitespace will also produce more strings
            string num = message.Substring(message.IndexOf(':') + 2);
            int.TryParse(num, out var a);
            Console.WriteLine(a);

            // this does not create string copies
            ReadOnlySpan<char> msgSpan = message;
            ReadOnlySpan<char> numSpan = msgSpan.Slice(msgSpan.IndexOf(':') + 2);
            int.TryParse(numSpan, out var b);
            Console.WriteLine(b);


            string firstString = "Test string";
            string secondString = "Test string";

            // Prints out true, because of string intern pool
            Console.WriteLine(object.ReferenceEquals(firstString, secondString)); 

            // The following is not possible, the api gives
            // only ReadOnlySpan and ReadOnlyMemory
            // Span<char> span = firstString.AsSpan();
            // Memory<char> mem = firstString.AsMemory();

            // Only use this approach when you know what you are doing
            // and aware of the consequences
            Memory<char> mem = MemoryMarshal.AsMemory(firstString.AsMemory());
            mem.Span[5] = 'Z';



            Console.WriteLine(firstString);
            Console.WriteLine(secondString);


            // Use stringbuilder or memory buffers if you need
            // to concatenate lots of strings

            var sb = new StringBuilder();
            foreach(int i in Enumerable.Range(1, 10))
            {
                sb.Append(i.ToString());
            }


            Console.WriteLine(sb.ToString());


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
