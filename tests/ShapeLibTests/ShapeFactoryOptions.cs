using ShapesLib.CretionalOptions;
using ShapesLib.ShapeFactory;
using ShapesLib.Shapes;
using Xunit;

namespace ShapeLib.Test
{
    public class ShapeFactoryOptions
    {
        [Fact]
        public void  FactoryCheck()
        {
            var facory = new ShapeFactory();
            var circle = (Circle)facory.CreateShapeReflection(new CircleShapeCreationOptions(1));
            var traingle = (Traingle)facory.CreateShapeReflection(new TringleCreationOptions(3, 4, 5));


            Assert.Equal(3, traingle.SideA);
            Assert.Equal(1, circle.Radius);

            var traingle1 = (Traingle)facory.CreateShape(new TringleCreationOptions(3, 4, 5));
            var circle1 = (Circle)facory.CreateShape(new CircleShapeCreationOptions(1));

            Assert.Equal(3, traingle1.SideA);
            Assert.Equal(1, circle1.Radius);

        }
    }
}
