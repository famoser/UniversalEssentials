using System;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.UniversalWindows.Platform;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Famoser.FrameworkEssentials.UniversalWindows.UnitTests
{
    [TestClass]
    public class TestStorageService
    {
        [TestMethod]
        public async Task TestSavingAndRetrieving()
        {
            var testString = "test";
            var ss = new StorageService();

            await ss.SetCachedTextFileAsync("file1", testString);
            Assert.IsTrue(await ss.GetCachedTextFileAsync("file1") == testString);

            await ss.SetUserTextFileAsync("file2", testString);
            Assert.IsTrue(await ss.GetUserTextFileAsync("file2") == testString);
        }
    }
}
