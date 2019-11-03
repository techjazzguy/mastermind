using System;
using System.IO;
    class Program
    {
        public static string fileName="wordsearch.xml";
        static void Main(string[] args)
        {
            Program.OpenFile();
        }

        public static void OpenFile()
        {
            File.ReadAllText(Program.fileName);
        }
    }
