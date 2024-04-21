using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Mediag.Models
{
    internal class ChestPainConverter : TypeConverter<ChestPainTypes>
    {
        public override ChestPainTypes ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            ChestPainTypes? chestPain;
            if (long.TryParse(text, out long id)) chestPain = ChestPainTypes.GetChestPainType(id + 1); // +1 because the id starts from 1
            else chestPain = ChestPainTypes.GetChestPainType(text);
            return chestPain ?? throw new CsvHelperException(row.Context, $"Invalid chest pain type: {text}");
        }

        public override string ConvertToString(ChestPainTypes value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.Name;
        }
    }
    
    internal class ThalassemiaConverter : TypeConverter<ThalassemiaTypes>
    {
        public override ThalassemiaTypes ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            ThalassemiaTypes? thalassemia;
            if (long.TryParse(text, out long id)) thalassemia = ThalassemiaTypes.GetThalassemiaType(id + 1); // +1 because the id starts from 1
            else thalassemia = ThalassemiaTypes.GetThalassemiaType(text);
            return thalassemia ?? throw new CsvHelperException(row.Context, $"Invalid thalassemia type: {text}");
        }

        public override string ConvertToString(ThalassemiaTypes value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.Name;
        }
    }
    
    internal class MajorVesselsConverter : TypeConverter<MajorVesselsTypes>
    {
        public override MajorVesselsTypes ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            MajorVesselsTypes? majorVessels;
            if (long.TryParse(text, out long id)) majorVessels = MajorVesselsTypes.GetMajorVesselsType(id + 1); // +1 because the id starts from 1
            else majorVessels = MajorVesselsTypes.GetMajorVesselsType(text);
            return majorVessels ?? throw new CsvHelperException(row.Context, $"Invalid major vessels type: {text}");
        }

        public override string ConvertToString(MajorVesselsTypes value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.Name;
        }
    }

    public class HeartDiseaseMap : ClassMap<HeartDiseaseData>
    {
        public HeartDiseaseMap()
        {
            Map(m => m.ChestPain).Index(0).Name("cp").TypeConverter(new ChestPainConverter());
            Map(m => m.Thalassemia).Index(1).Name("thal").TypeConverter(new ThalassemiaConverter());
            Map(m => m.MajorVessels).Index(2).Name("ca").TypeConverter(new MajorVesselsConverter());
            Map(m => m.OldPeak).Index(3).Name("oldpeak");
            Map(m => m.MaximumHeartRateAchieved).Index(4).Name("thalach");
            Map(m => m.Result).Index(5).Name("target");
        }
    }
}
