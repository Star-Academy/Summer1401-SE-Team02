package src;

import java.io.File;
import java.util.HashMap;

import src.enums.Constants;

public class Database {

     private static HashMap<String, String> dataSet;

     static {
          dataSet = new HashMap<>();
     }

     public static void loadData() {
          File directory = new File(Constants.DOCS_FOlDER.toString());
          for (File file : directory.listFiles()) {
               dataSet.put(file.getName(), FileReader.readFile(file));
          }
     }

     public static HashMap<String, String> getDataSet() {
          return dataSet;
     }

}
