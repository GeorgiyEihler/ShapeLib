
using ShapesLib.CretionalOptions;

namespace ShapesLib.Shapes
{
    public record Circle : IShape
    {
        public static bool CheckChape(double radius) =>
            radius > 0;
        public double Radius { get; init; }
        public Circle(double radius)
        {
            if(!CheckChape(radius))
            {
                throw new ArgumentException("Неверные параметры");
            }

            Radius = radius;

        }
        public Circle(CircleShapeCreationOptions options)
        {
            if (!CheckChape(options.Radius))
            {
                throw new ArgumentException("Неверные параметры");
            }

            Radius = options.Radius;
        }
        public double GetArea() =>
            Math.Pow(Radius, 2) * Math.PI;
    }
}
