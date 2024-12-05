using System.Collections.Concurrent;

namespace ConcurrentCollections._02;


internal enum TShirtStatus { Success, NoStockLeft, ChosenShirtSold };
internal class StockController
{
    private ConcurrentDictionary<string, TShirt> _stock;

    public StockController(IEnumerable<TShirt> shirts)
    {
        _stock = new ConcurrentDictionary<string, TShirt>(shirts.ToDictionary(x => x.Code));
    }

    public bool Sell(string code)
    {
      return  _stock.TryRemove(code, out TShirt removedShirt);
    }
    public (TShirtStatus Status, TShirt TShirt) SelectRandomShirt()
    {

        var keys = _stock.Keys.ToList();
        if (keys.Count == 0) return (TShirtStatus.NoStockLeft, TShirt.Empty);

        Thread.Sleep(Random.Shared.Next(10));
        var selectedCode = keys[Random.Shared.Next(keys.Count)];

        // return _stock[selectedCode];
        var hasTShirt = _stock.TryGetValue(selectedCode, out TShirt shirt);
        if (hasTShirt) return (TShirtStatus.Success, shirt);
        return (TShirtStatus.ChosenShirtSold, TShirt.Empty);
    }

    public void DisplayStock()
    {
        Console.WriteLine($"\r\n{_stock.Count} items left in stock;");
        foreach (TShirt shirt in _stock.Values)
        {
            Console.WriteLine(shirt);
        }
    }
}