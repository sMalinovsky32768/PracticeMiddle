using System;

namespace First
{
    public class Figure
    {
        private readonly Point[] _points;

        public string Name => _points is null ? string.Empty : _points.Length switch
        {
            3 => "Треугольник",
            4 => "Четырехугольник",
            5 => "Пятиугольник",
            _ => "Многоугольник",
        };

        protected Figure(params Point[] points) => _points = points;

        public Figure(Point p1, Point p2, Point p3) : this(new[] { p1, p2, p3 }) { }
        public Figure(Point p1, Point p2, Point p3, Point p4) : this(new[] { p1, p2, p3, p4 }) { }
        public Figure(Point p1, Point p2, Point p3, Point p4, Point p5) : this(new[] { p1, p2, p3, p4, p5 }) { }

        public double Perimeter()
        {
            var perimeter = 0d;

            for (int i = 0; i < _points.Length; i++)
            {
                var p1 = _points[i];
                var p2 = i + 1 < _points.Length ? _points[i + 1] : _points[0];

                perimeter += Distance(p1, p2);
            }

            return perimeter;
        }

        public double Area()
        {
            var area = 0d;

            for (int i = 0; i < _points.Length; i++)
            {
                var p1 = _points[i];
                var p2 = i + 1 < _points.Length ? _points[i + 1] : _points[0];

                area += (p1.X * p2.Y) - (p1.Y * p2.X);
            }

            return area / 2;
        }

        public static double Distance(Point p1, Point p2) => Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
    }
}
