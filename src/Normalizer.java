package src;

import java.util.ArrayList;
import java.util.Arrays;

import src.enums.Constants;

public class Normalizer {

    public static ArrayList<String> normalize(String text) {
        ArrayList<String> result = removeStopWords(tokenize(refine(text)),
                new ArrayList<String>(
                        Arrays.asList(
                                Constants.STOPPING_WORDS.toString().toUpperCase().split(Constants.SPACE.toString()))));
        return result;
    }

    private static ArrayList<String> tokenize(String text) {
        ArrayList<String> tokenized = new ArrayList<String>();
        for (String token : text.split("\\s+"))
            tokenized.add(token);
        return tokenized;
    }

    private static String refine(String text) {
        return text.replaceAll("[^a-zA-Z ]", "").toUpperCase();
    }

    private static ArrayList<String> removeStopWords(ArrayList<String> words, ArrayList<String> stopWords) {
        words.removeAll(stopWords);
        return words;
    }
}
