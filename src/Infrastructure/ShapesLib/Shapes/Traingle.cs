
namespace ShapesLib.Shapes
{
    public record Traingle : IShape
    {
        public static bool IsRightTriangle(Traingle traingle) 
        {
            var max = new[] { traingle.SideA, traingle.SideB, traingle.SideC }.OrderByDescending(x=> x).ToArray();
            return Math.Pow(max[0], 2) == Math.Pow(max[1], 2) + Math.Pow(max[2], 2);
        }

        public static bool CheckTringle(double sideA, double sideB, double sideC)
        {
            if (sideA <=0 || sideB <= 0 || sideC <= 0)
            {
                return false;
            }
            if(sideA + sideB <= sideC || sideB + sideC <= sideA || sideA + sideC <= sideB)
            {
                return false;
            }
            return true;
        }
        public double SideA { get; init; }
        public double SideB { get; init; }
        public double SideC { get; init; }

        public Traingle(double sideA, double sideB, double sideC)
        {

            if(!CheckTringle(sideA, sideB, sideC))
            {
                throw new ArgumentException("Неверные параметры");
            }
            (SideA, SideB, SideC) = (sideA, sideB, sideC);
        }

        public double GetArea()
        {
            var halfPerimetr = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(halfPerimetr * (halfPerimetr - SideA) * (halfPerimetr - SideB) * (halfPerimetr - SideC));
        }
    }
}
