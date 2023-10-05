using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace AddProducts;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task AddProductsTest()
    {
        await Page.GotoAsync("https://commitquality.com/");
        var buttonAddProduct = Page.GetByTestId("add-a-product-button");
        await buttonAddProduct.ClickAsync();

        var titleText = Page.Locator(".container>div>h1");
        await Expect(titleText).ToHaveTextAsync("Add Product");
    }
}