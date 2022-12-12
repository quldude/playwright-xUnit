using Xunit;

namespace Sample.E2E.Tests.Test.Web.Samples;

[CollectionDefinition(nameof(SuiteFixture))]
public class SharedPlaywrightCollectionFixture : ICollectionFixture<SuiteFixture>
{
}
