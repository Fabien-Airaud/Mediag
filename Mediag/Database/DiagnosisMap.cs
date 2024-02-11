using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Mediag.Medical;

namespace Mediag.Database
{
    internal class ResultConverter : TypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text == "B") return false;
            if (text == "M") return true;
            if (text == "false") return false;
            if (text == "true") return true;
            return base.ConvertFromString(text, row, memberMapData);
        }
    }

    class DiagnosisMap : ClassMap<Diagnosis>
    {
        public DiagnosisMap()
        {
            Map(m => m.RadiusWorst).Index(0).Name("radius_worst");
            Map(m => m.AreaWorst).Index(1).Name("area_worst");
            Map(m => m.PerimeterWorst).Index(2).Name("perimeter_worst");
            Map(m => m.ConcavePointsWorst).Index(3).Name("concave_points_worst");
            Map(m => m.ConcavePointsMean).Index(4).Name("concave_points_mean");
            Map(m => m.PerimeterMean).Index(5).Name("perimeter_mean");
            Map(m => m.Result).Index(6).Name("diagnosis").TypeConverter(new ResultConverter());
        }
    }
}
