using System.Text.RegularExpressions;
using SampleLibrary.enums;

namespace SampleLibrary.Normalizing;

public class BasicNormalizer : INormalizer
{
    public List<string> Tokenize(string text)
    {
        return Regex.Split(text, Constants.TokenizerDelimiterRegex).ToList();
    }

    public string Refine(string text)
    {
        return Regex.Replace(text, Constants.TextRefiningRegex,
            string.Empty);
    }

    public string RemoveStoppingWords(string text)
    {
        text = Constants.StoppingWords.Split().Aggregate(text,
            (current, stoppingWord) =>
                Regex.Replace(current, $"\\b{stoppingWord}\\b", string.Empty, RegexOptions.IgnoreCase));
        return Regex.Replace(text, Constants.WhiteSpaceRegex, " ").Trim();
    }


    public List<string> Normalize(string data)
    {
        return Tokenize(RemoveStoppingWords(Refine(data.ToUpper())));
    }
}