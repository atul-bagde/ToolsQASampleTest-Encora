using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ToolsQASampleTest_Encora.Configurations
{
    public class FolderPaths
    {
        private const string DriverPath = "\\Drivers";

        public static string GetDriverPath()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug", string.Empty) + DriverPath;
            return path;
        }
    }
}
