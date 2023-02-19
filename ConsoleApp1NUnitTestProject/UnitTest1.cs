namespace ConsoleApp1NUnitTests
{
    using PlaywrightEntry = Microsoft.Playwright.Program;
    using Microsoft.Playwright;
    using Microsoft.Playwright.NUnit;
    public class PlaywrightNUnitTests : PageTest
    {
        //[SetUp]
        //public void Setup()
        //{

        //    Console.WriteLine("Start download chromium");
        //    var exitCode = PlaywrightEntry.Main(new[] { "install", "chromium" });
        //    if (exitCode != 0)
        //    {
        //        throw new Exception($"Playwright exited with code {exitCode}");
        //    }
        //}

        [Test]
        public async Task ShouldHaveTheCorrectSlogan()
        {
            await Page.GotoAsync("https://playwright.dev");
            await Expect(Page.Locator("text=enables reliable end-to-end testing for modern web apps")).ToBeVisibleAsync();
        }

        [Test]
        public async Task ShouldHaveTheCorrectTitle()
        {
            await Page.GotoAsync("https://playwright.dev");
            var title = Page.Locator(".navbar__inner .navbar__title");
            await Expect(title).ToHaveTextAsync("Playwright");
        }





        [TestCase(true, "msedge")]
        [TestCase(true, "chrome")]
        [Test]
        public async Task Baidu_Test(bool browserHeadless, string browserChannel)
        {
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true, Channel = browserChannel });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.baidu.com");
            
            var title = await page.InnerTextAsync("title");
            await browser.CloseAsync();
            Console.WriteLine($"{nameof(PlaywrightNUnitTests)} Title: <<{title}>>");
            Assert.IsTrue(title.Contains("�ٶ�", StringComparison.OrdinalIgnoreCase));
        }

        [TestCase(false, "msedge")]
        [TestCase(false, "chrome")]
        [Test]
        public async Task BaiduSearch_Test(bool browserHeadless, string browserChannel)
        {
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            //await using var browser = await playwright.Chromium.LaunchAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = browserHeadless, Channel = browserChannel });

            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://www.baidu.com");

            await page.Locator("id=kw").FillAsync(Guid.NewGuid().ToString());

            await page.Locator("id=su").ClickAsync();

            await Task.Delay(2000);

            await page.Locator("//*[@id=\"u\"]/a[2]").HoverAsync();

            await page.Locator("//*[@id=\"u\"]/div/a[1]/span").ClickAsync();
            await page.Locator("id=sh_1").CheckAsync();
            var title = await page.InnerTextAsync("title");
            var s = page.InnerTextAsync("body").Result;
            await browser.CloseAsync();
            Console.WriteLine($"{nameof(PlaywrightNUnitTests)} Title: <<{title}>>");
            Assert.IsTrue(s!.Contains("�ٶ�Ϊ���ҵ���ؽ��"));
        }
    }
}