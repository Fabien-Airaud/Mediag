﻿using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Mediag.Models
{
    internal class ResultConverter : TypeConverter<bool>
    {
        public override bool ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            text = text.ToLower();

            if (text == "b" || text == "benign" || text == "f" || text == "false") return false;
            return true;
        }

        public override string ConvertToString(bool value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.ToString();
        }
    }


    public class BreastCancerMap : ClassMap<BreastCancerData>
    {
        public BreastCancerMap()
        {
            Map(m => m.RadiusWorst).Index(0).Name("RadiusWorst", "radiusworst", "radius_worst", "radius worst");
            Map(m => m.AreaWorst).Index(1).Name("AreaWorst", "areaworst", "area_worst", "area worst");
            Map(m => m.PerimeterWorst).Index(2).Name("PerimeterWorst", "perimeterworst", "perimeter_worst", "perimeter worst");
            Map(m => m.ConcavePointsWorst).Index(3).Name("ConcavePointsWorst", "concavepointsworst", "concave_points_worst", "concave points_worst", "concave_points worst", "concave points worst");
            Map(m => m.ConcavePointsMean).Index(4).Name("ConcavePointsMean", "concavepointsmean", "concave_points_mean", "concave points_mean", "concave_points mean", "concave points mean");
            Map(m => m.PerimeterMean).Index(5).Name("PerimeterMean", "perimetermean", "perimeter_mean", "perimeter mean");
            Map(m => m.Result).Index(6).Name("Result", "result", "Diagnosis", "diagnosis").TypeConverter(new ResultConverter());
        }
    }
}
