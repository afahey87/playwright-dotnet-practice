using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Commitquality;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task HomepageVerifyProducts()
    {
        // Verify the product on the first row
        await Page.GotoAsync("https://commitquality.com/");

        await Expect(Page).ToHaveTitleAsync(new Regex("CommitQuality"));

        var firstRowId = Page.GetByTestId("id").First;
        await Expect(firstRowId).ToHaveTextAsync("11");

        var firstRowName = Page.GetByTestId("name").First;
        await Expect(firstRowName).ToHaveTextAsync("Product 2");

        var firstRowPrice = Page.GetByTestId("price").First;
        await Expect(firstRowPrice).ToHaveTextAsync("15");

        var firstRowDateStocked = Page.GetByTestId("dateStocked").First;
        await Expect(firstRowDateStocked).ToHaveTextAsync("2021-02-01");
    }
}