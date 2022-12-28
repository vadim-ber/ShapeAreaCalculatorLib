using System.Data;
using System.Reflection;

namespace ShapeAreaCalculator
{

    public delegate void ShapeCheatorHandler(string message);
    public static class ShapeCreator
    {

        public static void GetShapeArea(string shapetypename, double[] shapeparams, ShapeCheatorHandler del)
        {
            string typeName = (Char.ToUpper(shapetypename[0]) + shapetypename[1..].ToLowerInvariant());
            var type = Type.GetType("ShapeAreaCalculator." + typeName);
            if (type != null)
            {
                try
                {
                    var shape = (Shape)Activator.CreateInstance(type)!;
                    del(shape.CalcArea(shapeparams));
                }
                catch (Exception ex)
                {
                    del(ex.Message);
                }
            }
            else { del("This type of figure is not found."); }

        }

        public static void GetRelisedShapeTypes(ShapeCheatorHandler del)
        {
            // Динамический список фигур, площадь которых доступна для вычисления.

            Type t = typeof(Shape);

            IEnumerable<Type> list = Assembly.GetAssembly(t)!.GetTypes().Where(type => type.IsSubclassOf(t));

            foreach (Type itm in list)
            {
                del(itm.Name + " ");
            }
        }
    }
}