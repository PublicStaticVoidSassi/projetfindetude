public class Main {

    public static void main(String[] args) {
String[] words = {
    "Lead",
    "Account",
    "Contact",
    "Opportunity",
    "Task",
    "Call",
    "Meeting",
    "Email",
    "Note"
};

for (String word : words) {
	String code = "\"Permission:"+word+"\":\""+word+"\",";

        System.out.println(code);
}
        
    }
}