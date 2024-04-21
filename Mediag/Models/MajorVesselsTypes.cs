namespace Mediag.Models
{
    public class MajorVesselsTypes : SimpleEnum
    {
        public static ICollection<MajorVesselsTypes> GetMajorVesselsTypes()
        {
            MediagDbContext mediagDbContext = new();
            return [.. mediagDbContext.MajorVesselsTypes]; // Copy the collection
        }

        public static MajorVesselsTypes? GetMajorVesselsType(long id)
        {
            MediagDbContext mediagDbContext = new();
            return mediagDbContext.MajorVesselsTypes.Find(id);
        }

        public static MajorVesselsTypes? GetMajorVesselsType(string name)
        {
            MediagDbContext mediagDbContext = new();
            return mediagDbContext.MajorVesselsTypes.FirstOrDefault(i => i.Name == name);
        }
    }
}
