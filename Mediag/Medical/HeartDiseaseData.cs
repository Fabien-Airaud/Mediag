namespace Mediag.Medical
{
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


        public static IllnessTypes TargettedIllness() { return IllnessTypes.BreastCancer; }

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
