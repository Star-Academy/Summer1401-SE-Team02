using System.Runtime.InteropServices;
using FluentAssertions;
using SampleLibrary.Normalizing;

namespace SampleLibrary.Test;

public class NormalizerTest
{
    private readonly BasicNormalizer _basicNormalizer;

    public NormalizerTest()
    {
        _basicNormalizer = new BasicNormalizer();
    }

    #region Tokenize method tests

    [Fact]
    public void Tokenize_SingleSpaceDelimiterSentence_ReturnListOfWords()
    {
        var input = "simple space seperated sentence";
        var expected = new List<string>() { "simple", "space", "seperated", "sentence" };
        
        var result = _basicNormalizer.Tokenize(input);
        result.Should().Equal(expected);
    }

    [Fact]
    public void Tokenize_MultipleSpaceDelimiterSentence_ReturnListOfWords()
    {
        var input = "complex       space   seperated    sentence";
        var expected = new List<string>() { "complex", "space", "seperated", "sentence" };
        
        var result = _basicNormalizer.Tokenize(input);
        result.Should().Equal(expected);
    }

    [Fact]
    public void Tokenize_SingleCommaSeperatedSentence_ReturnListOfWords()
    {
        var input = "simple,comma,seperated,sentence";
        var expected = new List<string>() { "simple", "comma", "seperated", "sentence" };
        
        var result = _basicNormalizer.Tokenize(input);
        result.Should().Equal(expected);
    }

    [Fact]
    public void Tokenize_MultipleCommaSeperatedSentence_ReturnListOfWords()
    {
        var input = "complex,,,comma,,seperated,,,,,sentence";
        var expected = new List<string>() { "complex", "comma", "seperated", "sentence" };
        
        var result = _basicNormalizer.Tokenize(input);
        result.Should().Equal(expected);
    }

    [Fact]
    public void Tokenize_CommaOrSpaceSeperatedSentence_ReturnListOfWords()
    {
        var input = "comma,,,  or,   space,,   , seperated  , ,sentence";
        var expected = new List<string>() { "comma", "or", "space", "seperated", "sentence" };
        
        var result = _basicNormalizer.Tokenize(input);
        result.Should().Equal(expected);
    }
    
    [Fact]
    public void Tokenize_MultipleLinesText_ReturnListOfWordsIgnoringNewLineCharacter()
    {
        var input = "text with \nnewline\ncharacter";
        var expected = new List<string>() { "text", "with", "newline", "character" };
        
        var result = _basicNormalizer.Tokenize(input);
        result.Should().Equal(expected);
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

    [Theory]
    [InlineData("this is a test for removing stopping words", "test removing stopping words")]
    public void RemoveStoppingWords_SimpleCondition_ReturnStringWithoutStoppingWords(string input, string expected)
    {
        var result = _basicNormalizer.RemoveStoppingWords(input);
        result.Should().Be(expected);
    }

    #endregion

    #region Normailizing a text (mixture of other three methods)

    [Fact]
    public void Normalize_TextWithStoppingWords_ReturnTheListOfUpperCasedMainWords()
    {
        var input = "here is a simple test";
        var expected = new List<string>() { "SIMPLE", "TEST" };
        
        var result = _basicNormalizer.Normalize(input);
        result.Should().Equal(expected);
    }
    
    [Fact]
    public void Normalize_TextWithNonAlphabeticalCharacters_ReturnTheListOfUpperCasedMainWords()
    {
        var input = "#non! @alphabetical 123 (chars;) [included.]";
        var expected = new List<string>() { "NON", "ALPHABETICAL", "CHARS", "INCLUDED" };
        
        var result = _basicNormalizer.Normalize(input);
        result.Should().Equal(expected);
    }

    [Fact]
    public void Normalize_CommaIncludedText_ReturnTheListOfUpperCasedMainWords()
    {
        var input = "test for, commas,,, in the text.";
        var expected = new List<string>() { "TEST", "COMMAS", "TEXT" };
        
        var result = _basicNormalizer.Normalize(input);
        result.Should().Equal(expected);
    }

    #endregion
}