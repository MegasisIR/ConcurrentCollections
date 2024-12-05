using System.Collections.Concurrent;
namespace ConcurrentCollections._01;
public sealed class CollectionAndAtomicOperators
{

    public void Run()
    {
        Sample1();
        //Sample2();
    }

    private void Sample1()
    {
        Queue<string> orders = [];
        PlaceOrdersSample1(orders, "Mehrdad", 5);
        PlaceOrdersSample1(orders, "Behzad", 5);
        foreach (var order in orders)
        {
            Console.WriteLine($"Order : {order}");
        }
    }

    private void Sample2()
    {
        ConcurrentQueue<string> orders = [];  
        var task1 = Task.Run(() => PlaceOrdersSample2(orders, "Mehrdad", 5));
        var task2 = Task.Run(() => PlaceOrdersSample2(orders, "Behzad", 5));
        Task.WaitAll(task1, task2);
        foreach (var order in orders)
        {
            Console.WriteLine($"Order : {order}");
        }
    }
    private void PlaceOrdersSample1(Queue<string> orders, string customerName, int nOrder)
    {
        for (global::System.Int32 n = 0; n < nOrder; n++)
        {
            Thread.Sleep(new TimeSpan(1));
            string orderName = $"{customerName} wants t-shirt {n}";
            orders.Enqueue(orderName);
        }
    }
    private void PlaceOrdersSample2(ConcurrentQueue<string> orders, string customerName, int nOrder)
    {
        for (global::System.Int32 n = 0; n < nOrder; n++)
        {
            Thread.Sleep(new TimeSpan(100));
            string orderName = $"{customerName} wants t-shirt {n}";
            orders.Enqueue(orderName);
        }
    }
}
