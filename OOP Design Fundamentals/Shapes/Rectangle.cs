namespace OOPDesignFundamentals.Shapes
{
    public class Rectangle : Shape
    {
        public float Width { get; private set; }
        public float Height { get; private set; }

        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public override float GetArea()
        {
            return Width * Height;
        }

        public override float GetPerimeter()
        {
            return 2 * (Width + Height);
        }
    }
}
