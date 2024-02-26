namespace Mediag.Medical
{
    enum ChestPainTypes { TypicalAngina, AtypicalAngina, NonAnginalPain, Asymptomatic }

    enum ThalassemiaTypes { Normal, Fixed, Reversable }

    enum MajorVesselsTypes { Zero, One, Two, Three }

    class HeartDiseaseData : IMedicalData
    {
        private static long lastId = 0;

        public long Id { get; protected set; } = ++lastId;

        public bool Result { get; set; }


        public HeartDiseaseData() { }

        public HeartDiseaseData(bool result)
        {
            Result = result;
        }


        public IllnessTypes TargettedIllness() { return IllnessTypes.BreastCancer; }

        public string[] Values()
        {
            return [Result.ToString()];
        }

        public string[] Labels()
        {
            return ["Result"];
        }
    }
}
