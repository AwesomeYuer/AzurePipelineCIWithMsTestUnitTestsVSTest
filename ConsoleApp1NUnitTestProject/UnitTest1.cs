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

        [Test]
        public async Task VerifyDotNetLinkClickRedirectingToDotNetIntroPage()
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet/");
            await page.ClickAsync("section >> text=.NET");
            Assert.AreNotEqual("https://playwright.dev/dotnet/docs/intro/", page.Url);
        }


        [Test]
        public async Task BaiduSearch_Test()
        {
            

            await Page.GotoAsync("https://www.baidu.com");

            await Page.Locator("id=kw").FillAsync(Guid.NewGuid().ToString());

            await Page.Locator("id=su").ClickAsync();

            await Task.Delay(2000);

            await Page.Locator("//*[@id=\"u\"]/a[2]").HoverAsync();

            await Page.Locator("//*[@id=\"u\"]/div/a[1]/span").ClickAsync();
            await Page.Locator("id=sh_1").CheckAsync();

            var locator = Page.Locator("title");
            await Expect(locator).ToHaveTextAsync("百度");

            locator = Page.Locator("body");
            await Expect(locator).ToHaveTextAsync("百度为您找到相关结果");

        }
    }
}