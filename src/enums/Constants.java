package src.enums;

public enum Constants {
     POSITIVE_WORDS_REGEX("\\+"),
     NEGATIVE_WORDS_REGEX("-"),
     SIMPLE_WORDS_REGEX("(?<!\\S)"),
     EXTRACT_WORD_REGEX("(\\w+)"),

     SPACE("\\s+"),

     END_OF_PROGRAM("-1"),

     DOCS_FOlDER("Docs"),

     ERROR_MESSAGE(ColorCodes.RED_BOLD.getCode() + "! " + ColorCodes.ANSI_RESET.getCode() + "%s"),
     SUCCESS_MESSAGE(ColorCodes.GREEN_BOLD.getCode() + "+ " + ColorCodes.ANSI_RESET.getCode()
               + "number of search results: %d\n%s"),

     STOPPING_WORDS(
               "a about above across after afterwards again against all almost alone along also although always am among amount an and another any anyhow anyone anything anyway anywhere are around as at back be became because become becomes been being below beside besides between beyond both but by came can cant cannot come could couldnt describe did didnt do does doesnt doing done dont due during each either else elsewhere enough etc even ever every everyone everything everywhere few for from further get give goes going had happen has hasnt have having here how however i if ill im in into is isnt it its ive just keep let like made make many may me mean might mine more most mostly much name next no nobody not nothing now of once only onto or other others otherwise our over per perhaps please put rather re really same say see seem seemed seeming seems several should show side since so some somehow someone something sometime sometimes somewhere still such take tell than that the then their them then there these they thing this those through throughout to together too try un up upon us use used uses very want was way we well were what whatever when where wherever whether which who whoever whole whom whose why will with within without wont would you your youre yours yourself");

     private final String value;

     Constants(String constant) {
          this.value = constant;
     }

     @Override
     public String toString() {
          return this.value;
     }
}
