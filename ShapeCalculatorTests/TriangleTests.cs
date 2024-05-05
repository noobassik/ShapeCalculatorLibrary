using ShapeCalculatorLibrary;
using System.ComponentModel.DataAnnotations;

namespace ShapeCalculatorTests
{
	public class TriangleTests
	{
		[Theory]
		[InlineData(0, 1, 2)]
		[InlineData(1, 0, 2)]
		[InlineData(1, 2, 0)]
		[InlineData(-1, 2, 3)]
		public void InvalidSidesThrowsArgumentException(double side1, double side2, double side3)
		{
			Assert.Throws<ArgumentException>(() =>
				new Triangle(new LineSegment(side1), new LineSegment(side2), new LineSegment(side3)));
		}

		[Theory]
		[InlineData(1, 2, 3)]
		[InlineData(3, 4, 8)]
		public void ImpossibleTriangleThrowsArgumentException(double side1, double side2, double side3)
		{
			Assert.Throws<ValidationException>(() =>
				new Triangle(new LineSegment(side1), new LineSegment(side2), new LineSegment(side3)));
		}

		[Theory]
		[InlineData(3, 4, 5, 6)]
		[InlineData(6, 8, 10, 24)]
		[InlineData(5, 5, 5, 10.83)]
		public void TriangleAreaValidSides(double side1, double side2, double side3, double expectedArea)
		{
			Triangle triangle = new Triangle(new LineSegment(side1), new LineSegment(side2), new LineSegment(side3));

			double area = triangle.CalculateArea();

			Assert.Equal(expectedArea, area, 2);
		}

		[Fact]
		public void ConstructorWithArrayOfSides()
		{
			Triangle triangle = new Triangle(new[] { new LineSegment(6), new LineSegment(8), new LineSegment(10) });

			Assert.Equal(6, triangle.FirstSide.Length);
			Assert.Equal(8, triangle.SecondSide.Length);
			Assert.Equal(10, triangle.ThirdSide.Length);
		}

		[Fact]
		public void SidesPropertyUnmutable()
		{
			var preparedSides = new[] { new LineSegment(6), new LineSegment(8), new LineSegment(10) };

			Triangle triangle = new Triangle(preparedSides);
			var sides = triangle.Sides;
			sides[0] = new LineSegment(8);

			Assert.Equal(6, triangle.FirstSide.Length);
			Assert.Equal(8, triangle.SecondSide.Length);
			Assert.Equal(10, triangle.ThirdSide.Length);
			Assert.NotEqual(triangle.Sides[0].Length, sides[0].Length);
		}
	}
}