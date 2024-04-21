namespace Mediag.Models
{
    public class ChestPainTypes : SimpleEnum
    {
        public static ICollection<ChestPainTypes> GetChestPainTypes()
        {
            MediagDbContext mediagDbContext = new();
            return [.. mediagDbContext.ChestPainTypes]; // Copy the collection
        }

        public static ChestPainTypes? GetChestPainType(long id)
        {
            MediagDbContext mediagDbContext = new();
            return mediagDbContext.ChestPainTypes.Find(id);
        }

        public static ChestPainTypes? GetChestPainType(string name)
        {
            MediagDbContext mediagDbContext = new();
            return mediagDbContext.ChestPainTypes.FirstOrDefault(i => i.Name == name);
        }
    }
}
