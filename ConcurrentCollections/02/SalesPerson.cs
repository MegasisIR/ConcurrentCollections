namespace ConcurrentCollections._02;

internal class SalesPerson
{
    public string Name { get; }

    public SalesPerson(string name)
    {
        this.Name = name;
    }

    public void Work(TimeSpan workDay, StockController controller)
    {
        DateTime startTime = DateTime.Now;
        while (DateTime.Now - startTime < workDay)
        {
            var result = ServeCustomer(controller);
            if (result is { Status: "" })
                Console.WriteLine($"{Name}: {result.Status}");
            if (result is { ShirtsInStock: false })
                break;
        }
    }

    public (bool ShirtsInStock, string Status) ServeCustomer(
        StockController controller)
    {
        var result = controller.SelectRandomShirt();
        TShirt shirt = result.TShirt;
        if (result is { Status: TShirtStatus.NoStockLeft })
            return (false, "All shirts sold");
        else if (result is { Status: TShirtStatus.ChosenShirtSold })
            return (true, "Can't show shirt to customer - already sold");
        Thread.Sleep(Random.Shared.Next(30));

        // customer chooses to buy with only 20% probability
        if (Random.Shared.NextDouble() < (0.2))
        {
            bool sold = controller.Sell(shirt.Code);
            if (sold)
                return (true, $"Sold {shirt.Name}");
            return (false, $"Can't sell {shirt.Name}: already sold");
        }

        return (true, string.Empty);
    }


}