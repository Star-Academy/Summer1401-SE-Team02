package src;

import java.io.File;
import java.util.Scanner;

public class FileReader {

     public String readFile(File file) {
          try {
               Scanner scanner = new Scanner(file);
               StringBuilder text = new StringBuilder();
               while (scanner.hasNextLine())
                    text.append(scanner.nextLine() + " ");
               scanner.close();
               return text.toString();
          } catch (Exception e) {
               return new String();
          }

     }
}
