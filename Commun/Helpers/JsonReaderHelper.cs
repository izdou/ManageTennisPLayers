using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Commun.Helpers
{ 
    /// <summary>
  /// Hepler to read any json object
  /// </summary>
  /// <typeparam name="T">json object to read</typeparam>
    public static class JsonReaderHelper<T> where T : new()
    {
        private const string url = "https://eurosportdigital.github.io/eurosport-csharp-developer-recruitment/headtohead.json";
        public static T GetSerializedJsonFromUrl()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}
