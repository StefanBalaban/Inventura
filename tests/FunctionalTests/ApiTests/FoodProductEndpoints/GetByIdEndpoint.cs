using FunctionalTests;
using Inventura.PublicApi.Util.FoodProductEndpoints;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Inventura.ApplicationCore.Extensions;

namespace FunctionalTests.ApiTests.FoodProductEndpoints
{
    [Collection("Sequential")]
    public class GetByIdEndpoint : IClassFixture<ApiTestFixture>
    {
        JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public GetByIdEndpoint(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsItemGivenValidId()
        {
            var response = await Client.GetAsync("api/food-product/5");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<GetByIdFoodProductResponse>();

            Assert.Equal(5, model.FoodProduct.Id);
            Assert.Equal(0, model.FoodProduct.Protein);
        }

        [Fact]
        public async Task ReturnsNotFoundGivenInvalidId()
        {
            var response = await Client.GetAsync("api/catalog-items/0");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
