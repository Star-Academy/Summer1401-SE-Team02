import java.util.ArrayList;
import java.util.HashMap;

class SearchEngine{
     private static HashMap<String, ArrayList<Integer> > indexedData;
     public static HashMap<Integer, String> docNames;

     static{
          indexedData = new HashMap<>();
          docNames = new HashMap<>();
     }

     public static ArrayList<String> search(String word){
          return getDocNames(indexedData.get(word));
     }

     public static void addFile(String text, String docID){
          ArrayList<String> words = tokenize(refine(text));
          int id = docNames.size();
          docNames.put(id, docID);
          for (String word : words) addWord(word, id);
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

     private static ArrayList<String> getDocNames(ArrayList<Integer> docIndexes){
          ArrayList<String> result = new ArrayList<>();
          for (int index : docIndexes){
               result.add(docNames.get(index));
          }
          return result;
     }
}