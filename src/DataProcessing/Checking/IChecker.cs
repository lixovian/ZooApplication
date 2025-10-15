namespace DataProcessing.Checking;

public interface IChecker<in T>
{
    public bool Check(T obj);
}
