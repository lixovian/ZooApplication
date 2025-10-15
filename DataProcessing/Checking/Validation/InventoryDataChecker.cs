using System.Text.RegularExpressions;
using AnimalLibrary;
using AnimalLibrary.Items.Properties;

namespace DataProcessing.Checking.Validation;

public class InventoryDataChecker : IChecker<IInventory>
{
// regex проверки на то, соответствует ли строка шаблону (АА#000)
    private const string RegexString = @"^[A-Z]{2}#\d{3}$";
    private readonly Regex _regex = new(RegexString);

    public bool Check(IInventory obj)
    {
        if (obj.Number > 100 || obj.Number < 0)
        {
            return false;
        }

        if (obj is IHasName { ItemName.Length: > 50 or 0 })
        {
            return false;
        }

        if (_regex.Matches(obj.Id).Count == 0)
        {
            return false;
        }

        return true;
    }
}