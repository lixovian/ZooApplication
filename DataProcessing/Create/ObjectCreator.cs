namespace DataProcessing.Create;

public abstract class ObjectCreator<TCreator>
{
    public TCreator GetCreator(string type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        
        return GetTypes()[type];
    }
    
    protected abstract Dictionary<string, TCreator> GetTypes();

    public abstract string[] GetNames();
}