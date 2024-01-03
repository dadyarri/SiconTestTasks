namespace TestTasks
{
    public class Square : Rectangle
    {
        public new double SideALength { get; set; }

        public new double SideBLength
        {
            get => SideALength;
            private set => SideALength = value;
        }

        public override string ToString()
        {
            return "Квадрат — прямоугольник, у которого все стороны равны";
        }
    }
}