namespace HUDpatcher
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "HUDpatcher";
            Patcher patcher = new Patcher();
            
            // Catch exception if unable to find path to folder
            try
            {
                patcher.MoveFilesFromSprites();
                patcher.CreateReferenceToPreload();
                patcher.CreateControlPointIcons();
                patcher.CopyFilesFromTemp();
                patcher.CreateExtrasFolder();
                patcher.CopyReplayBrowser();
                patcher.EditMainMenuOverrideForContracker();
                patcher.FixConsoleErrors();
                patcher.FixMatchHudFPSLoss();
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Task failed successfully.");
            }

            // Keep console window open
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
