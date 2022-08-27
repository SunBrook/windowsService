using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace Fissoft.Taihe.Shiyan.UpdateExpectStartTime.ClassLibrary.Tools
{
    public class RequestUtils
    {
        public static TResult Post<TBody, TResult>(string url, TBody bodyParams, Action<string> errorAction)
            where TBody : class, new()
            where TResult : class
        {
            var client = new RestClient(url) { Timeout = 15000 };
            var request = new RestRequest { RequestFormat = DataFormat.Json };
            request.AddJsonBody(bodyParams);
            var response = client.Post<TBody>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                //网络异常
                errorAction(response.ErrorMessage);
                return null;
            }

            var result = JsonConvert.DeserializeObject<TResult>(response.Content);
            return result;
        }
    }
}


namespace DataDispose.Library.Tools
{
    public class RequestUtils
    {
        public static TResult Post<TBody, TResult>(string url, TBody bodyParams, Action<string> errorAction)
            where TBody : class, new()
            where TResult : class
        {
            var client = new RestClient(url) { Timeout = 15000 };
            var request = new RestRequest { RequestFormat = DataFormat.Json };
            request.AddJsonBody(bodyParams);
            var response = client.Post<TBody>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                //网络异常
                errorAction(response.ErrorMessage);
                return null;
            }

            var result = JsonConvert.DeserializeObject<TResult>(response.Content);
            return result;
        }
    }
}
