namespace Mediag.Medical
{
    enum ChestPainTypes { TypicalAngina, AtypicalAngina, NonAnginalPain, Asymptomatic }

    enum ThalassemiaTypes { Strange, Normal, Fixed, Reversable }

    enum MajorVesselsTypes { Zero, One, Two, Three, Four }

    class HeartDiseaseData : IMedicalData
    {
        private static long lastId = 0;

        public long Id { get; protected set; } = ++lastId;

        public ChestPainTypes ChestPain { get; set; }

        public ThalassemiaTypes Thalassemia { get; set; }

        public MajorVesselsTypes MajorVessels { get; set; }

        public double OldPeak { get; set; }

        public int MaximumHeartRateAchieved { get; set; }

        public bool Result { get; set; }


        public HeartDiseaseData() { }

        public HeartDiseaseData(ChestPainTypes chestPain, ThalassemiaTypes thalassemia, MajorVesselsTypes majorVessels, double oldPeak, int maximumHeartRateAchieved, bool result)
        {
            ChestPain = chestPain;
            Thalassemia = thalassemia;
            MajorVessels = majorVessels;
            OldPeak = oldPeak;
            MaximumHeartRateAchieved = maximumHeartRateAchieved;
            Result = result;
        }


        public IllnessTypes TargettedIllness() { return IllnessTypes.BreastCancer; }

        public string[] Values()
        {
            return [ ChestPain.ToString(), Thalassemia.ToString(), MajorVessels.ToString(), OldPeak.ToString(), MaximumHeartRateAchieved.ToString(), Result.ToString()];
        }

        public string[] Labels()
        {
            return ["ChestPain", "Thalassemia", "MajorVessels", "OldPeak", "MaximumHeartRateAchieved", "Result"];
        }
    }
}
