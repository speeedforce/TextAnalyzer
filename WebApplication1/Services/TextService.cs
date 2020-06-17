using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services
{
    public class TextService : ITextService
    {
        readonly char[] _delimiters = new char[] { ' ', '\r', '\n' };
        public KeyValuePair<string, int> CountSymbolsWithoutWhiteSpace(string input)
        {
            return new KeyValuePair<string, int>("Count Symbols Without White Space", 
                input.Split(_delimiters).Length);
        }

        public KeyValuePair<string, int> CountAllSymbols(string input)
        {
            return new KeyValuePair<string, int>("Count All Symbols", input.Length);
        }

        public KeyValuePair<string, int> NumbersCount(string input)
        {
            return new KeyValuePair<string, int>("Numbers: ",
                input.Count(char.IsDigit));
        }

        public KeyValuePair<string, Dictionary<string, int>> TopWords(string input, int max)
        {
            var words = input.Split(_delimiters)
               .Where(w => w.Length >= 2)
               .GroupBy(x => x)
               .OrderByDescending(x => x.Count())
               .Take(max)
               .ToDictionary(x => x.Key, x => x.Count());
            return new KeyValuePair<string, Dictionary<string, int>>("Top Words", words);
        }

        public KeyValuePair<string, Dictionary<string, int>> TopChars(string input, int max)
        {
            var chars = input
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(max)
                .ToDictionary(x => x.Key.ToString(), x => x.Count());

            return new KeyValuePair<string, Dictionary<string, int>>("Top Chars", chars);
        }
    }
}
