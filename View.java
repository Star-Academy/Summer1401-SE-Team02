import java.util.Scanner;

public class View {
     private static final String END_PROGRAM = "-1";
     private static final Scanner scanner;

     static {
          scanner = new Scanner(System.in);
     }

     public static void run(){
          String command;
          while (!(command = scanner.nextLine()).equals(END_PROGRAM)){
               System.out.println(SearchEngine.search(command.toUpperCase()));
          }
          scanner.close();
     }
}
