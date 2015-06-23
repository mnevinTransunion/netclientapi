using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trustev_DotNet.Entities.Internal;
using Trustev_DotNet.Exceptions;

namespace Trustev_DotNet.Entities
{
    public abstract class BaseEntity
    {
        internal static async Task<string> PerformHttpCallAsync(string uri, HttpMethod method, string json = "", bool IsAuthenticationNeeded = true)
        {
            String result = "";

            HttpClient client = new HttpClient();

            if (IsAuthenticationNeeded)
            {
                client.DefaultRequestHeaders.Add("X-Authorization", Trustev.UserName + " " + await Token.GetTokenAsync());
            }

            HttpResponseMessage response = new HttpResponseMessage();

            if(method == HttpMethod.Post)
            {
                response = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            }
            else if (method == HttpMethod.Put)
            {
                response = await client.PutAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            }
            else if (method == HttpMethod.Get)
            {
                response = await client.GetAsync(uri);
            }

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                result = await response.Content.ReadAsStringAsync();

                throw new TrustevHttpException(response.StatusCode, result);
            }

            return result;
        }
        internal static string PerformHttpCall(string uri, HttpMethod method, string json = "", bool IsAuthenticationNeeded = true)
        {
            try
            {
                String result = "";

                WebRequest request = WebRequest.Create(uri);

                request.Method = method.ToString();

                request.ContentType = "application/json";

                if (IsAuthenticationNeeded)
                {
                    request.Headers.Add("X-Authorization", String.Format("{0} {1}", Trustev.UserName, Token.GetToken()));
                }

                if (method != HttpMethod.Get)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(json);

                    request.ContentLength = byteArray.Length;

                    Stream requestDataStream = request.GetRequestStream();

                    requestDataStream.Write(byteArray, 0, byteArray.Length);

                    requestDataStream.Close();
                }

                WebResponse response = request.GetResponse();

                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                Stream responseSataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(responseSataStream);

                result = reader.ReadToEnd();

                reader.Close();
                responseSataStream.Close();
                response.Close();

                return result;
                
            }
            catch (WebException ex)
            {
                Stream responseSataStream = ex.Response.GetResponseStream();

                StreamReader reader = new StreamReader(responseSataStream);

                string errorMessage = reader.ReadToEnd();

                throw new TrustevHttpException(((HttpWebResponse)ex.Response).StatusCode, errorMessage);
            }
        }
    }
}
