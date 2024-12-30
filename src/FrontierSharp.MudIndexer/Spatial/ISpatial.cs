namespace FrontierSharp.MudIndexer;

public interface ISpatial<out T> {
    public T X { get; }
    public T Y { get; }
    public T Z { get; }
}