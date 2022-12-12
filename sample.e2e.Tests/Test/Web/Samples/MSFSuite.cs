using Microsoft.Playwright;

using Xunit;
using Xunit.Abstractions;

namespace Sample.E2E.Tests.Test.Web.Samples;

public sealed class MSFSuite : SuiteBase, IClassFixture<SuiteFixture>, IDisposable
{
    private readonly SuiteFixture _fixture;
    private readonly IBrowserContext _context;

    // Test SetUp
    public MSFSuite(ITestOutputHelper output, SuiteFixture fixture)
    {
        _fixture = fixture;
        _fixture.Output = output;

        _context = CreateBrowserContextAsync(_fixture.Browser!);
    }

    public void Dispose() => _context!.CloseAsync().Wait();

    [Fact]
    public async Task MSFPageTestAsync()
    {
        _fixture.Log($"Go to Google.");

        var playwrightPage = await _context.NewPageAsync();
        await playwrightPage.GotoAsync("https://google.com/");
        var element = await playwrightPage.WaitForSelectorAsync("input[title='Google Search']");

        Assert.True(await element!.IsVisibleAsync());
    }
}
