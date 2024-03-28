using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Class1
    {
        async Task someAsyncMethod1()
        {
            Console.WriteLine("Start someAsyncMethod1");
            await Task.Delay(2000); // Simulating an asynchronous operation that takes 2 seconds
            Console.WriteLine("End someAsyncMethod1");
        }

        async Task someAsyncMethod2()
        {
            Console.WriteLine("Start someAsyncMethod2");
            await Task.Delay(3000); // Simulating an asynchronous operation that takes 3 seconds
            Console.WriteLine("End someAsyncMethod2");
        }

        async Task someAsyncMethod3()
        {
            Console.WriteLine("Start someAsyncMethod3");
            await Task.Delay(1500); // Simulating an asynchronous operation that takes 1.5 seconds
            Console.WriteLine("End someAsyncMethod3");
        }
    }
}
