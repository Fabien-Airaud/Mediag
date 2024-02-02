using Mediag.DecisionTree;

namespace Mediag.Hospital
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

        public bool Status { get; set; }

        public bool Selected { get; set; }


        public Diagnosis() { }

        public Diagnosis(long id, double radiusWorst, double areaWorst, double perimeterWorst, double concavePointsWorst, double concavePointsMean, double perimeterMean, bool status, bool selected)
        {
            Id = id;
            RadiusWorst = radiusWorst;
            AreaWorst = areaWorst;
            PerimeterWorst = perimeterWorst;
            ConcavePointsWorst = concavePointsWorst;
            ConcavePointsMean = concavePointsMean;
            PerimeterMean = perimeterMean;
            Status = status;
            Selected = selected;
        }


        public object[] Values()
        {
            object[] values = new object[]
            {
                RadiusWorst, AreaWorst, PerimeterWorst, ConcavePointsWorst, ConcavePointsMean, PerimeterMean, Status
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
                + Status + ", "
                + Selected;
            return str;
        }
    }
}
