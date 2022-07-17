import java.io.File;

import java.util.Scanner;

public class Main {
     public static void main(String[] args) {
          runProgram();
     }

     private static void runProgram(){
          try {
               loadFiles();               
          } catch (Exception e) {
               System.out.println(e);
          }

          Scanner scanner = new Scanner(System.in);
          for (int i = 0; i < 5; i++) {
               System.out.println(SearchEngine.search(scanner.nextLine()));
          }
     }

     private static void loadFiles() throws Exception{
          File directory = new File("Summer1401-SE-Team02/Docs");
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
