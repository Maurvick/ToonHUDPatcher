namespace HUDpatcher
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "HUDpatcher";
            // Fix CP icons doesn't work on sv_pure servers
            try
            {
                CreateReferenceToPreload();
                MoveFilesFromSprites();
                CreateControlPointIcons();
                CreateExtrasFolder();
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("CP icons should work on valve servers.");

            // Keep console window open in debug mode.
            Console.Write("\nPress any key to exit: ");
            Console.ReadKey();
        }

        static void CreateReferenceToPreload()
        {
            // Add specific line into file 
            string filePath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\mainmenuoverride.res";
            var fileText = File.ReadAllLines(filePath).ToList();
            
            // Check if line already exists
            if (!fileText.Any(line => line.Equals("#base \"../../resource/extras/preload.res\"")))
            {
                // Try catch possible exception of file can be used in other process
                try
                {
                    fileText.Insert(0, "#base \"../../resource/extras/preload.res\"");
                    File.WriteAllLines(filePath, fileText);
                    Console.WriteLine("Created #base in mainmenuoverride.res");
                }
                catch (FileLoadException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            else
            {
                Console.WriteLine("Created #base in mainmenuoverride.res");
            }     
        }

        static void MoveFilesFromSprites()
        {
            // Copy files of targeted folder
            string sourceFile = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\sprites\obj_icons";
            string destinationFile = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\temp";

            // Move files to targeted folder, if exists pass
            if (Directory.Exists(destinationFile))
            {    
                Console.WriteLine("Moved files from sprites/obj_icons to temp.");
            }
            else
            {
                Directory.Move(sourceFile, destinationFile);
                Console.WriteLine("Moved files from sprites/obj_icons.");
            }
        }

        static void CreateControlPointIcons()
        {
            // Copy files of targeted folder
            string sourcePath = @"..\..\..\ToonHUD\materials\sprites\obj_icons";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\sprites\obj_icons";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath);
            string destFile = Path.Combine(targetPath);

            // To copy a folder's contents to a new location:
            // Create a new target folder.
            // If the directory already exists, this method does not create a new directory.
            Directory.CreateDirectory(targetPath);
        }

        static void CreateExtrasFolder()
        {
            // Copy files of targeted folder
            string sourcePath = @"..\..\..\ToonHUD\resource\extras\";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\extras\";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath);
            string destFile = Path.Combine(targetPath);

            // To copy a folder's contents to a new location:
            // Create a new target folder.
            // If the directory already exists, this method does not create a new directory.
            Directory.CreateDirectory(targetPath);
        }
    }
}
