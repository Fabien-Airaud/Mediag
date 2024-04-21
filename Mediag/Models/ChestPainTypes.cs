namespace Mediag.Models
{
    public class ChestPainTypes : SimpleEnum
    {
        public static ICollection<ChestPainTypes> GetChestPainTypes()
        {
            MediagDbContext mediagDbContext = new();
            return [.. mediagDbContext.ChestPainTypes]; // Copy the collection
        }
    }
}
