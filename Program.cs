using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ScriptJoiner
{
    class Program
    {
        private const String _scriptFileName = "ScriptJoiner.txt";

        static void Main(string[] args)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            String scriptFilePath = Path.Combine(currentDirectory.FullName, _scriptFileName);
            if (File.Exists(scriptFilePath))
            {
                File.Delete(scriptFilePath);
            }
            List<String> scriptLines = new List<String>();

            foreach (FileInfo script in currentDirectory.GetFiles("*.txt", SearchOption.TopDirectoryOnly).OrderBy(f => f.Name))
            {
                using (StreamReader scriptStreamReader = new StreamReader(script.OpenRead()))
                {
                    while (!scriptStreamReader.EndOfStream)
                    {
                        scriptLines.Add(scriptStreamReader.ReadLine());
                    }
                }
            }

            using (StreamWriter scripts = File.CreateText(scriptFilePath))
            {
                foreach (String scriptLine in scriptLines)
	            {
                    scripts.WriteLine(scriptLine);
	            }
            }
        }
    }
}
