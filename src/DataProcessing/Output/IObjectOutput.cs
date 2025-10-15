namespace DataProcessing.Output;

public interface IObjectOutput<in T>
{
    public string Format(T obj);
}