using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DivVisualizer.Tests")]
namespace DivVizParqet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}