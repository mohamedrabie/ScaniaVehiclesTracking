using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Net.Http;
using System.Net.Http.Headers;
using Scania.VT.Helpers;

namespace Scania.VT.UI.Web.Hubs
{
    [HubName("VehiclesHub")]
    public class VehiclesHub : Hub
    {

        public static readonly string APiUrl = "http://localhost:17645/";

        public void Hello()
        {
            Clients.All.hello();
        }


        public string UpdateMyStatus(string vehicleId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(APiUrl);
            SetToken(ref client);
            var model = new VehicleStatusStruct { vehicleId = vehicleId, status = (int)Helpers.Enums.VehicleStatusEnum.Online };
            var result = client.PostAsJsonAsync("api/Vehicle/UpdateMyStatus", model);
            if (result.Result.IsSuccessStatusCode)
            {
                NotifyInformationToAllClients();
            }


            return vehicleId;
        }

        public static void NotifyInformationToAllClients()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<VehiclesHub>();
            context.Clients.All.UpdateData();
        }

        public static void SetToken(ref HttpClient client)
        {
            var token = client.PostAsync("/oauth/Token",
                new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string,string>("grant_type","password"),
                        new KeyValuePair<string,string>("username","user1"),
                        new KeyValuePair<string,string>("password","123")
                })).Result.Content.ReadAsAsync<AuthenticationToken>().Result;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.token_type, token.access_token);
        }

    }
}