
namespace ShapesLib.Shapes
{
    public record Circle : IShape
    {
        public double Radius { get; init; }
        public Circle(double radius)
        {
            if(radius <= 0)
            {
                throw new ArgumentException("Неверные параметры");
            }

            Radius = radius;

        }
        public double GetArea() =>
            Math.Pow(Radius, 2) * Math.PI;
    }
}
