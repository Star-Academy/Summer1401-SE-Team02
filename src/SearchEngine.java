package src;

import java.util.ArrayList;
import java.util.HashMap;
import src.models.QueryInterface;

public class SearchEngine {
     private HashMap<String, ArrayList<Integer>> indexedData;
     public HashMap<Integer, String> docNames;

     public SearchEngine() {
          this.indexedData = new HashMap<>();
          this.docNames = new HashMap<>();
     }

     public ArrayList<String> advanceSearch(QueryInterface query) {
          return getDocNames(process(query));
     }

     private ArrayList<Integer> getDocsList(String word) {
          if (indexedData.containsKey(word.toUpperCase()))
               return indexedData.get(word.toUpperCase());
          return new ArrayList<Integer>();
     }

     public void addFile(String docId, ArrayList<String> tokens) {
          docNames.put(docNames.size(), docId);
          for (String word : tokens)
               addWord(word, docNames.size() - 1);
     }

     private void addWord(String word, int docID) {
          if (!indexedData.containsKey(word)) {
               ArrayList<Integer> docs = new ArrayList<>();
               docs.add(docID);
               indexedData.put(word, docs);
          } else
               insertDocID(word, indexedData.get(word), docID);
     }

     private void insertDocID(String word, ArrayList<Integer> docsIDs, int docID) {
          if (!indexedData.get(word).contains(docID)) {
               docsIDs.add(docID);
               indexedData.put(word, docsIDs);
          }
     }

     private ArrayList<String> getDocNames(ArrayList<Integer> docIndexes) {
          if (docIndexes == null)
               return null;
          ArrayList<String> result = new ArrayList<>();
          for (int index : docIndexes)
               result.add(docNames.get(index));
          return result;
     }

     private ArrayList<Integer> process(QueryInterface query) {
          OrderedSet orderedSet = new OrderedSet();
          ArrayList<Integer> positiveWords = query.getLeastPresencengWords().isEmpty()
                    ? new ArrayList<>(docNames.keySet())
                    : new ArrayList<>();
          ArrayList<Integer> simpleWords = new ArrayList<>(docNames.keySet());
          ArrayList<Integer> negativeWords = new ArrayList<>();

          for (String word : query.getIncludingWords())
               simpleWords = orderedSet.intersection(simpleWords, getDocsList(word));
          for (String word : query.getExcludingWords())
               negativeWords = orderedSet.union(negativeWords, getDocsList(word));
          for (String word : query.getLeastPresencengWords())
               positiveWords = orderedSet.union(positiveWords, getDocsList(word));

          return orderedSet.subtract(orderedSet.intersection(simpleWords, positiveWords), negativeWords);
     }

}