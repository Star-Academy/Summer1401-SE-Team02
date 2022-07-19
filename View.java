import java.util.ArrayList;
import java.util.Scanner;

public class View {
     private static final Scanner scanner;

     static {
          scanner = new Scanner(System.in);
     }

     public static void run(){
          Query query;
          while (!(query = new Query(scanner.nextLine())).isEnd()){
               query.process();
               showOutput(SearchEngine.advanceSearch(query));
          }
          scanner.close();
     }

     private static void showOutput(ArrayList<String> output){
          System.out.println(output);
     }


}
