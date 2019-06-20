using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace CSharpJamApp.Models
{
    public class SportDAL
    {
        public static JObject GetSportContent(string playerId)
        {

            HttpWebRequest request = WebRequest.CreateHttp($"http://www.omdbapi.com/?apikey=1{playerId}");

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());

                JObject sportData = JObject.Parse(data.ReadToEnd());
                return sportData;
            }
            return null;
        }
    }
}