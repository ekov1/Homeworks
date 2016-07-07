namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    public interface IToothpaste : IProduct
    {
        IEnumerable<string> Ingredients { get; }
    }
}