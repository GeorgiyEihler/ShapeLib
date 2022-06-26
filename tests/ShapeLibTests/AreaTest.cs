using ShapesLib.Shapes;
using System;
using Xunit;

namespace ShapeLib.Test
{
    public class AreaTest
    {
        [Fact]
        public void CheckArea()
        {
            IShape _shape;
            _shape = new Traingle(4, 5, 2);
            Assert.Equal(3.799671, Math.Round(_shape.GetArea(), 6));

            _shape = new Circle(10);
            Assert.Equal(314.159265, Math.Round(_shape.GetArea(), 6));


        }
    }
    
}
