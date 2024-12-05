namespace ConcurrentCollections._02;

internal record TShirt(string Code, string Name, int PricePence)
{
    public static TShirt Empty => new(string.Empty, string.Empty, 0);
    public override string ToString()
    {
        return $"{Name} ({DisplayPrice(PricePence)})";
    }

    private string DisplayPrice(int pricePence) => $"{pricePence / 100}.{pricePence % 100:00}";
};