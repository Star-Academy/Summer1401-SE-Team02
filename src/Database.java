package src;
import java.io.File;
import java.util.Scanner;

public class Database {
     private static final String DATA_FOLDER = "Docs";
     
     public static void loadData(){
          try {
               loadFilesToSearchEngine();               
          } catch (Exception e) {
               System.out.println(e);
          }
     }

     private static void loadFilesToSearchEngine() throws Exception{
          File directory = new File(DATA_FOLDER);
          for (File file : directory.listFiles()) {
               SearchEngine.addFile(loadFile(file), file.getName());
          }    
     }

     private static String loadFile(File file) throws Exception{
          Scanner scanner = new Scanner(file);
          StringBuilder text = new StringBuilder();
          while(scanner.hasNextLine()) text.append(scanner.nextLine() + " ");
          scanner.close();
          return text.toString();
     }
}
