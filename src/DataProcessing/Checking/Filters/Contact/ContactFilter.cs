using AnimalLibrary.Animals;

namespace DataProcessing.Checking.Filters.Contact;

public class ContactFilter : IContactFilter
{
    public bool Check(Animal obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }
        
        if (obj is not Herbo herbo)
        {
            return false;
        }

        return herbo.Kindness > 5;
    }
}