namespace _03.SubstringService
{
    using System.Text.RegularExpressions;

    public class SubstringService : ISubstringService
    {
        public int GetOccurrencesCount(string substring, string text)
        {
            return Regex.Matches(text, substring).Count;
        }
    }
}
