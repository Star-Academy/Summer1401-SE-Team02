package src.models;

import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import src.enums.Constants;

public class MultiWordQuery implements QueryInterface {
     
     private String query;
     private ArrayList<String> includingWords;
     private ArrayList<String> excludingWords;
     private ArrayList<String> leastPresenceWrods;


     public MultiWordQuery(String query){
          this.query = query;
          this.includingWords = new ArrayList<>();
          this.excludingWords = new ArrayList<>();
          this.leastPresenceWrods = new ArrayList<>();
     }

     @Override
     public ArrayList<String> getIncludingWords() {
          return this.includingWords;
     }

     @Override
     public ArrayList<String> getExcludingWords() {
          return this.excludingWords;
     }

     @Override
     public ArrayList<String> getLeastPresencengWords() {
          return this.leastPresenceWrods;
     }

     @Override
     public void process() {
          this.includingWords = extractMatchedWords(Constants.SIMPLE_WORDS_REGEX.toString());
          this.leastPresenceWrods = extractMatchedWords(Constants.POSITIVE_WORDS_REGEX.toString());
          this.excludingWords = extractMatchedWords(Constants.NEGATIVE_WORDS_REGEX.toString());
     }
     
     private ArrayList<String> extractMatchedWords(String specialSign) {
          Matcher matcher = Pattern.compile(specialSign + Constants.EXTRACT_WORD_REGEX.toString()).matcher(this.query);
          ArrayList<String> result = new ArrayList<>();
          while (matcher.find())
               result.add(matcher.group(1));
          return result;
     }
}
