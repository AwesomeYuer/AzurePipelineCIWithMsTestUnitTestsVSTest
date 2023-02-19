namespace ConsoleApp1.Tests
{
    using PlaywrightEntry = Microsoft.Playwright.Program;
    using Microsoft.Playwright;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass(), TestCategory(nameof(PlaywrightTests))]
    public class PlaywrightTests
    {

        [TestInitialize()]
        public void TestInitializeProcess()
        {
            Console.WriteLine($"nameof{TestInitializeProcess}");

            Console.WriteLine("Start download chromium");
            var exitCode = PlaywrightEntry.Main(new[] { "install", "chromium" });
            if (exitCode != 0)
            {
                throw new Exception($"Playwright exited with code {exitCode}");
            }
        }
        [TestMethod()]
        public async Task Baidu_Test()
        {
            var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.baidu.com");
            var title = await page.InnerTextAsync("title");
            Console.WriteLine(title);
            Assert.IsTrue(title.Contains("百度"));
        }
    }
}
