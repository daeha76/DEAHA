using System.Diagnostics;
using System.Reflection;

string userInput = string.Empty;
do
{
    Console.WriteLine("Secure File Deletion Program");

    string sdeletePath = ExtractSDelete();

    if (!File.Exists(sdeletePath))
    {
        Console.WriteLine("Error: sdelete.exe not found. Make sure it is included in the project.");
        return;
    }

    Console.Write("1. Enter the path of the folder you want to securely delete:");
    string pathInput = Console.ReadLine();
    string path = pathInput.Replace("\"", "").Trim();

    Console.Write("2. Enter the number of overwrite passes (default is 3):");
    string countInput = Console.ReadLine();
    byte count = byte.TryParse(countInput, out byte result) ? result : (byte)3;

    bool isFolder = Directory.Exists(path);
    bool isFile = File.Exists(path);

    if (string.IsNullOrEmpty(path) || (!isFile && !isFolder))
    {
        Console.WriteLine("Error: The specified file or folder does not exist.");
        return;
    }

    try
    {
        if (isFile)
        {
            SDeleteFile(sdeletePath, path, count);
            Console.WriteLine("Specified file has been securely deleted.: " + path);
        }
        else
        {
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                SDeleteFile(sdeletePath, file, count);
            }

            string[] directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            Array.Reverse(directories);
            foreach (var directory in directories)
            {
                Console.WriteLine("Deleting empty directory: " + directory);
                if (Directory.Exists(directory) && Directory.GetFileSystemEntries(directory).Length == 0)
                {
                    Directory.Delete(directory);
                }
            }

            if (Directory.Exists(path) && Directory.GetFileSystemEntries(path).Length == 0)
            {
                Console.WriteLine("Deleting root directory: " + path);
                Directory.Delete(path);
            }

            Console.WriteLine("All specified files and folders have been securely deleted.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }

    static string ExtractSDelete()
    {
        string resourceName = "SDeleteConsole.sdelete.exe"; // 프로젝트 네임스페이스에 맞게 변경
        string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sdelete.exe");

        if (!File.Exists(outputPath))
        {
            try
            {
                using (Stream resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to extract sdelete.exe: " + ex.Message);
                return null;
            }
        }

        return outputPath;
    }
 
    static void SDeleteFile(string sdeletePath, string file, byte count = 3)
    {
        Console.WriteLine("Securely deleting file: " + file);

        Process process = new Process();
        process.StartInfo.FileName = sdeletePath;
        Console.WriteLine($"-p {count} \"{file}\"");
        process.StartInfo.Arguments = $"-p {count} \"{file}\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.Start();
        process.WaitForExit();

        if (File.Exists(file))
        {
            File.Delete(file);
        }
    }
    bool isValidInput = false;
    do
    {
        Console.Write("Do you want to run the program again? (y/n):");
        userInput = Console.ReadLine().Trim().ToLower();
        isValidInput = userInput == "n" || userInput == "y";

        if (!isValidInput)
        {
            Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
        }
        else if (userInput == "n")
        {
            Console.WriteLine("Program terminated. Goodbye!");
        }
    } while (!isValidInput);
} while (userInput == "y");
Console.WriteLine("Press any key to exit...");



