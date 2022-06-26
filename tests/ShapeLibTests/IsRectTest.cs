using ShapesLib.Shapes;
using Xunit;

namespace ShapeLib.Test
{
    public class IsRectTest
    {
        
        [Fact]
        public void IsRect()
        {
            IShape _shape;
            _shape = new Traingle(3, 4, 5);
            Assert.True(Traingle.IsRightTriangle((Traingle)_shape));

            _shape = new Traingle(1, 1, 1);
            Assert.False(Traingle.IsRightTriangle((Traingle)_shape));
        }

    }
}
