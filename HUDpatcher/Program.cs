namespace HUDpatcher
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "HUDpatcher";
            
            // Catch exception if unable to find path to folder
            try
            {
                MoveFilesFromSprites();
                CreateReferenceToPreload();
                CreateControlPointIcons();
                CreateExtrasFolder();
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        static void CreateReferenceToPreload()
        {
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
                    Console.WriteLine("*Created #base in mainmenuoverride.res");
                }
                catch (FileLoadException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            else
            {
                Console.WriteLine("*Created #base in mainmenuoverride.res");
            }     
        }

        static void MoveFilesFromSprites()
        {
            string sourcePath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\sprites\obj_icons";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\temp";

            string fileName1 = "button";

            // Move files to targeted folder, if exists pass
            if (Directory.Exists(targetPath))
            {    
                Console.WriteLine("*Moved files from sprites/obj_icons to temp.");
            }
            else
            {
                Directory.Move(sourcePath, targetPath);
                Console.WriteLine("*Moved files from sprites/obj_icons.");
            }

            sourcePath = @"..\..\..\ToonHUD\materials\temp";
            targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\temp";

            string sourceFile = Path.Combine(sourcePath);
            string destFile = Path.Combine(targetPath);

            // To copy a folder's contents to a new location:
            // Create a new target folder.
            // If the directory already exists, this method does not create a new directory.
            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName1 = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName1);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        static void CreateControlPointIcons()
        {
            string fileName = "icon_obj";

            string sourcePath = @"..\..\..\ToonHUD\materials\sprites\obj_icons";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\sprites\obj_icons";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath);
            string destFile = Path.Combine(targetPath);

            Directory.CreateDirectory(targetPath);
            Console.WriteLine("*Created control point icons.");

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

        }

        static void CreateExtrasFolder()
        {
            string fileName = "preload";
            string sourcePath = @"..\..\..\ToonHUD\resource\extras\";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\extras\";

            string sourceFile = Path.Combine(sourcePath);
            string destFile = Path.Combine(targetPath);

            Directory.CreateDirectory(targetPath);
            Console.WriteLine("*Created Extras Folder");

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true); 
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }
    }
}
