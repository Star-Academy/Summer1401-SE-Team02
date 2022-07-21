package src.models;

import java.util.ArrayList;

public class SimpleQuery implements QueryInterface {

     private ArrayList<String> includingWords;
     private String query;

     public SimpleQuery(String query){
          this.query = query; 
          this.includingWords = new ArrayList<>();
     }

     @Override
     public ArrayList<String> getIncludingWords() {
          return this.includingWords;
     }

     @Override
     public ArrayList<String> getExcludingWords() {
          return new ArrayList<String>();
     }

     @Override
     public ArrayList<String> getLeastPresencengWords() {
          return new ArrayList<String>();
     }

     @Override
     public void process() {
          this.includingWords.add(this.query);
     }

}
