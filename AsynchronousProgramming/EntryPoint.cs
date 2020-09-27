using System;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class EntryPoint
    {
        static void Main()
        {
            int count = 200000;
            char charToConcatenate = '1';

            Task t = new Task(ConcatenateChars);

            t.Start();
            Console.WriteLine("In progress");

            t.Wait();
            Console.WriteLine("Completed");

            // Asynchronous call of the async ConcatenateChars method
            Task<string> t1 = ConcatenateCharsAsync(charToConcatenate, count);

            // This line of code will be executed asynchronously
            Console.WriteLine("In progress");
                       
            Console.WriteLine("The length of the result is " + t1.Result.Length);

            // Normal Synchronous Call of the ConcatenateChars method
            ConcatenateChars(charToConcatenate, count);
        }


        public static void  ConcatenateChars()
        {
            string concatenatedString = string.Empty;

            for (int i = 0; i < 200000; i++)
            {
                concatenatedString += '1';
            }

        }

        public static string ConcatenateChars(char charToConcatenate, int count)
        {
            string concatenatedString = string.Empty;

            for (int i = 0; i < count; i++)
            {
                concatenatedString += charToConcatenate;
            }

            return concatenatedString;
        }

        public async static Task<string> ConcatenateCharsAsync(char charToConcatenate, int count)
        {
            return await Task<string>.Factory.StartNew(() =>
            {
                return ConcatenateChars(charToConcatenate, count);
            });
        }
    }
}