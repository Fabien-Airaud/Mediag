namespace Mediag.Models
{
    public class ThalassemiaTypes : SimpleEnum
    {
        public static ICollection<ThalassemiaTypes> GetThalassemiaTypes()
        {
            MediagDbContext mediagDbContext = new();
            return [.. mediagDbContext.ThalassemiaTypes]; // Copy the collection
        }

        public static ThalassemiaTypes? GetThalassemiaType(long id)
        {
            MediagDbContext mediagDbContext = new();
            return mediagDbContext.ThalassemiaTypes.Find(id);
        }

        public static ThalassemiaTypes? GetThalassemiaType(string name)
        {
            MediagDbContext mediagDbContext = new();
            return mediagDbContext.ThalassemiaTypes.FirstOrDefault(i => i.Name == name);
        }
    }
}
