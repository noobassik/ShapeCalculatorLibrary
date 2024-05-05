namespace ShapeCalculatorLibrary
{
	public class LineSegment
	{
		private double _length;

		public double Length
		{
			get => _length;
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Length of line must be greater than zero");
				}
				_length = value;
			}
			
		}

		public LineSegment(double length)
		{
			Length = length;
		}
	}
}
