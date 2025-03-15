public class App {
    public static void main(String[] args) throws Exception 
    {
    String[] input = new String[] {
     // have your data be here
    };

    int ans = executePartOne(input, input.length);
    System.out.println("solution to Part One is: " + ans);
    int secondAns = executePartTwo(input, input.length);
    System.out.println("solution to Part Two is: ");
    System.out.print(secondAns);
    }

    public static int executePartOne(String[] arr, int totArrLength)
    {
        int output = 0;
        int arrVal;
        int arrLen;
        for(int arrProgress = 0; arrProgress < totArrLength; arrProgress++){
            arrVal = 0;
            arrLen = arr[arrProgress].length();
            for(int i = 0; i < arrLen; i++){
                if(isNumNum(arr[arrProgress].substring(i, i+1))){
                    arrVal += 10*getNumNum(arr[arrProgress].substring(i, i+1));
                    i = arrLen;
                }
            }
            for(int j = arrLen-1; j >= 0; j--){
                if(isNumNum(arr[arrProgress].substring(j, j+1))){
                    arrVal += getNumNum(arr[arrProgress].substring(j, j+1));
                    j = -1;
                }
            }
            output += arrVal;
        }
        return output;

    }

    private static int executePartTwo(String[] arr, int totArrLength)
    {
        int output = 0;
        int arrVal;
        int arrLen;
        int checkedInt;
        String letter;
        String[] numList = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
        String check;
        for(int arrProgress = 0; arrProgress < totArrLength; arrProgress++){
            arrVal = 0;
            arrLen = arr[arrProgress].length();
            for(int i = 0; i < arrLen; i++){
                letter = arr[arrProgress].substring(i,i+1);
                if(isNumNum(letter)){
                    arrVal += 10*getNumNum(letter);
                    i = arrLen;
                }
                else if(letter.equals("n")){
                    check = checkN(arr[arrProgress], i);
                    checkedInt = isWord(check, numList);
                    if(checkedInt >= 0){
                        arrVal += 10*checkedInt;
                        i = arrLen;
                    }
                }
                else if(letter.equals("o")){
                    check = checkO(arr[arrProgress], i);
                    checkedInt = isWord(check, numList);
                    if(checkedInt >= 0){
                        arrVal += 10*checkedInt;
                        i = arrLen;
                    }
                    checkedInt = -1;
                }
                else if(letter.equals("t")){
                    check = checkT(arr[arrProgress], i);
                    checkedInt = isWord(check, numList);
                    if(checkedInt >= 0){
                        arrVal += 10*checkedInt;
                        i = arrLen;
                    }
                    checkedInt = -1;
                }
                else if(letter.equals("i")){
                    check = checkI(arr[arrProgress], i);
                    checkedInt = isWord(check, numList);
                    if(checkedInt >= 0){
                        arrVal += 10*checkedInt;
                        i = arrLen;
                    }
                    checkedInt = -1;
                }

            }
            for (int q = arrLen-1; q >=0; q--){
                letter = arr[arrProgress].substring(q,q+1);
                if(isNumNum(letter)){
                    arrVal += getNumNum(letter);
                    q = -1;
                }
                else if(letter.equals("n")){
                    check = checkN(arr[arrProgress], q);
                    checkedInt = isWord(check, numList);
                    if(checkedInt >= 0){
                        arrVal += checkedInt;
                        q = -1;
                    }
                    checkedInt = -1;
                }
                else if(letter.equals("o")){
                    check = checkO(arr[arrProgress], q);
                    checkedInt = isWord(check, numList);
                    if(checkedInt >= 0){
                        arrVal += checkedInt;
                        q = -1;
                    }
                    checkedInt = -1;
                }
                else if(letter.equals("t")){
                    check = checkT(arr[arrProgress], q);
                    checkedInt = isWord(check, numList);
                    if(checkedInt >= 0){
                        arrVal += checkedInt;
                        q = -1;
                    }
                    checkedInt = -1;
                }
                else if(letter.equals("i")){
                    check = checkI(arr[arrProgress], q);
                    checkedInt = isWord(check, numList);
                    if(checkedInt >= 0){
                        arrVal += checkedInt;
                        q = -1;
                    }
                    checkedInt = -1;
                }
            }
            output += arrVal;
        }
        return output;
    }

    private static boolean isNumNum(String x)
    {
        String idk;
        int ans = 0;
        for(int j = 0; j < 10; j++){
            idk = Integer.toString(j);
            if(idk.equals(x)){
                ans++;
            }
        }
        if(ans > 0){
            return true;
        }
        return false;
    }

    private static int getNumNum(String x)
    {
        return Integer.parseInt(x); //changes 1 letter String into an Integer
    }

    private static int isWord(String word, String[] list) //double check...Not needed 
    {
        for(int i = 0; i < list.length; i++){
            if (word.equals(list[i])){
                return Integer.parseInt(word);
            }
        }
        return -1;
    }

    private static String checkN(String mesh, int location)
    {
        if(location >= 1 && location < mesh.length()-1){
            if(mesh.substring(location-1, location).equals("o")){
                if(mesh.substring(location+1,location+2).equals("e")){
                    return "1";
                }
            }
        }
        if(location >= 4){
            if(mesh.substring(location-4, location+1).equals("seven")){
                return "7";
            }
        }
        if(location >=0 && location + 4 <= mesh.length()){
            if(mesh.substring(location, location+4).equals("nine")){
                return "9";
            }
        }
        if(location >= 2 && location + 2 <= mesh.length()){
            if(mesh.substring(location-2,location+2).equals("nine")){
                return "9";
            }
        }
        return "";
    }

    private static String checkO(String mesh, int location)
    {
        if(location>=2){
            if(mesh.substring(location-2, location+1).equals("two")){
                return "2";
            }
        }
        if(location >= 1 && location +3 <= mesh.length()){
            if(mesh.substring(location-1, location+3).equals("four")){
                return "4";
            }
        }
        return "";
    }

    private static String checkT(String mesh, int location)
    {
        if(location + 5 <= mesh.length()){
            if(mesh.substring(location, location+5).equals("three")){
                return "3";
            }
        }
        return "";
    }

    private static String checkI(String mesh, int location)
    {
        if(location >= 1 && location + 3 <= mesh.length()){
            if(mesh.substring(location-1, location+3).equals("five")){
                return "5";
            }
        }
        if(location >=1 && location + 2 <= mesh.length()){
            if(mesh.substring(location-1, location+2).equals("six")){
                return "6";
            }
        }
        if(location >=1 && location + 4 <= mesh.length()){
            if(mesh.substring(location-1, location+4).equals("eight")){
                return "8";
            }
        }
        return "";
    }
}
