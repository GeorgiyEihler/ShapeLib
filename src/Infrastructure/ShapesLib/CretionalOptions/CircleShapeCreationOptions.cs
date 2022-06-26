using ShapesLib.Shapes;

namespace ShapesLib.CretionalOptions
{
    public class CircleShapeCreationOptions : IShapeCreationOptions<Circle>
    {
        public double Radius { get; set; }

        public ShapeEnum ShapeType => ShapeEnum.Circle;

        public CircleShapeCreationOptions(double radius)
        {
            Radius = radius;
        }
    }
}
