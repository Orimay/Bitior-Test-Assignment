using OOPDesignFundamentals.Shapes;
using System.Text.RegularExpressions;

namespace OOPDesignFundamentals.ShapeFactories
{
    public class RectangleFactory : ShapeFactory
    {
        private static readonly Regex s_ArgumentsRegex = new Regex(@"^(?<width>\d+(?:\.\d+)?)x(?<height>\d+(?:\.\d+)?)$");

        public override bool TryCreateShape(string arguments, out Shape shape, out string errorMessage)
        {
            shape = default;
            errorMessage = default;

            var match = s_ArgumentsRegex.Match(arguments);
            if (!match.Success)
            {
                errorMessage = "Invalid arguments format! Rectangle requires width and height. Example: \"rectangle:12.7x4\"";
                return false;
            }
            var groups = match.Groups;
            var width = float.Parse(groups["width"].Value);
            var height = float.Parse(groups["height"].Value);

            shape = new Rectangle(width, height);
            return true;
        }
    }
}
