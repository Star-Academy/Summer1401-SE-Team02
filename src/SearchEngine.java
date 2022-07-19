package src;
import java.util.ArrayList;
import java.util.HashMap;


class SearchEngine{
     private static HashMap<String, ArrayList<Integer> > indexedData;
     public static HashMap<Integer, String> docNames;

     static{
          indexedData = new HashMap<>();
          docNames = new HashMap<>();
     }

     public static ArrayList<String> advanceSearch(Query query){
          return getDocNames(process(query));
     }

     private static ArrayList<Integer> getDocsList(String word){
          if (indexedData.containsKey(word.toUpperCase())) return indexedData.get(word.toUpperCase());
          return new ArrayList<Integer>();
     }

     public static void addFile(String text, String docID){
          docNames.put(docNames.size(), docID);
          for (String word : Normalizer.normalize(text)) addWord(word, docNames.size() - 1);
     }

     private static void addWord(String word, int docID){
          if (!indexedData.containsKey(word)) {
               ArrayList<Integer> docs = new ArrayList<>();
               docs.add(docID);
               indexedData.put(word, docs);
          }
          else insertDocID(word, indexedData.get(word), docID);
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
          for (int index : docIndexes) result.add(docNames.get(index));
          return result;
     }

     private static ArrayList<Integer> process(Query query){
          ArrayList<Integer> positiveWords = query.positiveWords.isEmpty()? new ArrayList<>(docNames.keySet()) : new ArrayList<>();
          ArrayList<Integer> simpleWords = new ArrayList<>(docNames.keySet());
          ArrayList<Integer> negativeWords = new ArrayList<>();

          for (String word : query.simpleWords) simpleWords = OrderedSet.intersection(simpleWords, getDocsList(word));
          for (String word : query.negativeWords) negativeWords = OrderedSet.union(negativeWords, getDocsList(word));
          for (String word : query.positiveWords) positiveWords = OrderedSet.union(positiveWords, getDocsList(word));

          return OrderedSet.subtract(OrderedSet.intersection(simpleWords, positiveWords), negativeWords);
     }
         
}