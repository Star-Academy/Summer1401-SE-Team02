package src.enums;

public enum Constants {
     POSITIVE_WORDS_REGEX("\\+"),
     NEGATIVE_WORDS_REGEX("-"),
     SIMPLE_WORDS_REGEX("(?<!\\S)"),
     EXTRACT_WORD_REGEX("(\\w+)"),

     END_OF_PROGRAM("-1");

     private final String value;

     Constants(String constant) {
          this.value = constant;
     }

     @Override
     public String toString() {
          return this.value;
     }
}
