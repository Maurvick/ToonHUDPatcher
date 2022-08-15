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
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("Task completed. It's safe to close console window now.");
            Console.ReadKey();
        }
    }
}
