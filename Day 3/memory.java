import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.regex.Pattern;
import java.util.regex.Matcher;

public class Memory {

    public static String readGibberishFile(String path) {
        String gibberish = "";
        try (BufferedReader bufferedReader = new BufferedReader(new FileReader(path))) {
            String line;
            while ((line = bufferedReader.readLine()) != null) {
                gibberish += line;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return gibberish;
    }

    public static int parseGibberish(String gibberish) {
        int total = 0;

        Pattern pattern = Pattern.compile("mul[(]\\d{1,3}[,]\\d{1,3}[)]");
        Matcher matcher = pattern.matcher(gibberish);

        System.out.println("Gibberish:\n" + gibberish + "\n");

        while (matcher.find()) {
            String match = matcher.group();
            String numbers = match.substring(match.indexOf("(") + 1, match.indexOf(")"));
            int firstNum = Integer.parseInt(numbers.split(",")[0]);
            int secondNum = Integer.parseInt(numbers.split(",")[1]);
            System.out.println("\nFirst number: " + firstNum + "\tSecond number: " + secondNum);
            total += firstNum * secondNum;
            System.out.println("Product: " + (firstNum * secondNum));
        }

        return total;
    }

    public static void main(String[] args) {
        String gibberish = readGibberishFile("data.txt");
        int total = parseGibberish(gibberish);
        System.out.println("\nThe total is: " + total);
    }

}