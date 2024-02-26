namespace Mediag.Medical
{
    class BreastCancerData : IMedicalData
    {
        private static long lastId = 0;

        public long Id { get; protected set; } = ++lastId;

        public double RadiusWorst { get; set; }

        public double AreaWorst { get; set; }

        public double PerimeterWorst { get; set; }

        public double ConcavePointsWorst { get; set; }

        public double ConcavePointsMean { get; set; }

        public double PerimeterMean { get; set; }

        public bool Result { get; set; }


        public BreastCancerData() { }

        public BreastCancerData(double radiusWorst, double areaWorst, double perimeterWorst, double concavePointsWorst, double concavePointsMean, double perimeterMean, bool result)
        {
            RadiusWorst = radiusWorst;
            AreaWorst = areaWorst;
            PerimeterWorst = perimeterWorst;
            ConcavePointsWorst = concavePointsWorst;
            ConcavePointsMean = concavePointsMean;
            PerimeterMean = perimeterMean;
            Result = result;
        }


        public static IllnessTypes TargettedIllness() { return IllnessTypes.BreastCancer; }

        public string[] Values()
        {
            return [RadiusWorst.ToString(), AreaWorst.ToString(), PerimeterWorst.ToString(), ConcavePointsWorst.ToString(), ConcavePointsMean.ToString(), PerimeterMean.ToString(), Result.ToString()];
        }

        public string[] Labels()
        {
            return ["RadiusWorst", "AreaWorst", "PerimeterWorst", "ConcavePointsWorst", "ConcavePointsMean", "PerimeterMean", "Result"];
        }
    }
}
