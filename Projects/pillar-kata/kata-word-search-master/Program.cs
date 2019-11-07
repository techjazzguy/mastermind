using System;
using System.IO;
using System.Xml;

    class Program
    {
          public static XmlDocument wordSearchDoc = new XmlDocument();
          public static XmlNode xmlNode;
          public static string wordSearchDocPath = "/Users/eric/Documents/git/Projects/pillar-kata/kata-word-search-master/bin/Debug/netcoreapp3.0/wordsearch.xml";
        static void Main(string[] args)
        {
            
            //Check if file exists.
            if (!File.Exists(Program.wordSearchDocPath))
            {
                Console.WriteLine("Input file must exist.");
                return;
            }

            try
            {
                Program.wordSearchDoc.Load(Program.wordSearchDocPath);
            }
            catch
            {
                Console.WriteLine("An error occurred while loading the word search file.");
                return;
            }

            if (Program.wordSearchDoc.InnerText.Length == 0)
            {
                Console.WriteLine("Input file is empty.");
                return;
            }
            Program.xmlNode = wordSearchDoc.SelectSingleNode("pre").FirstChild;

                using (StringReader reader = new StringReader(Program.xmlNode.InnerText))
                {
                    string line;
                    while (( line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine("Test " + line);
                    }
                }
}
    }
