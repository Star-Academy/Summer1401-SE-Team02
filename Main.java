import java.io.File;

import java.util.Scanner;

public class Main {
     public static void main(String[] args) {
          runProgram();
     }

     private static void runProgram(){
          loadData();
          getQueries();
     }

     
     private static void getQueries(){
          Scanner scanner = new Scanner(System.in);
          String word;
          while (!(word = scanner.nextLine()).equals("-1")){
               System.out.println(SearchEngine.search(word));
          }
     }
     private static void loadData(){
          try {
               loadFiles();               
          } catch (Exception e) {
               System.out.println(e);
          }
     }

     private static void loadFiles() throws Exception{
          File directory = new File("Docs");
          for (File file : directory.listFiles()) {
               loadFile(file);
          }    
     }

     private static void loadFile(File file) throws Exception{
          Scanner scanner = new Scanner(file);
          StringBuilder text = new StringBuilder();
          while(scanner.hasNextLine()){
               text.append(scanner.nextLine() + " ");
          }
          System.out.println(file.getName() + " :: ");
          System.out.println(text + "\n");
          SearchEngine.addFile(text.toString(), file.getName());
          scanner.close();
     }
}
