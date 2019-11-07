using Xunit;
using System.IO;
using System.Xml;

    public class UnitTests
    {
        [Fact]
        public void InputFileExists()
        { 
           Assert.True(File.Exists(Program.wordSearchDocPath));
        }
        [Fact]
        public void InputFileIsNotEmpty()
        { 
           FileInfo fi = new FileInfo(Program.wordSearchDocPath);
           Assert.True(fi.Length > 0);
        }
         [Fact]
        public void CanLoadInputFile()
        {
          XmlDocument wordSearchDoc = new XmlDocument();
          Program.wordSearchDoc.Load(Program.wordSearchDocPath);
        }
        [Fact]
        public void InputFileContainsPreformattedText()
        { 
           Program.xmlNode = Program.wordSearchDoc.SelectSingleNode("pre").FirstChild;
           Assert.True(Program.xmlNode.InnerText != null);
        }
        
    }
 