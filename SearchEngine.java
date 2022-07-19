import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.HashMap;


class SearchEngine{
     private static HashMap<String, ArrayList<Integer> > indexedData;
     public static HashMap<Integer, String> docNames;

     static{
          indexedData = new HashMap<>();
          docNames = new HashMap<>();
     }

     // public static ArrayList<String> search(String query){
     //      return getDocNames(processQuery(query.split("\\s+")));
     // }
     
     public static ArrayList<String> advanceSearch(Query query){
          return getDocNames(processQuery(query));
     }

     private static ArrayList<Integer> getDocsList(String word){
          if (indexedData.containsKey(word.toUpperCase())) return indexedData.get(word.toUpperCase());
          return new ArrayList<Integer>();
     }

     private static ArrayList<Integer> processQuery(Query query){
          ArrayList<Integer> result = new ArrayList<>();
          ArrayList<Integer> result_plus = new ArrayList<>();
          for (String word : query.positiveWords) result = union(result_plus, getDocsList(word));

          if (!query.simpleWords.isEmpty()){
               result = getDocsList(query.simpleWords.get(0));
               for (int j = 0; j < query.simpleWords.size(); j++) {
                    result = intersection(result, getDocsList(query.simpleWords.get(j)));
               }
               for (String word : query.negativeWords) result = subtract(result, getDocsList(word));
               if (query.positiveWords.isEmpty()) return result;
               return intersection(result, result_plus);
          }
          else if (!query.positiveWords.isEmpty()){
               result = getDocsList(query.positiveWords.get(0));
               for (int j = 0; j < query.positiveWords.size(); j++) {
                    result_plus = union(result_plus, getDocsList(query.positiveWords.get(j)));
               }
               for (String word : query.negativeWords) result_plus = subtract(result_plus, getDocsList(word));
          }
          return result_plus;
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
          ArrayList<Integer> result = (ArrayList<Integer>) a.clone();
          result.retainAll(b);
          return result;
     }
     private static ArrayList<Integer> union(ArrayList<Integer> a, ArrayList<Integer> b){
          ArrayList<Integer> result = new ArrayList<Integer>();
          result.addAll(a);
          result.addAll(b);
          for (Integer e : intersection(a, b)) {
              result.remove(e);
          }
          return result;
     }
     private static ArrayList<Integer> subtract(ArrayList<Integer> a, ArrayList<Integer> b){
          ArrayList<Integer> result = new ArrayList<Integer>();
          result.addAll(a);
          for (Integer e : intersection(a, b)) {
              result.remove(e);
          }
          return result;
     }
     
         
}