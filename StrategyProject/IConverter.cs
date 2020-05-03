namespace StrategyProject
{
    /// <summary>
    /// Interface for converting
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IConverter<T>
    {
        string ConvertFrom(T element);
    }
}
