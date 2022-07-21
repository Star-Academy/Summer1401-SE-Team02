package src;

import java.util.ArrayList;

public class OrderedSet {

     public ArrayList<Integer> intersection(ArrayList<Integer> a, ArrayList<Integer> b) {
          ArrayList<Integer> result = (ArrayList<Integer>) a.clone();
          result.retainAll(b);
          return result;
     }

     public ArrayList<Integer> union(ArrayList<Integer> a, ArrayList<Integer> b) {
          ArrayList<Integer> result = new ArrayList<Integer>();
          result.addAll(a);
          result.addAll(b);
          for (Integer e : intersection(a, b)) {
               result.remove(e);
          }
          return result;
     }

     public ArrayList<Integer> subtract(ArrayList<Integer> a, ArrayList<Integer> b) {
          ArrayList<Integer> result = new ArrayList<Integer>();
          result.addAll(a);
          for (Integer e : intersection(a, b)) {
               result.remove(e);
          }
          return result;
     }

}
