using TestTasks.Abstract;

namespace TestTasks
{
    public class Rectangle : CustomFigure
    {
        public double SideALength { get; set; }
        public double SideBLength { get; set; }

        public override double CalculateSquare()
        {
            return SideALength * SideBLength;
        }

        public override string ToString()
        {
            return "Прямоугольник — четырёхугольник, у которого все углы прямые (равны 90 градусов)";
        }
    }
}