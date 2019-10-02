using OOPDesignFundamentals.ShapeFactories;
using OOPDesignFundamentals.Shapes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OOPDesignFundamentals
{
    public abstract class ShapeFactory
    {
        public abstract bool TryCreateShape(string arguments, out Shape shape, out string errorMessage);

        private static readonly Regex s_InputRegex = new Regex(@"^(?<shapeType>\w+):(?<arguments>.+)$");
        private static readonly Dictionary<string, ShapeFactory> s_ShapeFactories = new Dictionary<string, ShapeFactory>();

        static ShapeFactory()
        {
            s_ShapeFactories.Add(nameof(Circle).ToLowerInvariant(), new CircleFactory());
            s_ShapeFactories.Add(nameof(Rectangle).ToLowerInvariant(), new RectangleFactory());
        }

        public static bool TryCreateShapeFromInput(string input, out Shape shape, out string errorMessage)
        {
            shape = default;

            var match = s_InputRegex.Match(input);
            if (!match.Success)
            {
                errorMessage = "Invalid input format! Please provide \"shape:arguments\"";
                return false;
            }

            var groups = match.Groups;
            var shapeType = groups["shapeType"].Value;
            var arguments = groups["arguments"].Value;

            if (!s_ShapeFactories.TryGetValue(shapeType.ToLowerInvariant(), out var factory))
            {
                errorMessage = $"Invalid shape provided! Valid shapes are {string.Join(", ", s_ShapeFactories.Keys)}";
                return false;
            }

            return factory.TryCreateShape(arguments, out shape, out errorMessage);
        }
    }
}
