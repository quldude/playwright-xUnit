using System.Globalization;

using Microsoft.Playwright;

using Xunit;
using Xunit.Abstractions;

namespace Sample.E2E.Tests.Test.Web.Samples;

public sealed class SuiteFixture : IAsyncLifetime
{
    public ITestOutputHelper? Output { get; set; }
    public IBrowser? Browser { get; private set; }
    private IPlaywright? _playwrightInstance;

    public async Task InitializeAsync()
    {
        _playwrightInstance = await Playwright.CreateAsync();

        Browser = await _playwrightInstance!.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true,
            Args = new List<string> { "--start-maximized " }
        });
    }

    public async Task DisposeAsync()
    {
        await Browser!.CloseAsync();
        _playwrightInstance?.Dispose();
    }

    private readonly CultureInfo _culture = new CultureInfo("en-US");

    public void Log(string message) => Output?.WriteLine(string.Format(_culture, "{0} [{1}] {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", _culture), "DEBUG", message));
}
