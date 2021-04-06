namespace DoubleZ.BoardGames
{
    public interface IPlaceable<T> where T : class, IPlaceable<T>
    {
        Cell<T> Cell { get; set; }
    }
}