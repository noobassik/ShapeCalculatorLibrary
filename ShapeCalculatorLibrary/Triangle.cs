using System.ComponentModel.DataAnnotations;
using static System.Math;

namespace ShapeCalculatorLibrary
{
	public class Triangle : IShape
	{
		public LineSegment FirstSide {  get; private set; }

		public LineSegment SecondSide { get; private set; }

		public LineSegment ThirdSide { get; private set; }

		public LineSegment[] Sides => new[] { FirstSide, SecondSide, ThirdSide };

		public Triangle(LineSegment firstSide, LineSegment secondSide, LineSegment thirdSide)
		{
			if (!TriangleValidation(firstSide, secondSide, thirdSide))
			{
				throw new ValidationException("Triangle with given sides can not exist");
			}	
			FirstSide = firstSide;
			SecondSide = secondSide;
			ThirdSide = thirdSide;
		}

		public Triangle(LineSegment[] sides)
		{
			if (sides.Length != 3)
			{
				throw new ArgumentException("Amount of sides in array must be 3");
			}
			if (!TriangleValidation(sides[0], sides[1], sides[2]))
			{
				throw new ValidationException("Triangle with given sides can not exist");
			}
			FirstSide = sides[0];
			SecondSide = sides[1];
			ThirdSide = sides[2];
		}
		
		public double CalculateArea()
		{
			// S = sqrt(p(p-a)(p-b)(p-c))
			double p = (FirstSide.Length + SecondSide.Length + ThirdSide.Length) / 2;
			return Sqrt(p * (p - FirstSide.Length) * (p - SecondSide.Length) * (p - ThirdSide.Length));
		}
		public bool isRightTriangle()
		{
			const double tolerance = 0.01;

			double[] sides = { FirstSide.Length, SecondSide.Length, ThirdSide.Length };
			Array.Sort(sides);

			return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < tolerance;

		}
		private static bool TriangleValidation(LineSegment firstSide, LineSegment secondSide, LineSegment thirdSide)
		{
			return firstSide.Length + secondSide.Length > thirdSide.Length &&
				   secondSide.Length + thirdSide.Length > firstSide.Length &&
				   firstSide.Length + thirdSide.Length > secondSide.Length;
		}
	}
}
