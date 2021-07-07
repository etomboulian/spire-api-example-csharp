using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.Client
{
    public abstract class BaseObjectClient<T> where T : new()
    {
        protected ApiClient Client;

        public BaseObjectClient(ApiClient client)
        {
            Client = client;
        }

        string BaseResource
        {
            get
            {
                return string.Format("companies/{0}/", Client.Company);
            }
        }

        abstract public string Resource { get; }

        /// <summary>
        /// List objects in resource collection
        /// </summary>
        /// <param name="start">Start offset in list</param>
        /// <param name="limit">Limit objects returned; defaults to 100</param>
        /// <param name="query">Search string</param>
        /// <param name="filter">Filter criteria</param>
        /// <returns></returns>
        public List<T> List(int start = 0, int limit = 100, string query = null, object filter = null)
        {
            var request = new RestRequest();

            if (start != 0)
                request.AddQueryParameter("start", start.ToString());

            if (limit != 100)
                request.AddQueryParameter("limit", limit.ToString());

            if (query != null)
                request.AddQueryParameter("q", query);

            if (filter != null)
            {
                string jsonFilter = JsonConvert.SerializeObject(filter);
                request.AddQueryParameter("filter", jsonFilter);
            }

            request.RequestFormat = DataFormat.Json;
            request.Resource = BaseResource + Resource;
            //request.RootElement = "records";
            return Client.Execute<List<T>>(request);
        }

        /// <summary>
        /// Get object by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Fetch(int? id)
        {
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.Resource = BaseResource + Resource + id;
            return Client.Execute<T>(request);
        }

        /// <summary>
        /// Create new object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Create(T obj)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.Resource = BaseResource + Resource;
            request.AddJsonBody(obj);
            return Client.Execute<T>(request);
        }

        /// <summary>
        /// Update existing object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Update(int? id, T obj)
        {
            var request = new RestRequest(Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.Resource = BaseResource + Resource + id;
            request.AddJsonBody(obj);
            return Client.Execute<T>(request);
        }

        /// <summary>
        /// Delete object by ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            var request = new RestRequest(Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.Resource = BaseResource + Resource + id;
            Client.Execute<ErrorResponse>(request);
        }
    }
}
