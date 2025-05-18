namespace _Main.Scripts.SurfaceArea
{
    public class SquareSurfaceAreaCalculator : SurfaceAreaCalculator
    {
        private int a;

        public SquareSurfaceAreaCalculator(int a)
        {
            this.a = a;
        }

        public override int GetSurfaceArea()
        {
            return a * a;
        }
    }
}