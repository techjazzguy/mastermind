using Xunit;
using System.IO;

    public class UnitTests
    {
        [Fact]
        public void InputFileExists()
        { 
           Assert.True(File.Exists(Program.fileName));
        }
    }
 