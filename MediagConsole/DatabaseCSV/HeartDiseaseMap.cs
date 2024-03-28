using CsvHelper.Configuration;
using Mediag.Medical;

namespace Mediag.DatabaseCSV
{
    class HeartDiseaseMap : ClassMap<HeartDiseaseData>
    {
        public HeartDiseaseMap()
        {
            Map(m => m.ChestPain).Index(0).Name("cp");
            Map(m => m.Thalassemia).Index(1).Name("thal");
            Map(m => m.MajorVessels).Index(2).Name("ca");
            Map(m => m.OldPeak).Index(3).Name("oldpeak");
            Map(m => m.MaximumHeartRateAchieved).Index(4).Name("thalach");
            Map(m => m.Result).Index(5).Name("target");
        }
    }
}
