using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditAccessor.models;
using RedditAccessor.models.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditAccessor
{
    public class RedditRequestHandler
    {
        public static string GetRedditAccessToken(RedditWebRequest user)
        {
            //TODO: validation
            string url = "https://www.reddit.com/api/v1/access_token";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user.ClientId}:{user.ClientSecret}")));
            client.DefaultRequestHeaders.Add("User-Agent", user.UserAgent);

            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("grant_type", user.GrantType),
            new KeyValuePair<string, string>("username", user.UserName),
            new KeyValuePair<string, string>("password", user.Password)
            });

            var response = client.PostAsync(url, content).Result;
            string tokenResponseString = response.Content.ReadAsStringAsync().Result;

            JObject responseJson = JObject.Parse(tokenResponseString);
            string accessToken = responseJson["access_token"].ToString();
            return accessToken;
        }

        public static List<RedditRequestChildObject> GetSavedPosts(RedditWebRequest request)
        {
            List<RedditRequestChildObject> redditSavedItemsList = new List<RedditRequestChildObject>();
           
            var bearerToken = request.AccessToken;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
            client.DefaultRequestHeaders.Add("User-Agent", request.UserAgent);

            var requestResultCount = 0;
            var requestAfter = "";
            bool finishedLoading = false;

            while(finishedLoading == false) 
            {
                var url = "https://oauth.reddit.com/user/imCooper/saved";
                if (requestResultCount > 0)
                {
                    var pagingParameter = $"?after={requestAfter}";

                    var countParameter = $"&count={requestResultCount}";

                    url += pagingParameter + countParameter;
                }

                var rawResponse = client.GetAsync(url).Result;
                if (!rawResponse.IsSuccessStatusCode)
                {
                    return null;
                }

                var requestResponseString = rawResponse.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<RedditRequestRootObject>(requestResponseString);

                requestAfter = response.Data.After;
                if(requestAfter == null || requestResultCount > 1000) // no more results to process, or requesting too many and cutting it off
                {
                    finishedLoading = true;
                }

               requestResultCount += 25;

                foreach (var savedItem in response.Data.Children)
                {
                    redditSavedItemsList.Add(savedItem);
                }
            }

            return redditSavedItemsList;
        }

    }
}
