using AnonLeaks.Models;
using System.Text.Json;

namespace AnonLeaks
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    public class MyProgram
    {
        public static ConfigModel StartConfig()
        {
            try
            {
                var contentConfig = File.ReadAllText("config.json");
                var configFile = JsonSerializer.Deserialize<ConfigModel>(contentConfig);

                return configFile;
            }
            catch
            {
                return null;
            }
        }
    }
}
