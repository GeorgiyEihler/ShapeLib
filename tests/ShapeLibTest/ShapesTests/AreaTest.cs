using ShapesLib.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShapeLibTest.ShapesTests
{
    public class AreaTest
    {
        private IShape _shape;
        [Fact]
        public void CheckArea()
        {
            _shape = new Traingle(4, 5, 2);
            Assert.Equal(3.799671, Math.Round(_shape.GetArea(), 6));

            _shape = new Circle(10);
            Assert.Equal(314.159265, Math.Round(_shape.GetArea(), 6));


        }
    }
    
}
