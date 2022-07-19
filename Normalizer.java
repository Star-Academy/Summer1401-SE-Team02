import java.util.ArrayList;
import java.util.Arrays;

public class Normalizer {

    static private final ArrayList<String> stopWords = new ArrayList<String>(Arrays.asList("OURSELVES", "HERS", "BETWEEN", "YOURSELF", "BUT", "AGAIN", "THERE", "ABOUT", "ONCE", "DURING", "OUT", "VERY", "HAVING", "WITH", "THEY", "OWN", "AN", "BE", "SOME", "FOR", "DO", "ITS", "YOURS", "SUCH", "INTO", "OF", "MOST", "ITSELF", "OTHER", "OFF", "IS", "S", "AM", "OR", "WHO", "AS", "FROM", "HIM", "EACH", "THE", "THEMSELVES", "UNTIL", "BELOW", "ARE", "WE", "THESE", "YOUR", "HIS", "THROUGH", "DON", "NOR", "ME", "WERE", "HER", "MORE", "HIMSELF", "THIS", "DOWN", "SHOULD", "OUR", "THEIR", "WHILE", "ABOVE", "BOTH", "UP", "TO", "OURS", "HAD", "SHE", "ALL", "NO", "WHEN", "AT", "ANY", "BEFORE", "THEM", "SAME", "AND", "BEEN", "HAVE", "IN", "WILL", "ON", "DOES", "YOURSELVES", "THEN", "THAT", "BECAUSE", "WHAT", "OVER", "WHY", "SO", "CAN", "DID", "NOT", "NOW", "UNDER", "HE", "YOU", "HERSELF", "HAS", "JUST", "WHERE", "TOO", "ONLY", "MYSELF", "WHICH", "THOSE", "I", "AFTER", "FEW", "WHOM", "T", "BEING", "IF", "THEIRS", "MY", "AGAINST", "A", "BY", "DOING", "IT", "HOW", "FURTHER", "WAS", "HERE", "THAN"));

    public static ArrayList<String> normalize(String text) {
        ArrayList<String> result = removeStopWords(tokenize(refine(text)));
        return result;
        
    }
    
    private static ArrayList<String> tokenize(String text){
        ArrayList<String> tokenized = new ArrayList<String>();
        for (String token : text.split("\\s+")) {
             tokenized.add(token);
        }
        return tokenized;
   }

   private static String refine(String text){
    return text.replaceAll("[^a-zA-Z ]", "").toUpperCase();
    }

    private static ArrayList<String> removeStopWords(ArrayList<String> words) {
        words.removeAll(stopWords);
        return words;
        }
    }
    

