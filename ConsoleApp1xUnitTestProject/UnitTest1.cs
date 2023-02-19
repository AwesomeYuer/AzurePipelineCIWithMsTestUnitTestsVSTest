namespace ConsoleApp1xUnitTests
{
    using PlaywrightEntry = Microsoft.Playwright.Program;
    using Microsoft.Playwright;
    public class xUnitTests
    {
        
        public xUnitTests()
        {
            Console.WriteLine("Start download chromium");
            var exitCode = PlaywrightEntry.Main(new[] { "install", "chromium" });
            if (exitCode != 0)
            {
                throw new Exception($"Playwright exited with code {exitCode}");
            }
        }

        [InlineData(true, "msedge")]
        [InlineData(true, "chrome")]
        [Theory]
        public async Task Baidu_Test(bool browserHeadless, string browserChannel)
        {
            var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = browserHeadless, Channel = browserChannel });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.baidu.com");
            var title = await page.InnerTextAsync("title");
            await browser.CloseAsync();
            Console.WriteLine(title);
            //Assert.Contains("�ٶ�", title);
        }

        [InlineData(false, "msedge")]
        [InlineData(false, "chrome")]
        [Theory]
        public async Task BaiduSearch_Test(bool browserHeadless, string browserChannel)
        {
            var playwright = await Playwright.CreateAsync();
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
            var s = page.InnerHTMLAsync("body").Result;
            await browser.CloseAsync();
            //Assert.Contains("�ٶ�Ϊ���ҵ���ؽ��", s!);
        }
    }
}