import java.util.ArrayList;
import java.util.HashMap;

class SearchEngine{
     private static HashMap<String, ArrayList<String> > indexedData;

     static {
          indexedData = new HashMap<>();
     }

     public static ArrayList<String> search(String word){
          return indexedData.get(word);
     }

     public static void addFile(String text, String docID){
          ArrayList<String> words = tokenize(text);
          for (String word : words) addWord(word, docID);
     }

     private static ArrayList<String> tokenize(String text){
          //TODO: tokenize the text and seperate it to words. (most simple way)
          ArrayList<String> tokenized = new ArrayList<String>();
          for (String token : text.split("\\s+")) {
               tokenized.add(token);
          }
          return tokenized;
     }

     private static void addWord(String word, String docID){
          if (!indexedData.containsKey(word)) {
               ArrayList<String> docs = new ArrayList<String>();
               indexedData.put(word, docs);
          }
          else {
               insertDocID(word, indexedData.get(word), docID);
          }
     }

     private static void insertDocID(String word, ArrayList<String> docsIDs, String docID){
          //TODO: insert the docID to the list and replace it in indexedData.
     }
}