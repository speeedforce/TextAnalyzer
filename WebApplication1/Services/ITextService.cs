using System;
using System.Collections.Generic;

namespace WebApplication1.Services
{
    public interface ITextService
    {
        KeyValuePair<string, int> CountSymbolsWithoutWhiteSpace(string input);
        KeyValuePair<string, int> CountAllSymbols(string input);
        KeyValuePair<string, int> NumbersCount(string input);

        KeyValuePair<string, Dictionary<string, int>> TopWords(string input, int max);

        KeyValuePair<string, Dictionary<string, int>> TopChars(string input, int max);
    }
}
