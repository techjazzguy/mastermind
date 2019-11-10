using System;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace WordSearchNamespace
{
    public class WordSearch 
    {
        public string wordSearchDocPath = 
           "/Users/eric/Documents/git/Projects/pillar-kata/kata-word-search-master/bin/Debug/netcoreapp3.0/wordsearch.xml";
           public XmlDocument wordSearchDoc = new XmlDocument();
           public XmlNode xmlNode;
           public string wordsToSearch = String.Empty;
        
        public string ReadFileOutput(XmlNode searchNode)
        {
             if (this.xmlNode != null)
        {
            
            using (StringReader reader = new StringReader(xmlNode.InnerText))
            {
                bool isFirstLine = true;
                string line = String.Empty;
                var regex = "[a-z],[a-z]";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        if (isFirstLine)
                        {
                            this.wordsToSearch = line;
                            isFirstLine = false;
                        }
                        else
                        {
                            Match match = Regex.Match(line, regex ,RegexOptions.IgnoreCase);
                            if (!match.Success)
                            {
                               Console.WriteLine("Word search lines must be comma-separated.");
                            }
                        }
                        Console.WriteLine(line);
                    }
                }
            }


        }
            return this.wordsToSearch;
        }

    }
}
