package src.enums;

public enum ColorCodes {

     ANSI_RESET("\u001B[0m"),
     RED_BOLD("\033[1;31m"),
     GREEN_BOLD("\033[1;32m");

     private final String code;

     ColorCodes(String code) {
          this.code = code;
     }

     public String getCode() {
          return this.code;
     }
}
