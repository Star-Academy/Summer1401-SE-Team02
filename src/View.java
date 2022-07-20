package src;

import java.util.ArrayList;
import java.util.Scanner;

import src.enums.ColorCodes;
import src.enums.Constants;

public class View {

     private static final Scanner scanner;

     static {
          scanner = new Scanner(System.in);
     }

     public static void run() {
          Query query;
          while (isNotEnd(query = new Query(scanner.nextLine()))) {
               query.process();
               showOutput(SearchEngine.advanceSearch(query));
          }
          scanner.close();
     }

     private static boolean isNotEnd(Query query) {
          return !query.getValue().equals(Constants.END_OF_PROGRAM.toString());
     }

     private static void showOutput(ArrayList<String> output) {
          if (output.isEmpty())
               _error("Oops! no result ...");
          else
               _success(output);
     }

     private static void _error(String message) {
          System.out.println(ColorCodes.RED_BOLD.getCode() + "! " + ColorCodes.ANSI_RESET.getCode() + message);
     }

     private static void _success(ArrayList<String> output) {
          System.out.println(String.format("%s+ %snumber of search results: %d\n%s",
                    ColorCodes.GREEN_BOLD.getCode(), ColorCodes.ANSI_RESET.getCode(), output.size(), output));
     }

}
