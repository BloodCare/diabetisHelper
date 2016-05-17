using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MobileFramework.Model.Network
{
    /// <summary>
    /// organizes http communication with the MSM
    /// </summary>
    public class HttpCommunicator
    {
        /// <summary>
        /// generic request class with digest authentication
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetRequest(string url)
        {
            int counter = 0;
            bool status = false;
            var result = "";
            while(counter < 3 && status==false){
                try
                {
                    var url_tmp = url; 

                    //add credentials to request
                    var credCache = new CredentialCache();
                    var cred = new NetworkCredential("admin", "abb");
                    credCache.Add(new Uri(url),AuthenticationSchemes.Digest.ToString(), new NetworkCredential("admin", "abb"));
                    NativeMessageHandler nativeHandler = new NativeMessageHandler();
                    nativeHandler.Credentials = credCache.GetCredential(new Uri(url), AuthenticationSchemes.Digest.ToString());
                    var handler = new HttpClientHandler();
                    handler.PreAuthenticate = true;
                    handler.Credentials = credCache.GetCredential(new Uri(url), "Digest");
                    var client = new HttpClient(nativeHandler);
                    //set timeout for Request
                    client.Timeout = new TimeSpan(0,0,10);
                    var answer = client.GetAsync(new Uri(url));
                    if (answer.Result.StatusCode == HttpStatusCode.OK)
                    {
                        status = true;
                    }
                    Debug.WriteLine("------------------------->" + answer.Result);
                    Debug.WriteLine("***********************************************************************************");
                    result = answer.Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine("json: " + result);
                    
                    counter++;
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }
            return result;
        }
    }
}