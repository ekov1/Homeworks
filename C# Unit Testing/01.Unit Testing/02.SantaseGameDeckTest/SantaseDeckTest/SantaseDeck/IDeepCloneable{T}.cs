namespace SantaseDeck.Logic
{
    public interface IDeepCloneable<out T>
    {
        T DeepClone();
    }
}
