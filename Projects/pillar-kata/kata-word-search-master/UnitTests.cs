using Xunit;
using System.IO;
using System.Xml;
using WordSearchNamespace;

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
        wordSearch.xmlNode = wordSearch.wordSearchDoc.SelectSingleNode("pre").FirstChild;
        Assert.True(wordSearch.xmlNode.InnerText != null);
    }

}
