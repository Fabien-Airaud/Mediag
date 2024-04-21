namespace Mediag.Models
{
    public class ThalassemiaTypes : SimpleEnum
    {
        public static ICollection<ThalassemiaTypes> GetThalassemiaTypes()
        {
            MediagDbContext mediagDbContext = new();
            return [.. mediagDbContext.ThalassemiaTypes]; // Copy the collection
        }
    }
}
