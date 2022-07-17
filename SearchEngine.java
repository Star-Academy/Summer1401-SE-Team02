import java.util.ArrayList;
import java.util.HashMap;

class SearchEngine{
     private static HashMap<String, ArrayList<Integer> > indexedData;
     private static HashMap<Integer, String> docNames;

     static{
          indexedData = new HashMap<>();
          docNames = new HashMap<>();
     }

     public static ArrayList<Integer> search(String word){
          return indexedData.get(word);
     }

     public static void addFile(String text, String docID){
          ArrayList<String> words = tokenize(refine(text));
          docNames.put(docNames.size(), docID);
          for (String word : words) addWord(word, docNames.size());
     }

     private static ArrayList<String> tokenize(String text){
          ArrayList<String> tokenized = new ArrayList<String>();
          for (String token : text.split("\\s+")) {
               tokenized.add(token);
          }
          return tokenized;
     }

     private static String refine(String text){
          return text.replaceAll("[^a-zA-Z ]", "");
     }

     private static void addWord(String word, int docID){
          if (!indexedData.containsKey(word)) {
               ArrayList<Integer> docs = new ArrayList<>();
               docs.add(docID);
               indexedData.put(word, docs);
          }
          else {
               insertDocID(word, indexedData.get(word), docID);
          }
     }

     private static void insertDocID(String word, ArrayList<Integer> docsIDs, int docID){
          if (!indexedData.get(word).contains(docID)) {
               docsIDs.add(docID);
               indexedData.put(word, docsIDs);
          }
     }
}