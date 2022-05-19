using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Threading.Tasks;

namespace TestZippopotamus
{
    public class Zippo
    {
        [TestCase("BG", "1000", "Sofija")]
        [TestCase("BG", "8600", "Jambol")]
        [TestCase("CA", "M5S" , "Toronto")]
        [TestCase("GB", "B1", "Birmingham")]
        [TestCase("DE", "01067", "Dresden")]

        [Test]
        public async Task ZippoTest(string countryCode, string zipCode, string expectedPlace)
        {
            //Arrange
            var client = new RestClient("https://api.zippopotam.us/");
            var request = new RestRequest(countryCode + "/" + zipCode);

            //Act
            var response = await client.ExecuteAsync(request, Method.Get);
            var location = new SystemTextJsonSerializer().Deserialize<Locatoin>(response);

            //Assert
            StringAssert.Contains(expectedPlace, location.places[0].PlaceName);

        }
    }
}