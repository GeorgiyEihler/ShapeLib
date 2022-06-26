using ShapesLib.Shapes;

namespace ShapesLib.CretionalOptions
{
    public class TringleCreationOptions : IShapeCreationOptions<Traingle>
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public ShapeEnum ShapeType => ShapeEnum.Traingle;

        public TringleCreationOptions(double sideA, double sideB, double sideC)
        {
            (SideA, SideB, SideC) = (sideA, sideB, sideC);
        }
       

    }
}
