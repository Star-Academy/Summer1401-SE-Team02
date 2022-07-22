package src.models;

import java.util.ArrayList;

public interface QueryInterface{
     public ArrayList<String> getIncludingWords();
     public ArrayList<String> getExcludingWords();
     public ArrayList<String> getLeastPresencengWords();
     public void process();
}