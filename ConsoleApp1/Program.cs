
    Console.WriteLine("Start MainAsync");

    await someAsyncMethod1();
    Console.WriteLine("someAsyncMethod1 completed");

    Task task2 = someAsyncMethod2();
    Task task3 = someAsyncMethod3();

    await Task.WhenAll(task2, task3);
    Console.WriteLine("someAsyncMethod2 and someAsyncMethod3 completed");

    Console.WriteLine("End MainAsync");


async Task someAsyncMethod1()
{
    Console.WriteLine("Start someAsyncMethod1");
    //Task.Delay(10000);
    await Task.Delay(10000); // Simulating an asynchronous operation that takes 2 seconds
    Console.WriteLine("End someAsyncMethod1");
}

async Task someAsyncMethod2()
{
    Console.WriteLine("Start someAsyncMethod2");
    await Task.Delay(10000); // Simulating an asynchronous operation that takes 10 seconds
    Console.WriteLine("End someAsyncMethod2");
}

async Task someAsyncMethod3()
{
    Console.WriteLine("Start someAsyncMethod3");
    await Task.Delay(1500); // Simulating an asynchronous operation that takes 1.5 seconds
    Console.WriteLine("End someAsyncMethod3");
}