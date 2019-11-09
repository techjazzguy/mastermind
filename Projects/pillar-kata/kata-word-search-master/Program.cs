using System;
using System.IO;
using System.Xml;
using WordSearchNamespace;

class Program
{

    static void Main(string[] args)
    {
        WordSearch wordSearch = new WordSearch();

        //Check if file exists.
        if (!File.Exists(wordSearch.wordSearchDocPath))
        {
            Console.WriteLine("Input file must exist.");
            return;
        }

        try
        {
            wordSearch.wordSearchDoc.Load(wordSearch.wordSearchDocPath);
        }
        catch
        {
            Console.WriteLine("An error occurred while loading the word search file.");
            return;
        }

        if (wordSearch.wordSearchDoc.InnerText.Length == 0)
        {
            Console.WriteLine("Input file is empty.");
            return;
        }
        wordSearch.xmlNode = wordSearch.wordSearchDoc.SelectSingleNode("pre").FirstChild;

        if (wordSearch.xmlNode != null)
        {
            using (StringReader reader = new StringReader(wordSearch.xmlNode.InnerText))
            {
                string wordsToSearch = String.Empty;
                bool isFirstLine = true;
                string line = String.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        if (isFirstLine)
                        {
                            wordsToSearch = line;
                            isFirstLine = false;
                        }
                        else
                        {

                        }
                        Console.WriteLine(line);
                    }
                }
            }


        }

    }
}
