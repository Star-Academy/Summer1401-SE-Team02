package src;

import java.util.ArrayList;
import java.util.Arrays;

import src.enums.Constants;

public class Normalizer {

    public ArrayList<String> normalize(String text) {
        String[] stoppingWords = Constants.STOPPING_WORDS.toString().toUpperCase().split(Constants.SPACE.toString());
        ArrayList<String> result = removeStopWords(tokenize(refine(text)),
                new ArrayList<String>(Arrays.asList(stoppingWords)));
        return result;
    }

    private ArrayList<String> tokenize(String text) {
        return new ArrayList<String>(Arrays.asList(text.split(Constants.SPACE.toString())));
    }

    private String refine(String text) {
        return text.replaceAll("[^a-zA-Z ]", "").toUpperCase();
    }

    private ArrayList<String> removeStopWords(ArrayList<String> words, ArrayList<String> stopWords) {
        words.removeAll(stopWords);
        return words;
    }
}
