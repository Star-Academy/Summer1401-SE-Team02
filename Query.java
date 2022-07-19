import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Query {
     private static final String END_PROGRAM = "-1";
     private final String query;
     public ArrayList<String> simpleWords;
     public ArrayList<String> positiveWords;
     public ArrayList<String> negativeWords;


     Query(String query){
          this.query = query;
     }

     public boolean isEnd(){
          return query.equals(END_PROGRAM);
     }

     public void process(){
          this.simpleWords = extractMatchedWords("(?<!\\S)"); 
          this.positiveWords = extractMatchedWords("\\+"); 
          this.negativeWords = extractMatchedWords("-"); 
     }

     private ArrayList<String> extractMatchedWords(String specialSign){
          Matcher matcher = Pattern.compile(specialSign + "(\\w+)").matcher(this.query);
          ArrayList<String> result = new ArrayList<>();
          while (matcher.find())
               result.add(matcher.group(1));
          return result;
     }

}
