using OOPDesignFundamentals.Shapes;
using System.Text.RegularExpressions;

namespace OOPDesignFundamentals.ShapeFactories
{
    public class CircleFactory : ShapeFactory
    {
        private static readonly Regex s_ArgumentsRegex = new Regex(@"^(?<radius>\d+(?:\.\d+)?)$");

        public override bool TryCreateShape(string arguments, out Shape shape, out string errorMessage)
        {
            shape = default;
            errorMessage = default;

            var match = s_ArgumentsRegex.Match(arguments);
            if (!match.Success)
            {
                errorMessage = "Invalid arguments format! Circle requires a radius. Example: \"circle:24.5\"";
                return false;
            }

            var groups = match.Groups;
            var radius = float.Parse(groups["radius"].Value);

            shape = new Circle(radius);
            return true;
        }
    }
}
