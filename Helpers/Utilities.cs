using RestSharp;

namespace ResourceRequestService.Helpers
{
    public class Utilities
    {
        public bool sendEmail(emailSendModel model)
        {
            var client = new RestClient();
            //var request = new RestRequest("https://10.50.5.120:3023/api/sendemailv2", method: Method.Post);
            var request = new RestRequest("https://internalapp.acuitykp.com/BPAS.EMAIL/api/sendemailv2", method: Method.Post);
            request.AddHeader("Access-Control-Allow-Origin", "*");
            request.AddHeader("Authorization", "Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA");
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(model);
            var response = client.ExecuteAsync(request).Result;
          
            bool success = ((int)response.StatusCode) >= 200 && ((int)response.StatusCode) < 300;
            return success;

            //response.Status = true;
        }

    }
}
