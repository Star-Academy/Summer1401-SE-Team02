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
          
          return null;
     }

     private static void addWord(String word, String docID){
          //TODO: check whether the word is new or not. if its new, simply add it to the indexedData, else, insert the docID to the list.
          
     }

     private static void insertDocID(String word, ArrayList<String> docsIDs, String DocID){
          //TODO: insert the docID to the list and replace it in indexedData.
     }
}