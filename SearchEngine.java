import java.util.ArrayList;
import java.util.HashMap;

class SearchEngine{
     private static HashMap<String, ArrayList<Integer> > indexedData;
     public static HashMap<Integer, String> docNames;

     static{
          indexedData = new HashMap<>();
          docNames = new HashMap<>();
     }

     public static ArrayList<String> search(String query){
          return getDocNames(processQuery(query.split("\\s+")));
     }

     private static ArrayList<Integer> getDocsList(String word){
          if (indexedData.containsKey(word.toUpperCase())) return indexedData.get(word);
          return new ArrayList<Integer>();
     }

     private static ArrayList<Integer> processQuery(String[] queryParts){
          ArrayList<Integer> result = new ArrayList<>();
          ArrayList<Integer> result_plus = new ArrayList<>();
          boolean[] flags = {false, false};
          for (String query : queryParts){
               if (query.startsWith("+")) {
                    flags[0] = true;
                    result_plus = union(result_plus, getDocsList(query.substring(1)));
               }
               else if (query.startsWith("-")) result = subtract(result, getDocsList(query.substring(1)));
               else{
                    flags[1] = true;
                    if (result.isEmpty()) result = getDocsList(query);
                    else result = intersection(result, getDocsList(query));
               }
               
          }
          if (flags[0]){
               return (flags[1]) ? intersection(result, result_plus) : result_plus;
          }else return result;
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