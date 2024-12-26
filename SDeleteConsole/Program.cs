using System.Diagnostics;

string sdeletePath = @"D:\Documents\SDelete\sdelete.exe";
string[] FOLDERPATHS = [
    @"D:\Downloads\BizboxA",
    @"D:\Documents\BizboxA",
    //@"D:\Pictures\Screenshots",
    //@"D:\Pictures\DesktopBackground",
    //@"D:\Pictures\PhotoScape X",
    //@"D:\Documents\Bandicam",
    @"D:\FBKR_SCAN",
    //@"D:\OneDrive - (주)종합건축사사무소 동일건축",
    //@"D:\Obsidian",
    //@"D:\DBMS",
    //@"D:\Backup",

];
foreach (var folderPath in FOLDERPATHS)
{
    if (!Directory.Exists(folderPath))
    {
        Console.WriteLine("Error: The specified folder does not exist.");
        return;
    }

    if (!File.Exists(sdeletePath))
    {
        Console.WriteLine("Error: sdelete.exe not found.");
        return;
    }

    string[] files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

    foreach (var file in files)
    {
        Console.WriteLine("Deleting files: " + file);

        Process process = new Process();
        process.StartInfo.FileName = sdeletePath;
        process.StartInfo.Arguments = $"-p 10 \"{file}\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.Start();
        process.WaitForExit();
    }

    string[] directories = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories);
    Array.Reverse(directories);

    foreach (var directory in directories)
    {
        Console.WriteLine("Deleting directorys: " + directory);
        Directory.Delete(directory); // 빈 디렉토리 삭제
    }

    // 3. 최상위 디렉토리 삭제
    //if (Directory.Exists(folderPath) && Directory.GetFiles(folderPath).Length == 0 && Directory.GetDirectories(folderPath).Length == 0)
    //{
    //    Console.WriteLine("Deleting Root Directory: " + folderPath);
    //    Directory.Delete(folderPath);
    //}
}