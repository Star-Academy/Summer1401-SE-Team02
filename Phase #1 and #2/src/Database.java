package src;

import java.io.File;
import java.util.HashMap;

import src.enums.Constants;

public class Database {

     private HashMap<String, String> dataSet;
     private FileReader fileReader;

     public Database(){
          this.dataSet = new HashMap<>();
          this.fileReader = new FileReader();
     }

     public void loadData() {
          File directory = new File(Constants.DOCS_FOlDER.toString());
          for (File file : directory.listFiles()) {
               dataSet.put(file.getName(), this.fileReader.readFile(file));
          }
     }

     public HashMap<String, String> getDataSet() {
          return dataSet;
     }

}
