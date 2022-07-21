package src;

import java.util.ArrayList;
import java.util.Scanner;

import src.enums.Constants;
import src.models.MultiWordQuery;
import src.models.QueryInterface;


public class View {

     private final Scanner scanner;

     public View(){
          this.scanner = new Scanner(System.in);
     }

     public void run(SearchEngine searchEngine) {
          QueryInterface query;
          String command;
          while (!(command = scanner.nextLine()).equals(Constants.END_OF_PROGRAM.toString())) {
               query = new MultiWordQuery(command);
               query.process();
               showOutput(searchEngine.advanceSearch(query));
          }
          scanner.close();
     }

     private void showOutput(ArrayList<String> output) {
          if (output.isEmpty())
               error("Oops! no result ...");
          else
               success(output);
     }

     private void error(String message) {
          System.out.println(String.format(Constants.ERROR_MESSAGE.toString(), message));
     }

     private void success(ArrayList<String> output) {
          System.out.println(String.format(Constants.SUCCESS_MESSAGE.toString(), output.size(), output));
     }

}
