import java.util.HashMap;

import src.Database;
import src.View;
import src.SearchEngine;
import src.Normalizer;

public class Main {
     public static void main(String[] args) {
          runProgram();
     }

     private static void runProgram() {
          Database database = new Database();
          SearchEngine searchEngine = new SearchEngine();
          database.loadData();
          indexData(database.getDataSet(), searchEngine);
          new View().run(searchEngine);
     }

     private static void indexData(HashMap<String, String> dataSet, SearchEngine searchEngine) {
          Normalizer normalizer = new Normalizer();
          dataSet.forEach((fileName, fileContent) -> {
               searchEngine.addFile(fileName, normalizer.normalize(fileContent));
          });
     }
}
