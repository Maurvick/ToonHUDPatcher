using System.Text;

namespace HUDpatcher
{
    internal class Program
    {
        static void Main()
        {
            if (!Directory.Exists("toonhud"))
            {
                Console.WriteLine("Folder 'toonhud' not found.");
                return;
            }

            CopyFilesFromTemp();
            MoveFilesFromSprites();
            CopyMiscFiles();
            CopyHudFolder();
            EditMainMenuOverrideForContracker();
            CopyFilesFromHudFolder();
            CreateReferenceToPreload();
            CreateControlPointIcons();
            CopyReplayBrowser();
            CreateExtrasFolder();
            FixHudItemEffectMeterConsoleError();
            FixMissingVguiMaterialError();
            FixMatchHudFPSLoss();

            Console.WriteLine("\nTask completed." +
                " It's safe to close console window now.");
            Console.ReadKey();
        }

        static void CopyFilesFromTemp()
        {
            string sourcePath = @"Resources\toonhud\materials\temp";
            string targetPath = @"toonhud\materials\temp";

            // If the directory already exists, this method does not create a new directory.
            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = Path.GetFileName(s);
                    string destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }

                Console.WriteLine("Copied files from temp.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        static void CopyMiscFiles()
        {
            string sourcePath = @"Resources\toonhud\materials\misc";
            string targetPath = @"toonhud\materials\temp";

            // If the directory already exists, this method does not create a new directory.
            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = Path.GetFileName(s);
                    string destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
                Console.WriteLine("Copied misc folder.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        static void CopyHudFolder()
        {
            string sourcePath = @"Resources\toonhud\materials\hud";
            string targetPath = @"toonhud\materials\hud";

            // If the directory already exists, this method does not create a new directory.
            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = Path.GetFileName(s);
                    string destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }

                Console.WriteLine("Copied hud folder.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        static void MoveFilesFromSprites()
        {
            string sourcePath = @"toonhud\materials\sprites\obj_icons";
            string targetPath = @"toonhud\materials\temp";

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

        static void EditMainMenuOverrideForContracker()
        {
            StringBuilder newFile = new();

            string[] file = File.ReadAllLines(@"toonhud\resource\ui\mainmenuoverride.res");

            foreach (string line in file)
            {
                if (line.Contains("../../materials/temp/button_quests_pda"))
                {
                    newFile.Append(line + "\r\n");
                }
                else
                {
                    if (line.Contains("button_quests_pda"))
                    {
                        string temp = line.Replace("button_quests_pda", "../../materials/temp/button_quests_pda");

                        newFile.Append(temp + "\r\n");

                        continue;
                    }
                    newFile.Append(line + "\r\n");
                }
            }

            File.WriteAllText(@"toonhud\resource\ui\mainmenuoverride.res", newFile.ToString());

            Console.WriteLine("Fixed contracker icon bug.");
        }

        static void CopyFilesFromHudFolder()
        {
            string sourcePath = @"toonhud\materials\hud";
            string targetPath = @"toonhud\materials\temp";

            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    string fileName = Path.GetFileName(s);
                    string destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
                Console.WriteLine("Copied from hud folder.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        static void CreateReferenceToPreload()
        {
            string sourcePath = @"toonhud\resource\ui\mainmenuoverride.res";
            var file = File.ReadAllLines(sourcePath).ToList();

            // Check if a line exists.
            if (!file.Any(line => line.Equals("#base \"../../resource/extras/preload.res\"")))
            {
                file.Insert(0, "#base \"../../resource/extras/preload.res\"");

                File.WriteAllLines(sourcePath, file);
                Console.WriteLine("Created #base in mainmenuoverride.res");
            }
            // If exists, pass.
            else
            {
                Console.WriteLine("Created #base in mainmenuoverride.res");
            }
        }

        static void CreateControlPointIcons()
        {
            string sourcePath = @"Resources\ToonHUD\materials\sprites\obj_icons";
            string targetPath = @"toonhud\materials\sprites\obj_icons";

            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    string fileName = Path.GetFileName(s);
                    string destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }

                Console.WriteLine("Created control point icons.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        static void CopyReplayBrowser()
        {
            string sourcePath = @"Resources\ToonHUD\resource\ui\replaybrowser";
            string targetPath = @"toonhud\resource\ui\replaybrowser";

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
                    string fileName1 = Path.GetFileName(s);
                    string destFile = Path.Combine(targetPath, fileName1);
                    File.Copy(s, destFile, true);
                }
                Console.WriteLine("Copied replay browser.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        static void CreateExtrasFolder()
        {
            string sourcePath = @"Resources\ToonHUD\resource\extras\";
            string targetPath = @"toonhud\resource\extras\";

            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    string fileName = Path.GetFileName(s);
                    string destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
                Console.WriteLine("Created extras folder.");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        static void FixHudItemEffectMeterConsoleError()
        {
            string fileName = "huditemeffectmeter_action.res";
            string sourcePath = @"Resources\ToonHUD\resource\ui";
            string targetPath = @"toonhud\resource\ui";

            try
            {
                string sourceFile = Path.Combine(sourcePath, fileName);
                string destFile = Path.Combine(targetPath, fileName);

                File.Copy(sourceFile, destFile, true);

                Console.WriteLine("Fixed HudItemEffectMeter_Action console error.");
            }
            catch (Exception)
            {
                Console.WriteLine("Source path does not exist!");
            } 
        }

        static void FixMissingVguiMaterialError()
        {
            // 1
            string sourcePath = @"Resources\ToonHUD\materials\vgui\maps";
            string targetPath = @"toonhud\materials\vgui\maps";

            Directory.CreateDirectory(targetPath);

            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    string fileName = Path.GetFileName(s);
                    string destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        static void FixMatchHudFPSLoss()
        {
            StringBuilder newFile = new();

            var currentFile = File.ReadAllLines(@"toonhud\resource\ui\hudmatchstatus.res").ToList();

            // check lines in file
            foreach (string lines in currentFile)
            {
                // find specified line in file and replace 
                if (lines.Contains("\"enabled\"\t\t\t\"1\""))
                {
                    string temp = lines.Replace("\"enabled\"\t\t\t\"1\"", "\"enabled\"\t\t\t\"0\"");

                    newFile.Append(temp + "\r\n");

                    continue;
                }
                else
                {
                    newFile.Append(lines + "\r\n");
                }
            }

            File.WriteAllText(@"toonhud\resource\ui\hudmatchstatus.res", newFile.ToString());
            Console.WriteLine("Fixed matchstatus fps loss.");
        }
    }
}
