namespace ConcurrentCollections._02;

public class FromDictionaryToConcurrentDictionary
{
    public static void Run()
    {
        Sample1();
    }

    private static void Sample1()
    {
        StockController controller = new StockController(TShirtProvider.AllShirt);
        TimeSpan workDay = new TimeSpan(0, 0, 0, 0, 500);
        var task1 = Task.Run(() => { new SalesPerson("Mehrdad").Work(workDay, controller); });
        var task2 = Task.Run(() => { new SalesPerson("Yasin").Work(workDay, controller); });
        var task3 = Task.Run(() => { new SalesPerson("Haniyeh").Work(workDay, controller); });

        Task.WaitAll(task1, task2, task3);

        controller.DisplayStock();
    }
}