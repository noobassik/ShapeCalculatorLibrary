using ShapeCalculatorLibrary;

namespace ShapeCalculatorTests
{
	public class CircleTests
	{
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void InvalidRadiusThrowsArgumentException(double radius)
		{
			Assert.Throws<ArgumentException>(() => new Circle(new LineSegment(radius)));
		}

		[Theory]
		[InlineData(1, Math.PI)]
		[InlineData(5, 78.54)]
		[InlineData(10, 314.16)]
		public void CircleAreaValidRadius(double radius, double expectedArea)
		{
			Circle circle = new Circle(new LineSegment(radius));

			double area = circle.CalculateArea();

			Assert.Equal(expectedArea, area, 2);
		}
	}
}