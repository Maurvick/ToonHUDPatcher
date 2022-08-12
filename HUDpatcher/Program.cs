using System.Text;

namespace HUDpatcher
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "HUDpatcher";

            FixControlPointIcon();
            //FixFPSLoss();
            //FixConsoleError();
        }

        static void FixControlPointIcon()
        {
            var filePath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\mainmenuoverride.res";
            var fileText = File.ReadAllLines(@"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\mainmenuoverride.res").ToList();

            try
            {
                fileText.Insert(0, "#base \"../../resource/extras/preload.res\"");
                File.WriteAllLines(filePath, fileText);
            }
            catch (Exception)
            {
                Console.WriteLine("Can't edit targeted file. Try to close all applications and run script again.");
            }

            Console.WriteLine("Fixed control points not working on sv_pure 1 servers.");
        }

        static void FixFPSLoss()
        {
            StringBuilder newFile = new StringBuilder();

            string[] file = File.ReadAllLines(@"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\hudmatchstatus.res");

            foreach (string line in file)
            {
                if (line.Contains("\"HealthIcon\"\r\n\t\t\t{\r\n\t\t\t\t\"ControlName\"\t\t\"EditablePanel\"\r\n\t\t\t\t\"fieldName\"\t\t\t\"HealthIcon\"\r\n\t\t\t\t\"xpos\"\t\t\t\t\"22\"\r\n\t\t\t\t\"ypos\"\t\t\t\t\"-3\"\r\n\t\t\t\t\"zpos\"\t\t\t\t\"3\"\r\n\t\t\t\t\"wide\"\t\t\t\t\"32\"\r\n\t\t\t\t\"tall\"\t\t\t\t\"32\"\r\n\t\t\t\t\"visible\"\t\t\t\"0\"\r\n\t\t\t\t\"enabled\"\t\t\t\"1\"\t\r\n\t\t\t\t\"HealthBonusPosAdj\"\t\"10\"\r\n\t\t\t\t\"HealthDeathWarning\"\t\t\"0.49\"\r\n\t\t\t\t\"TFFont\"\t\t\t\t\t\"HudFontSmallest\"\r\n\t\t\t\t\"HealthDeathWarningColor\"\t\"HUDDeathWarning\"\r\n\t\t\t\t\"TextColor\"\t\t\t\t\t\"HudOffWhite\"\r\n\t\t\t}"))
                {
                    string temp = line.Replace("\"enabled\"\t\t\t\t\"1\"", "lol");

                    newFile.Append(temp + "\r\n");

                    continue;
                }
                newFile.Append(line + "\r\n");
            }

            File.WriteAllText(@"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\hudmatchstatus.res", newFile.ToString());

            Console.WriteLine("Fixed matchstatus fps loss.");
        }

        static void FixConsoleError()
        {
            string fileName = "huditemeffectmeter_action.res";
            string sourcePath = @"C:\Users\Andrew\source\repos\HUDpatcher\HUDpatcher\ToonHUD\resource\ui\";
            string targetPath = @"D:\SteamLibrary\steamapps\common\Team Fortress 2\tf\custom\toonhud\resource\ui\";

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);

            File.Copy(sourceFile, destFile, true);

            Console.WriteLine("Fixed HudItemEffectMeter_Action console error.");
        }
    }
}
