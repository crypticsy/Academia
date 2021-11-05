/**
 * @author Crypticsy
 */

package Opticalog.Main;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;



public class Algorithms {
    
    
    private int sortOrder;  // 0 represents ascending and 1 represents descending
    private int category;
    
    public Algorithms(){
        sortOrder = -1;
        category = -1;
    }
    
    
    public void setSortOrder(int val){
        sortOrder = val;
    }
    
    public void setCategory(int val){
        category = val;
    }  
    
    public int getSortOrder(){
        return sortOrder;
    }
    
    public int getCategory(){
        return category;
    }  
    
    
    
    
    
    
    /**
     * Compares and identifies the order of the two strings
     * @param str1: first string to compare
     * @param str2: second string to compare
     * @return int: positive value represents higher order, negative value lower order and zero represents the string are same 
     */
    private int compareString(String str1, String str2){
        
        int l1 = str1.length(); 
        int l2 = str2.length(); 
        int lmin = Math.min(l1, l2); 
        for (int i = 0; i < lmin; i++) { 
            int str1_ch = (int)str1.charAt(i);      // Obtain the ascii value of the character of the string at position i
            int str2_ch = (int)str2.charAt(i);      // Obtain the ascii value of the character of the string at position i 
            if (str1_ch != str2_ch) return str1_ch - str2_ch;       // Compare the ascii value of the two characters
        } 
        return l1 != l2 ?  l1 - l2 : 0;     // Check for length difference between the strings  
    }
    
    
    /**
     * Compares and identifies the order of the values defined by the left and right head
     * @param leftHead:  index of the first value
     * @param rightHead: index of the second value
     * @param values: an array list of rows of data
     * @return Boolean: true represents use left index and false represents use right index 
     */
    private boolean compareValues(int leftHead, int rightHead, List<String[]> values){
       
        if(category!=4){         
           // Use integer as comparision for price field
           int tempCategory = category;
           if (tempCategory == -1) tempCategory = 0;
           int compare = compareString(values.get(leftHead)[tempCategory], values.get(rightHead)[tempCategory]);
           return sortOrder==0 ? compare < 0 : compare > 0 ;        // Handle ascending|descending order
           
       }else{
           // Use String as comparision for other fields 
           boolean compare = Integer.valueOf(values.get(leftHead)[category]) <  Integer.valueOf(values.get(rightHead)[category]);
           return sortOrder==0? compare : !compare;                 // Handle ascending|descending order   
       }
    }
    
    
    /**
     * Sorts the input array list depending upon the sort order and filter selected
     * @param data: an array list of integers representing the index 
     * @param details: an array list of rows of data
     * @return sortedData: an array list of integers representing the sorted index
     */
    public List<Integer> mergeSort(List<Integer> data, List<String[]> details){
        
        if(data.size()<2) return data;      // Base case
        
        int mid = (int)data.size()/2;
        List<Integer> leftside = mergeSort( data.subList( 0, mid), details);               // Break half of the intial list and sort the first half through recursion
        List<Integer> rightside = mergeSort( data.subList( mid, data.size()), details);    // Break half of the intial list and sort the second half through recursion
        
        List<Integer> sortedData = new ArrayList<>();       // Store the sorted list
        
        int leftDex=0, rightDex=0;
        
        while(leftDex < leftside.size() && rightDex < rightside.size() ){                               // Breaking the loop only when the index of one of the half goes beyond it's final element
            if( compareValues( leftside.get(leftDex), rightside.get(rightDex), details) ){
                sortedData.add(leftside.get(leftDex));
                leftDex++;
            }else{
                sortedData.add(rightside.get(rightDex));
                rightDex++;
            }
        }
        
        for(int i = leftDex; i<leftside.size(); i++){       // Handle case for left out elements of first half of the initial list
            sortedData.add(leftside.get(i));
        }
        
        for(int i = rightDex; i<rightside.size(); i++){     // Handle case for left out elements of second half of the initial list
            sortedData.add(rightside.get(i));
        }
                
        return sortedData;
        
    }
    
    
    
    
    
    
    /**
     * Uses Binary search to find the exact value that the user is searching for
     * @param searchFor: a string  representing the value the user is searching
     * @param indexes: an array list of integers representing the index 
     * @param details: an array list of rows of data
     * @return searchList: an array list of integers representing the values that match the searchFor string
     */
    public List<Integer> BinarySearch(String searchFor, List<Integer> Indexes, List<String[]> details){
        
        List<Integer> searchList = new ArrayList();
        
        int left = 1, right = Indexes.size();       // Initializing boundary for search
        
        while (left <= right){
            int mid = (int) (left + right)/2;       // Obtain the mid point from the boundary
            int compare;
            
            if (category != 4) {                    // Using string as comparator for all elements except price
                compare = compareString( searchFor.toLowerCase() , details.get(Indexes.get(mid-1))[category].toLowerCase());
                
            }else{                                  // Using integer as comparator for only price
                compare = Integer.parseInt(searchFor) - Integer.parseInt(details.get(Indexes.get(mid-1))[4]);
            }
            compare = sortOrder == 0 ? -compare : compare ;         // Handling ascending|descending order
            
            
            if (compare < 0 ){
                left = mid + 1;             // Updating the left side of the boundary to above mid
                
            }else if (compare > 0){
                right = mid - 1;            // Updating the right side of the boundary to below mid
                
            }else{
                
                searchList.add(Indexes.get(mid-1));         // Add the first element that matched the search 
                
                // Add the rest of the elements that matched the search 
                for(int i : Arrays.asList(-1,1)){           // Linear search on above and botoom from the first matched position
                    int pos = mid + i;
                    
                    while( pos > 0 && pos <= Indexes.size() && searchFor.toLowerCase().equals( details.get(Indexes.get(pos-1))[category].toLowerCase() ) ){
                        searchList.add(Indexes.get(pos-1));                  
                        pos += i;
                    }
                }
                break;
            }
        }
        return searchList;
    }
    
    
    
    
    
    /**
     * Compares the row of data with the search value for a match or mismatch
     * @param searchFor: a string  representing the value the user is searching
     * @param Row: a list of a single row of data
     * @return Boolean: true represents a match and false represents a mismatch
     */
    private boolean rowSelectiveSearch(String searchFor, String[] Row){
        
        if(category!=-1){           // Handling case where category is selected
            return searchFor.equals(Row[category].toLowerCase()) || Row[category].toLowerCase().contains(searchFor);
            
        }else{                      // Handling case where category is not selected allowing search between all fields
            for(String val: Row){
                if (searchFor.equals(val.toLowerCase()) || val.toLowerCase().contains(searchFor)) return true;
            }
        }   
        return false;
    }
    
    
    
    /**
     * Uses Linear search to find the both the exact value as well as the almost same value that the user is searching for
     * @param searchFor: a string  representing the value the user is searching
     * @param indexes: an array list of integers representing the index 
     * @param details: an array list of rows of data
     * @return searchList: an array list of integers representing the values that match the searchFor string
     */
    public List<Integer> LinearSearch(String searchFor, List<Integer> Indexes, List<String[]> details){
        
        List<Integer> searchList = new ArrayList();
        
        for(int pos: Indexes){
            if ( rowSelectiveSearch(searchFor.toLowerCase(), details.get(pos)) ) searchList.add(pos);
        }
        
        return searchList;
    }
    
    
}
