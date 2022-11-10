using Bookings.Controllers;
using Bookings.Models;
using Bookings.Models.FlightModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bookings.Classes
{
    public class TravelAPI
    {
        private string apiKey;
        private string apiSecret;
        private string bearerToken;
        private HttpClient http;

        public TravelAPI(IConfiguration config, IHttpClientFactory httpFactory)
        {
            apiKey = config.GetValue<string>("AmadeusAPI:APIKey");
            apiSecret = config.GetValue<string>("AmadeusAPI:APISecret");
            http = httpFactory.CreateClient("TravelAPI");
        }

        public async Task ConnectOAuth()
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "/v1/security/oauth2/token");
            message.Content = new StringContent(
                $"grant_type=client_credentials&client_id={apiKey}&client_secret={apiSecret}",
                Encoding.UTF8, "application/x-www-form-urlencoded"
            );

            var results = await http.SendAsync(message);
            await using var stream = await results.Content.ReadAsStreamAsync();
            var oauthResults = await JsonSerializer.DeserializeAsync<OAuthResults>(stream);

            bearerToken = oauthResults.access_token;
        }

        private class OAuthResults
        {
            public string access_token { get; set; }
        }

        public async Task<FlightPackages> SearchFlights(FlightInformation flightInformation)
        {
            FlightInformation flightInformation1 = flightInformation;

            string ste = "v2/shopping/flight-offers?originLocationCode=" + flightInformation.OriginLocationCode + "&destinationLocationCode=" + flightInformation.DestinationLocationCode + "&departureDate=" + flightInformation.DepartureDate + "&returnDate=" + flightInformation.ReturnDate + "&adults=" + flightInformation.Adults + "&max=5";

            var message = new HttpRequestMessage(HttpMethod.Get,
                $"/v2/shopping/flight-offers?originLocationCode=SYD&destinationLocationCode=BKK&departureDate=2022-12-01&returnDate=2022-12-18&adults=2");

            ConfigBearerTokenHeader();
            var response = await http.SendAsync(message);
            using var stream = await response.Content.ReadAsStreamAsync();
            FlightPackages second = await JsonSerializer.DeserializeAsync<FlightPackages>(stream);
            return second;


        }

        private void ConfigBearerTokenHeader()
        {
            http.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
        }

    }
}


