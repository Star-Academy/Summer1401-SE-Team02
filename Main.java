public class Main {      
     public static void main(String[] args) {
          runProgram();
     }

     private static void runProgram(){
          Database.loadData();
          View.run();
     }
}
