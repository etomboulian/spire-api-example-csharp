using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace ApiTest.Client
{
    /// <summary>
    /// API client used to authenticate a user's access to a company, send requests, and receive responses
    /// </summary>
    public class ApiClient
    {
        // URL for API access; port may need to be changed if non-standard
        public string BaseUrl;
        readonly public string Hostname;
        readonly public int Port;
        readonly public string Company;
        readonly string _username;
        readonly string _password;
        
        RestClient _client;
        

        /// <summary>
        /// Instantiate an ApiClient
        /// </summary>
        /// <param name="company">Company short name</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ApiClient(string hostname, int port, string company, string username, string password)
        {
            Hostname = hostname;
            Port = port;
            Company = company;
            _username = username;
            _password = password;

            BaseUrl = $"https://{hostname}:{port}/api/v2";

            _client = Client();
        }

        RestClient Client()
        {
            // Accept self-signed certificate
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;

            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(_username, _password);
            client.FollowRedirects = false;
            return client;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);

            HttpStatusCode code = response.StatusCode;
            if (code == HttpStatusCode.Unauthorized)
                throw new ApiException("Username or password incorrect");

            if (code != HttpStatusCode.BadRequest &&
                code != HttpStatusCode.InternalServerError &&
                response.ErrorException != null)
                throw new ApplicationException(response.ErrorMessage,
                    response.ErrorException);

            if (code == HttpStatusCode.OK || code == HttpStatusCode.NoContent)
                return response.Data;

            if (code == HttpStatusCode.Created)
            {
                // Manually follow header redirect
                foreach (var p in response.Headers)
                {
                    if (p.Name == "Location")
                    {
                        var secondRequest = new RestRequest();
                        var location = (string)p.Value;
                        secondRequest.Resource = location.Remove(0,
                            _client.BaseUrl.ToString().Length);
                        return Execute<T>(secondRequest);
                    }
                }
            }

            throw new ApiException(response.Content);
        }
    }
}
