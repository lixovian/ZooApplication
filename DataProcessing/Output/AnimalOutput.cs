using System.Text;
using AnimalLibrary.Animals;

namespace DataProcessing.Output;

public class AnimalOutput : IObjectOutput<Animal>
{
    public string Format(Animal obj)
    {
        StringBuilder sb = new();

        sb.AppendLine($"{obj.GetTypeName()} - {obj.Name} ({obj.Age} лет)");
        sb.AppendLine($"Нуждается в {obj.FoodNeeded} кг еды");
        sb.AppendLine(obj.IsNeutered ? "Животное кастрировано" : "Животное не кастрировано");

        if (obj is Herbo herbo)
        {
            sb.AppendLine($"Доброта - {herbo.Kindness}");
        }

        return sb.ToString();
    }
}