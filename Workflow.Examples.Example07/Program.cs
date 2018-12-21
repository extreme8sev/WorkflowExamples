#region Usings

using System.IO;
using Microsoft.AspNetCore.Hosting;

#endregion

namespace Workflow.Examples.Example07
{
    public class Program
    {
        #region  Public Methods

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                      .UseKestrel()
                      .UseContentRoot(Directory.GetCurrentDirectory())
                      .UseIISIntegration()
                      .UseStartup<Startup>()
                      .Build();

            host.Run();
        }

        #endregion
    }
}