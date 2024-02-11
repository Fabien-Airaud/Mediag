using Mediag.DiagnosticDecision;

namespace Mediag.Medical
{
    class Diagnosis : IForDecisionTree
    {
        public long Id { get; set; }

        public double RadiusWorst { get; set; }

        public double AreaWorst { get; set; }

        public double PerimeterWorst { get; set; }

        public double ConcavePointsWorst { get; set; }

        public double ConcavePointsMean { get; set; }

        public double PerimeterMean { get; set; }

        public bool Result { get; set; }


        public Diagnosis() { }

        public Diagnosis(long id, double radiusWorst, double areaWorst, double perimeterWorst, double concavePointsWorst, double concavePointsMean, double perimeterMean, bool result)
        {
            Id = id;
            RadiusWorst = radiusWorst;
            AreaWorst = areaWorst;
            PerimeterWorst = perimeterWorst;
            ConcavePointsWorst = concavePointsWorst;
            ConcavePointsMean = concavePointsMean;
            PerimeterMean = perimeterMean;
            Result = result;
        }


        public object[] Values()
        {
            object[] values = new object[]
            {
                RadiusWorst, AreaWorst, PerimeterWorst, ConcavePointsWorst, ConcavePointsMean, PerimeterMean, Result
            };
            return values;
        }


        public override string ToString()
        {
            string str = "Diagnosis " + Id + ": "
                + RadiusWorst + ", "
                + AreaWorst + ", "
                + PerimeterWorst + ", "
                + ConcavePointsWorst + ", "
                + ConcavePointsMean + ", "
                + PerimeterMean + ", "
                + Result;
            return str;
        }
    }
}
