using ShapesLib.Shapes;
using System;
using Xunit;

namespace ShapeLibTest.ShapesTests
{
    
    public class GenerateTest
    {
        private IShape _shape;
        [Fact]
        public void CheckNegativeParametres()
        {
            Assert.Throws<ArgumentException>(() => _shape = new Circle(-100));
            Assert.Throws<ArgumentException>(() => _shape = new Circle(0));
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(-100, 100, 200));
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(100, -100, 500));
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(700, 600, -100));
        }
        [Fact]
        public void CheckTraingleWrongSide()
        {
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(4, 5, 1));
            Assert.Throws<ArgumentException>(() => _shape = new Traingle(0, 0, 0));

        }
    }
    
}
