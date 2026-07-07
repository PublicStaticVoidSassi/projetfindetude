import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

public class FindAndReplace {
    public static void main(String[] args) {
	String[] targets = {
    		"contact",
    		"prospect",
    		"compte",
    		"opportunite",
    		"appel",
    		"tache",
    		"reunion",
    		"email",
    		"note"
	};

	for (String target : targets) {
    		replacer(target);
	}
    }

    public static void replacer(String target) {
        String sourceFile = "abstract crud.txt";
        String destinationFile = target + ".txt";
        String findText = "OBJET_UNIQUE_XYZ";
        String replaceText = target;

        try {
            // Read the entire file
            String content = Files.readString(Path.of(sourceFile));

            // Replace all occurrences
            String updatedContent = content.replace(findText, replaceText);

            // Write to the destination file
            Files.writeString(Path.of(destinationFile), updatedContent);

            System.out.println("File processed successfully.");
            System.out.println("Output written to: " + destinationFile);

        } catch (IOException e) {
            System.err.println("Error processing file: " + e.getMessage());
            e.printStackTrace();
        }
    }
}