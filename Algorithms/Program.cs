using System;
using System.Text;

namespace Algorithms
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please provide a word to generate palindrome");

                Console.ForegroundColor = ConsoleColor.Gray;
                var input = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.White;
                var palindrome = GetPalindrome(input);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Palindrome: {palindrome}");
                Console.WriteLine();
            }
        }

        private static string GetPalindrome(string word)
        {
            var balance = 0;
            for (var frame = word.Length; frame > 0; --frame)
            {
                var offset = word.Length - frame;
                var isSymmetric = true;
                var isSymmetricWithOffset = true;
                for (var j = Math.Max(0, frame / 2 - 1); j > -1; --j)
                {
                    if (frame == 1)
                        balance = 0;

                    if (isSymmetric && word[j] != word[frame - 1 - j])
                    {
                        isSymmetric = false;
                        if (frame > 1)
                            balance = -1;
                    }
                    if (isSymmetricWithOffset && word[offset + j] != word[offset + frame - 1 - j])
                    {
                        isSymmetricWithOffset = false;
                        if (frame > 1)
                            balance = 1;
                    }
                    if (balance == 0)
                    {
                        var newBalance = word[j].CompareTo(word[word.Length - 1 - j]);
                        if (newBalance != 0)
                            balance = newBalance > 0 ? 1 : -1;
                    }
                    if (!isSymmetric && !isSymmetricWithOffset)
                        break;
                }
                if (isSymmetric || isSymmetricWithOffset)
                {
                    if (balance == 0)
                        return word;

                    var sb = new StringBuilder(offset + word.Length);


                    if (balance > 0)
                    {
                        for (var j = word.Length - 1; j > 0; --j)
                            sb.Append(word[j]);
                    }

                    for (var j = 0; j < word.Length; ++j)
                        sb.Append(word[j]);

                    if (balance < 0)
                    {
                        for (var j = offset - 1; j > -1; --j)
                            sb.Append(word[j]);
                    }

                    return sb.ToString();
                }
            }
            return word;
        }
    }
}
