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
            var testBytes = new byte[] { 2, 1, 3 };
            var ss = new StorageService();

            await ss.SetCachedTextFileAsync("file1", testString);
            Assert.IsTrue(await ss.GetCachedTextFileAsync("file1") == testString);

            await ss.SetCachedFileAsync("file2", testBytes);
            AssertArrayEquality(await ss.GetCachedFileAsync("file2"), testBytes);

            await ss.SetRoamingTextFileAsync("file3", testString);
            Assert.IsTrue(await ss.GetRoamingTextFileAsync("file3") == testString);

            await ss.SetRoamingFileAsync("file4", testBytes);
            AssertArrayEquality(await ss.GetRoamingFileAsync("file4"), testBytes);

            Assert.IsTrue(string.IsNullOrEmpty(await ss.GetRoamingTextFileAsync("file1")));
            Assert.IsTrue((await ss.GetRoamingFileAsync("file2")).Length == 0);

            Assert.IsTrue(string.IsNullOrEmpty(await ss.GetCachedTextFileAsync("file3")));
            Assert.IsTrue((await ss.GetCachedFileAsync("file4")).Length == 0);
        }

        private void AssertArrayEquality(byte[] one, byte[] two)
        {
            Assert.IsTrue(one.Length == two.Length);
            for (int i = 0; i < one.Length; i++)
            {
                Assert.IsTrue(one[i] == two[i]);
            }
        }
    }
}
