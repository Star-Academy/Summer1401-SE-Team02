package src;

import java.util.ArrayList;
import java.util.Scanner;

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
               error("Oops! no result ...");
          else
               success(output);
     }

     private static void error(String message) {
          System.out.println(String.format(Constants.ERROR_MESSAGE.toString(), message));
     }

     private static void success(ArrayList<String> output) {
          System.out.println(String.format(Constants.SUCCESS_MESSAGE.toString(), output.size(), output));
     }

}
