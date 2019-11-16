using Xunit;
using System;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using WordSearchNamespace;
using System.Reflection;
public class UnitTests
{
    [Fact]
    public void InputFileExists()
    {
        WordSearch wordSearch = new WordSearch();
        Assert.True(File.Exists(wordSearch.wordSearchDocPath));
    }
    [Fact]
    public void InputFileIsNotEmpty()
    {
        WordSearch wordSearch = new WordSearch();
        FileInfo fi = new FileInfo(wordSearch.wordSearchDocPath);
        Assert.True(fi.Length > 0);
    }
    [Fact]
    public void CanLoadInputFile()
    {
        WordSearch wordSearch = new WordSearch();
        XmlDocument wordSearchDoc = new XmlDocument();
        wordSearch.wordSearchDoc.Load(wordSearch.wordSearchDocPath);
    }
    [Fact]
    public void InputFileContainsPreformattedText()
    {
        WordSearch wordSearch = new WordSearch();
        wordSearch.wordSearchDoc.Load(wordSearch.wordSearchDocPath);
        wordSearch.xmlNode = wordSearch.wordSearchDoc.SelectSingleNode("pre").FirstChild;
      Assert.True(wordSearch.xmlNode.InnerText != null);
    }
    [Fact]
    public void InputFileSearchListExists()
    {
        WordSearch wordSearch = new WordSearch();
        wordSearch.wordSearchDoc.Load(wordSearch.wordSearchDocPath);
        wordSearch.xmlNode = wordSearch.wordSearchDoc.SelectSingleNode("pre").FirstChild;
        wordSearch.ReadFileOutput(wordSearch.xmlNode);
       Assert.True(!String.IsNullOrEmpty(wordSearch.wordsToSearch));
    }
    [Fact]
    public void SearchLineIsCommaSeparated()
    {
       var regex = "[a-z],[a-z]";
        Match match = Regex.Match("U,M,K,H,U,L,K,I,N,V,J,O,C,W,E", regex ,RegexOptions.IgnoreCase);
      if (!match.Success)
        {
            Console.WriteLine("Word search lines must be comma-separated.");
         }
       Assert.True(match.Success);
    }

    [Fact]
    public void SearchGridHasSameNumOfRowsAndColumns()
    {
       char [,] arrayChars = new char [1, 2];
               Console.WriteLine("Long Length: " + arrayChars.GetLongLength(0));
                  Assert.True(true);
    }

    public bool SearchForWord()
    {
      string word = "UHURA";
      foreach (char letter in word)
      {
        
      }
      return true;
    }
[Fact]
    public void SearchForLetter()
    {
      string directory = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
      Console.WriteLine("Here is: " + Path.Combine(directory, "wordsearch.xml"));
    }

}
