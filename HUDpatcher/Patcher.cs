using System.Text;

namespace HUDpatcher
{
    internal class Patcher
    {
        public void CreateReferenceToPreload()
        {
            string filePath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\mainmenuoverride.res";
            var fileText = File.ReadAllLines(filePath).ToList();

            // Check if line already exists.
            if (!fileText.Any(line => line.Equals("#base \"../../resource/extras/preload.res\"")))
            {
                // Try catch possible exception of file can be used in other process.
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

        public void MoveFilesFromSprites()
        {
            string sourcePath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\sprites\obj_icons";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\temp";

            // Move files to targeted folder. Pass if already exists.
            if (Directory.Exists(targetPath))
            {
                Console.WriteLine("Moved files from sprites/obj_icons to temp.");
            }
            else
            {
                Directory.Move(sourcePath, targetPath);
                Console.WriteLine("Moved files from sprites/obj_icons to temp.");
            }
        }

        public void CopyFilesFromTemp()
        {
            string fileName1 = "button";
            string sourcePath = @"..\..\..\ToonHUD\materials\temp";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\temp";

            // Use Path class to manipulate file and directory paths.
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
                Console.WriteLine("Copied files from temp.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        public void CreateControlPointIcons()
        {
            string fileName = "icon_obj";
            string sourcePath = @"..\..\..\ToonHUD\materials\sprites\obj_icons";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\sprites\obj_icons";

            string sourceFile = Path.Combine(sourcePath);
            string destFile = Path.Combine(targetPath);

            Directory.CreateDirectory(targetPath);
            
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
                Console.WriteLine("Created control point icons.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

        }

        public void CreateExtrasFolder()
        {
            string fileName = "preload";
            string sourcePath = @"..\..\..\ToonHUD\resource\extras\";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\extras\";

            string sourceFile = Path.Combine(sourcePath);
            string destFile = Path.Combine(targetPath);

            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
                Console.WriteLine("Created extras folder.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        public void CopyReplayBrowser()
        {
            string fileName1 = "button";
            string sourcePath = @"..\..\..\ToonHUD\resource\ui\replaybrowser";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\replaybrowser";

            // Use Path class to manipulate file and directory paths.
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
                Console.WriteLine("Copied replay browser.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        public void EditMainMenuOverrideForContracker()
        {
            StringBuilder newFile = new StringBuilder();

            string temp = "";

            string[] file = File.ReadAllLines(@"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\mainmenuoverride.res");

            foreach (string line in file)
            {
                if (line.Contains("button_quests_pda"))
                {
                    temp = line.Replace("button_quests_pda", "../../materials/temp/button_quests_pda");

                    newFile.Append(temp + "\r\n");

                    continue;
                }
                newFile.Append(line + "\r\n");
            }

            File.WriteAllText(@"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\mainmenuoverride.res", newFile.ToString());

            Console.WriteLine("Fixed contracker icon bug.");
        }

        public void FixConsoleErrors()
        {
            string fileName = "huditemeffectmeter_action.res";
            string sourcePath = @"..\..\..\ToonHUD\resource\ui";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui";

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);

            File.Copy(sourceFile, destFile, true);

            Console.WriteLine("Fixed HudItemEffectMeter_Action console error.");

           fileName = "menu_thumb_Missing.vmt";
           sourcePath = @"..\..\..\ToonHUD\materials\vgui\maps";
           targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\materials\vgui\maps";

            sourceFile = Path.Combine(sourcePath);
            destFile = Path.Combine(targetPath);

            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
                Console.WriteLine("Fixed missing vgui material error.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        public void FixMatchHudFPSLoss()
        {
            StringBuilder newFile = new StringBuilder();

            var file = File.ReadAllLines(@"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\hudmatchstatus.res").ToList();

            foreach (string line in file)
            {
                if (line.Contains("\"wide\"\t\t\t\t\"32\"\r\n\t\t\t\t\"tall\"\t\t\t\t\"32\"\r\n\t\t\t\t\"visible\"\t\t\t\"0\"\r\n\t\t\t\t\"enabled\"\t\t\t\"1\""))
                {
                   string temp = line.Replace("\"wide\"\t\t\t\t\"32\"\r\n\t\t\t\t\"tall\"\t\t\t\t\"32\"\r\n\t\t\t\t\"visible\"\t\t\t\"0\"\r\n\t\t\t\t\"enabled\"\t\t\t\"1\"", "\"wide\"\t\t\t\t\"32\"\r\n\t\t\t\t\"tall\"\t\t\t\t\"32\"\r\n\t\t\t\t\"visible\"\t\t\t\"0\"\r\n\t\t\t\t\"enabled\"\t\t\t\"0\"");

                   newFile.Append(temp + "\r\n");

                   continue;
                }
                newFile.Append(line + "\r\n");
            }

            File.WriteAllText(@"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\hudmatchstatus.res", newFile.ToString());

            Console.WriteLine("Fixed matchstatus fps loss.");
        }
    }
}
