namespace Mediag.Models
{
    public class MajorVesselsTypes : SimpleEnum
    {
        public static ICollection<MajorVesselsTypes> GetMajorVesselsTypes()
        {
            MediagDbContext mediagDbContext = new();
            return [.. mediagDbContext.MajorVesselsTypes]; // Copy the collection
        }
    }
}
