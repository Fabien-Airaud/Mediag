namespace Mediag.Models
{
    public class IllnessTypes : SimpleEnum
    {
        public static ICollection<IllnessTypes> GetIllnessTypes()
        {
            MediagDbContext mediagDbContext = new();
            return [.. mediagDbContext.IllnessTypes]; // Copy the collection
        }
    }
}
