namespace ShapeAreaCalculator
{

    public abstract class Shape
    {

        internal abstract string CalcArea(double[] data);

    }

    public class Circle : Shape
    {
        internal override string CalcArea(double[] data)
        {
            if (data.Length == 1)
            {
                double radius = data[0];
                double area = Math.PI * radius * radius;
                return "Circle with area: " + area.ToString();
            }
            else { return "Wrong input."; }
        }
    }

    public class Triangle : Shape
    {
        internal override string CalcArea(double[] data)
        {
            if (data.Length == 3)
            {
                double sideA = data[0];
                double sideB = data[1];
                double sideC = data[2];

                if ((sideA + sideB) > sideC & (sideA + sideC) > sideB & (sideB + sideC) > sideA)
                {

                    double p = (sideA + sideB + sideC) / 2;

                    bool rec = IsRectangular(sideA, sideB, sideC);

                    double area = (Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC)));

                    return "Triangle with area: " + area.ToString() + ". Is rectangular: " + rec + ".";
                }
                else { return "Triangle does not exist."; }

            }
            else { return "Wrong input."; }
        }
        private static bool IsRectangular(double sideA, double sideB, double sideC)
        {
            double[] arrSides = { sideA, sideB, sideC };
            Array.Sort(arrSides);

            if (Math.Pow(arrSides[2], 2) - Math.Pow(arrSides[1], 2) - Math.Pow(arrSides[0], 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
