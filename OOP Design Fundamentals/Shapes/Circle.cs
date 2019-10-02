using System;

namespace OOPDesignFundamentals.Shapes
{
    public class Circle : Shape
    {
        public float Radius { get; private set; }

        public Circle(float radius)
        {
            Radius = radius;
        }

        public override float GetArea()
        {
            return MathF.PI * Radius * Radius;
        }

        public override float GetPerimeter()
        {
            return 2 * MathF.PI * Radius;
        }
    }
}
