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
        
        wordSearch.ReadFileOutput(wordSearch.xmlNode);

    }
}
