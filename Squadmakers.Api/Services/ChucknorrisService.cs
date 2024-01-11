using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using RestSharp;
using RestSharp.Serializers;
using Squadmakers.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;

namespace Squadmakers.Api.Services
{
    public class ChucknorrisService
    {
        private static readonly ChucknorrisService _instance = new ChucknorrisService();

        private ChucknorrisService() { }

        public static ChucknorrisService Instance
        {
            get
            {
                return _instance;
            }
        }

        public string GetJoke()
        {
            HttpClient client = new HttpClient();
            string URL = ConfigurationManager.AppSettings["ChucknorrisApi"] + "/random";
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            var  responseBody = "";
            string responseText = "";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "error";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                            ChuckNorrisJoke joke = JsonConvert.DeserializeObject<ChuckNorrisJoke>(responseBody);
                            responseText = joke.value;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                responseText = ex.Message;
            }

            return responseText;

        }
     
    }
}