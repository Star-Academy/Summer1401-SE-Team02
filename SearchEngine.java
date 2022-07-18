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
          if (docIndexes == null) return null;
          ArrayList<String> result = new ArrayList<>();
          for (int index : docIndexes){
               result.add(docNames.get(index));
          }
          return result;
     }

     private static ArrayList<Integer> intersection(ArrayList<Integer> a, ArrayList<Integer> b){
          // TODO: you can also use 'retainAll' and 'addAll' methods from Collection library
          // link: https://stackoverflow.com/questions/5283047/intersection-and-union-of-arraylists-in-java
          return null;
     }
     private static ArrayList<Integer> union(ArrayList<Integer> a, ArrayList<Integer> b){
          return null;
     }
     private static ArrayList<Integer> subtract(ArrayList<Integer> a, ArrayList<Integer> b){
          return null;
     }
     
         
}