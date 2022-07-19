import java.util.Scanner;

public class Main {      
     public static void main(String[] args) {
          runProgram();
     }

     private static void runProgram(){
          Database.loadData();
          getQueries();
     }
     
     private static void getQueries(){
          Scanner scanner = new Scanner(System.in);
          String command;
          while (!(command = scanner.nextLine()).equals("-1")){
               System.out.println(SearchEngine.search(command.toUpperCase()));
          }
          scanner.close();
     }
     
}
