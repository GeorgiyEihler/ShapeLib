using ShapesLib.Shapes;
using System;
using Xunit;

namespace ShapeLib.Test
{
    
    public class GenerateTest
    {
        [Fact]
        public void CheckNegativeParametres()
        {
            IShape _shape;
            Assert.Throws<ArgumentException>(() => _shape = new Circle(-100));
            Assert.Throws<ArgumentException>(() => _shape = new Circle(0));
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(-100, 100, 200));
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(100, -100, 500));
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(700, 600, -100));
        }
        [Fact]
        public void CheckTraingleWrongSide()
        {
            IShape _shape;
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(4, 5, 1));
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(0, 0, 0));

        }
    }
    
}
