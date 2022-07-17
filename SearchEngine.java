import java.util.ArrayList;
import java.util.HashMap;

class SearchEngine{
     private static HashMap<String, ArrayList> indexedData;
     static {
          indexedData = new HashMap<>();
     }

     public static ArrayList<String> search(String word){
          return null;
     }

     public static void addFile(String text, String docID){
          //TODO tokenize the text and add each word to our indexed database
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