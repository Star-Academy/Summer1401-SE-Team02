package src;

import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import src.enums.Constants;

public class Query {

     private final String query;
     public ArrayList<String> simpleWords;
     public ArrayList<String> positiveWords;
     public ArrayList<String> negativeWords;

     Query(String query) {
          this.query = query;
     }

     public void process() {
          this.simpleWords = extractMatchedWords(Constants.SIMPLE_WORDS_REGEX.toString());
          this.positiveWords = extractMatchedWords(Constants.POSITIVE_WORDS_REGEX.toString());
          this.negativeWords = extractMatchedWords(Constants.NEGATIVE_WORDS_REGEX.toString());
     }

     private ArrayList<String> extractMatchedWords(String specialSign) {
          Matcher matcher = Pattern.compile(specialSign + Constants.EXTRACT_WORD_REGEX.toString()).matcher(this.query);
          ArrayList<String> result = new ArrayList<>();
          while (matcher.find())
               result.add(matcher.group(1));
          return result;
     }

     public String getValue() {
          return query;
     }

}
