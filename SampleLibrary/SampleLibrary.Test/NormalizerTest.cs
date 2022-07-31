using FluentAssertions;
using SampleLibrary.Normalizing;

namespace SampleLibrary.Test;

public class NormalizerTest
{
    private readonly BasicNormalizer _basicNormalizer;

    public NormalizerTest()
    {
        _basicNormalizer = new BasicNormalizer();
        //TODO: think about extension methods. is it true to use them here or not?
        //TODO: thinking whether this class violates the SRP or not. what if we create a IStringManipulator interface and implement these classes there?
    }

    #region Tokenize method tests

    [Fact]
    public void Tokenize_SingleSpaceDelimiterSentence_ReturnListOfWords()
    {
        List<string> result = _basicNormalizer.Tokenize("simple space seperated sentence");
        result.Should().Equal(new List<string>() { "simple", "space", "seperated", "sentence" });
    }

    [Fact]
    public void Tokenize_MultipleSpaceDelimiterSentence_ReturnListOfWords()
    {
        var result = _basicNormalizer.Tokenize("complex       space   seperated    sentence");
        result.Should().Equal(new List<string>() { "complex", "space", "seperated", "sentence" });
    }

    [Fact]
    public void Tokenize_SingleCommaSeperatedSentence_ReturnListOfWords()
    {
        var result = _basicNormalizer.Tokenize("simple,comma,seperated,sentence");
        result.Should().Equal(new List<string>() { "simple", "comma", "seperated", "sentence" });
    }

    [Fact]
    public void Tokenize_MultipleCommaSeperatedSentence_ReturnListOfWords()
    {
        var result = _basicNormalizer.Tokenize("complex,,,comma,,seperated,,,,,sentence");
        result.Should().Equal(new List<string>() { "complex", "comma", "seperated", "sentence" });
    }

    [Fact]
    public void Tokenize_CommaOrSpaceSeperatedSentence_ReturnListOfWords()
    {
        var result = _basicNormalizer.Tokenize("comma,,,  or,   space,,   , seperated  , ,sentence");
        result.Should().Equal(new List<string>() { "comma", "or", "space", "seperated", "sentence" });
    }
    
    [Fact]
    public void Tokenize_MultipleLinesText_ReturnListOfWordsIgnoringNewLineCharacter()
    {
        var result = _basicNormalizer.Tokenize("text with \nnewline\ncharacter");
        result.Should().Equal(new List<string>() { "text", "with", "newline", "character"});
    }
    #endregion

    #region Refine Method tests

    [Theory]
    [InlineData("string without any special character", "string without any special character")]
    [InlineData("keeping    white   spaces", "keeping    white   spaces")]
    public void Refine_AlphabeticalCharsOnly_ReturnInputWithoutChange(string sentence, string expected)
    {
        var result = _basicNormalizer.Refine(sentence);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("string, with; $some^ #special %chars!", "string with some special chars")]
    [InlineData("123numerical 485values0", "numerical values")]
    public void Refine_NonAlphabeticalCharsIncluded_ReturnWithoutSpecialCharacters(string sentence, string expected)
    {
        var result = _basicNormalizer.Refine(sentence);
        result.Should().Be(expected);
    }

    #endregion

    #region Stopping Wrods remove test

    [Fact]
    public void RemoveStoppingWords_SimpleCondition_ReturnStringWithoutStoppingWords()
    {
        var result = _basicNormalizer.RemoveStoppingWords("this is a test for removing stopping words");
        result.Should().Be("test removing stopping words");
    }

    #endregion

    #region Normailizing a text (mixture of other three methods)

    [Fact]
    public void Normalize_TextWithStoppingWords_ReturnTheListOfUpperCasedMainWords()
    {
        var result = _basicNormalizer.Normalize("here is a simple test");
        result.Should().Equal(new List<string>() {"SIMPLE", "TEST"});
    }
    
    [Fact]
    public void Normalize_TextWithNonAlphabeticalCharacters_ReturnTheListOfUpperCasedMainWords()
    {
        var result = _basicNormalizer.Normalize("#non! @alphabetical 123 (chars;) [included.]");
        result.Should().Equal(new List<string>() {"NON", "ALPHABETICAL", "CHARS", "INCLUDED"});
    }

    [Fact]
    public void Normalize_CommaIncludedText_ReturnTheListOfUpperCasedMainWords()
    {
        var result = _basicNormalizer.Normalize("test for, commas,,, in the text.");
        result.Should().Equal(new List<string>() {"TEST", "COMMAS", "TEXT"});
    }

    #endregion
}