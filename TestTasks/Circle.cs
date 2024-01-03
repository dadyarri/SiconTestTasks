using System;
using TestTasks.Abstract;

namespace TestTasks
{
    public class Circle : CustomFigure
    {
        public double Radius { get; set; }

        public override double CalculateSquare()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return "Круг — часть плоскости, которая лежит внутри окружности";
        }
    }
}