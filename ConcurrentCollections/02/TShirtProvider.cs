using System.Collections.Immutable;

namespace ConcurrentCollections._02;

internal static class TShirtProvider
{
    public static ImmutableArray<TShirt> AllShirt => [
        new ("igeek","IGeek",500),
        new ("bigdata","Big Data",600),
        new ("ilovenode","I Love Node",750),
        new ("kcdc","kcdc",400),
        new ("docker","Docker",350),
        new ("qcon","QCon",300),
        new ("ps","PluralSight",60000),
        new ("pslive","PluralSight Live",60000),
    ];
}