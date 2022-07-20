import java.util.HashMap;

import src.Database;
import src.View;
import src.SearchEngine;

public class Main {
     public static void main(String[] args) {
          runProgram();
     }

     private static void runProgram() {
          Database.loadData();
          indexData(Database.getDataSet());
          View.run();
     }

     private static void indexData(HashMap<String, String> dataSet) {
          dataSet.forEach((fileName, fileContent) -> {
               SearchEngine.addFile(fileName, fileContent);
          });
     }
}
