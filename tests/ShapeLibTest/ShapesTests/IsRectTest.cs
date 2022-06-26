using ShapesLib.Shapes;
using Xunit;

namespace ShapeLibTest.ShapesTests
{
    public class IsRectTest
    {
        private IShape _shape;

        [Fact]
        public void IsRect()
        {
            _shape = new Traingle(3, 4, 5);
            Assert.True(Traingle.IsRightTriangle((Traingle)_shape));

            _shape = new Traingle(1, 1, 1);
            Assert.False(Traingle.IsRightTriangle((Traingle)_shape));
        }

    }
}
