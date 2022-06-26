using ShapesLib.CretionalOptions;
using ShapesLib.Exceptions;
using ShapesLib.Shapes;

namespace ShapesLib.ShapeFactory
{
    public class ShapeFactory
    {
        
        public IShape CreateShape<T> (IShapeCreationOptions<T> options)
            where T : IShape
        {
            switch (options.ShapeType)
            {
                case ShapeEnum.Circle:
                    {
                        if(options is CircleShapeCreationOptions co)
                        {
                            return new Circle(co.Radius);
                        }
                        throw new FactoryCreateException($"Переданы неверные параметны");
                    }
                case ShapeEnum.Traingle:
                    {
                        if (options is TringleCreationOptions to)
                        {
                            return new Traingle(to.SideA, to.SideB, to.SideC);
                        }
                        throw new FactoryCreateException($"Переданы неверные параметны");
                    }
                default : throw new NotImplementedException();
            }
        }

        public IShape CreateShapeReflection<T>(IShapeCreationOptions<T> options)
            where T : IShape
        {
            
            var targetType = typeof(T);
            var requaredGeneric = typeof(IShapeCreationOptions<>).MakeGenericType(targetType);
            // Конкретный класс ICreationalOptions
            var cretionalOptonsConceteType = options.GetType();

            // Если есть реалзиация конструктора через ICreationOptions
                      
            var targetConstructors = targetType.GetConstructors()
                .Where(cp => cp.GetParameters().Length == 1 && cp.GetParameters()[0].ParameterType == cretionalOptonsConceteType).FirstOrDefault();

            if(targetConstructors is not null)
            {
                return (IShape)Activator.CreateInstance(targetType, new [] { options });
            }

            // для упрощения предположи что нам не надо лезть в field info а сразу лезем в propertyinfo
            // для упрощения предположи что естьт один коснтруктоа и не будем расписывать простыню

            targetConstructors = targetType.GetConstructors().Where(cp => cp.GetParameters().Length >= 1).FirstOrDefault();

            if (targetConstructors is null)
            {
                throw new FactoryCreateException("Нет конструкторов которые могли бы принять аргументы");
            }

            var targetTypeConstracotrsParams = targetConstructors?.GetParameters();

            var porpinfo = cretionalOptonsConceteType?.GetProperties();

            var constractorConcreteParametres =
                new object[targetTypeConstracotrsParams.Length];

            for (int parametrsId = 0; parametrsId < targetTypeConstracotrsParams.Length; parametrsId++)
            {
                var creationalOptionsProperty = porpinfo?.Where(pInfo => targetTypeConstracotrsParams[parametrsId]?.Name?.ToLower() == pInfo.Name.ToLower() &&
                           targetTypeConstracotrsParams[parametrsId].ParameterType == pInfo.PropertyType).FirstOrDefault();
                if (creationalOptionsProperty is null)
                {
                    throw new FactoryCreateException("Нет конструкторов которые могли бы принять аргументы");
                }
                constractorConcreteParametres[parametrsId] = creationalOptionsProperty?.GetValue(options);
            }
            return (IShape)Activator.CreateInstance(targetType, constractorConcreteParametres);
        }
    }
}
