using System;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Reflection;

namespace WordSearchNamespace
{
    public class WordSearch
    {
        public string wordSearchDocPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "wordsearch.xml");

        public XmlDocument wordSearchDoc = new XmlDocument();
        public XmlNode xmlNode;
        public string wordsToSearch = String.Empty;

        public char [] searchGrid;

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
                                Match match = Regex.Match(line, regex, RegexOptions.IgnoreCase);
                                if (!match.Success)
                                {
                                    Console.WriteLine("Word search lines must be comma-separated.");
                                }
                            }
                        }
                        Console.WriteLine(line);
                    }

                }


            }
            this.searchGrid = xmlNode.InnerText.ToCharArray();
            return this.wordsToSearch;
        }


    }
}
