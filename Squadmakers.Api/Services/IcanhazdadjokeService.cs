using Newtonsoft.Json;
using Squadmakers.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Configuration;

namespace Squadmakers.Api.Services
{
    public class IcanhazdadjokeService
    {
        private static readonly IcanhazdadjokeService _instance = new IcanhazdadjokeService();

        private IcanhazdadjokeService() { }

        public static IcanhazdadjokeService Instance
        {
            get
            {
                return _instance;
            }
        }

        public string GetJoke()
        {
            HttpClient client = new HttpClient();
            string URL = ConfigurationManager.AppSettings["IcanhazdadjokeApi"];
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            var responseBody = "";
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
                            IcanhazdadJoke joke = JsonConvert.DeserializeObject<IcanhazdadJoke>(responseBody);
                            responseText = joke.joke;
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