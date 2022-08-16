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
                Patcher.CopyFilesFromTemp();
                Patcher.MoveFilesFromSprites();
                Patcher.CopyMiscFiles();
                Patcher.CopyHudFolder();
                Patcher.EditMainMenuOverrideForContracker();
                Patcher.CopyFilesFromHudFolder();
                Patcher.CreateReferenceToPreload();
                Patcher.CreateControlPointIcons();
                Patcher.CopyReplayBrowser();
                Patcher.CreateExtrasFolder();
                Patcher.FixHudItemEffectMeterConsoleError();
                Patcher.FixMissingVguiMaterialError();
                Patcher.FixMatchHudFPSLoss();
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }

            // Keep console window open 
            Console.WriteLine("\nTask completed. It's safe to close console window now.");
            Console.ReadKey();
        }
    }
}
