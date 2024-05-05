using static System.Math;

namespace ShapeCalculatorLibrary
{
	public class Circle : IShape
	{
		public LineSegment Radius { get; private set; }

		public Circle(LineSegment radius) 
		{
			Radius = radius;
		}

		public double CalculateArea()
		{
			return PI * Pow(Radius.Length, 2);
		}
	}
}
