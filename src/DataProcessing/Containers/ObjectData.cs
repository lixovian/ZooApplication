using DataProcessing.Checking;

namespace DataProcessing.Containers;

public abstract class ObjectData<T>
{
    private List<T> _data = new();

    public bool Add(T obj)
    {
        if (!IsDataValid(obj))
        {
            return false;
        }
        
        _data.Add(obj);
        return true;
    }

    public bool Remove(T obj)
    {
        return _data.Remove(obj);
    }
    
    public T At(int n)
    {
        return _data[n];
    }
    
    public List<T> GetAll()
    {
        return _data;
    }

    protected abstract bool IsDataValid(T obj);

    public List<T> GetFilterData(IChecker<T> checker)
    {
        return _data.Where(checker.Check).ToList();
    }
}