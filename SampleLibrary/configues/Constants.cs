namespace SampleLibrary.enums;

public static class Constants
{
    public const string TokenizerDelimiterRegex = "[\\s,]+";
    public const string TextRefiningRegex = "[^a-zA-Z ]+";
    public const string WhiteSpaceRegex = "\\s+";

    public const string StoppingWords =
        "a about above across after afterwards again against all almost alone along also although always am among amount an and another any anyhow anyone anything anyway anywhere are around as at back be became because become becomes been being below beside besides between beyond both but by came can cant cannot come could couldnt describe did didnt do does doesnt doing done dont due during each either else elsewhere enough etc even ever every everyone everything everywhere few for from further get give goes going had happen has hasnt have having here how however i if ill im in into is isnt it its ive just keep let like made make many may me mean might mine more most mostly much name next no nobody not nothing now of once only onto or other others otherwise our over per perhaps please put rather re really same say see seem seemed seeming seems several should show side since so some somehow someone something sometime sometimes somewhere still such take tell than that the then their them then there these they thing this those through throughout to together too try un up upon us use used uses very want was way we well were what whatever when where wherever whether which who whoever whole whom whose why will with within without wont would you your youre yours yourself";

    public const string MustIncludingWordsRegex = "^([^\\+-]+)$";
    public const string PositiveWordsRegex = "\\+(.*)";
    public const string NegativeWordsRegex = "-(.*)";
}