using Microsoft.Playwright;

namespace Sample.E2E.Tests.Test.Web.Samples;

public abstract class SuiteBase
{
    protected IBrowserContext CreateBrowserContextAsync(IBrowser browser)
    {
        return browser.NewContextAsync(
           new BrowserNewContextOptions()
           {
               UserAgent = "XYZ"
           }).Result;
    }
}
