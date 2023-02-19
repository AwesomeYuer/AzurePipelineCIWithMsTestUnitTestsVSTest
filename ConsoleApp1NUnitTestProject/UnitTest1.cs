namespace ConsoleApp1NUnitTests
{
    using PlaywrightEntry = Microsoft.Playwright.Program;
    using Microsoft.Playwright;
    public class PlaywrightNUnitTests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Start download chromium");
            var exitCode = PlaywrightEntry.Main(new[] { "install", "chromium" });
            if (exitCode != 0)
            {
                throw new Exception($"Playwright exited with code {exitCode}");
            }
        }

        [TestCase(true, "msedge")]
        [TestCase(true, "chrome")]
        [Test]
        public async Task Bing_Test(bool browserHeadless, string browserChannel)
        {
            var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true, Channel = browserChannel });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("www.bing.com");
            var title = await page.InnerTextAsync("title");
            await browser.CloseAsync();
            Console.WriteLine($"{nameof(PlaywrightNUnitTests)} Title:《{title}》");
            Assert.IsTrue(title.Contains("bing", StringComparison.OrdinalIgnoreCase));
        }

        [TestCase(false, "msedge")]
        [TestCase(false, "chrome")]
        //[Test]
        public async Task BaiduSearch_Test(bool browserHeadless, string browserChannel)
        {
            var playwright = await Playwright.CreateAsync();
            //await using var browser = await playwright.Chromium.LaunchAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = browserHeadless, Channel = browserChannel, ChromiumSandbox = true });

            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://www.baidu.com");

            await page.Locator("id=kw").FillAsync(Guid.NewGuid().ToString());

            await page.Locator("id=su").ClickAsync();

            await Task.Delay(2000);

            await page.Locator("//*[@id=\"u\"]/a[2]").HoverAsync();

            await page.Locator("//*[@id=\"u\"]/div/a[1]/span").ClickAsync();
            await page.Locator("id=sh_1").CheckAsync();
            var title = await page.InnerTextAsync("title");
            var s = page.InnerHTMLAsync("body").Result;
            await browser.CloseAsync();
            Console.WriteLine($"{nameof(PlaywrightNUnitTests)} Title:《{title}》");
            //Assert.IsTrue(s!.Contains("百度为您找到相关结果"));
        }
    }
}