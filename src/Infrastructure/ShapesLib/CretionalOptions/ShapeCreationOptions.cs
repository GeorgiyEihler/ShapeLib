using ShapesLib.Shapes;

namespace ShapesLib.CretionalOptions
{
    public interface IShapeCreationOptions<T> where T: IShape
    {
        public ShapeEnum ShapeType { get; }
    }
}
