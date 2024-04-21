namespace Mediag.Models
{
    public class IllnessTypes : SimpleEnum
    {
        public static ICollection<IllnessTypes> GetIllnessTypes()
        {
            MediagDbContext mediagDbContext = new();
            return [.. mediagDbContext.IllnessTypes]; // Copy the collection
        }

        public static IllnessTypes? GetIllnessType(long id)
        {
            MediagDbContext mediagDbContext = new();
            return mediagDbContext.IllnessTypes.Find(id);
        }

        public static IllnessTypes? GetIllnessType(string name)
        {
            MediagDbContext mediagDbContext = new();
            return mediagDbContext.IllnessTypes.FirstOrDefault(i => i.Name == name);
        }
    }
}
