using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trustev_DotNet.Entities.Internal;
using Trustev_DotNet.Exceptions;

namespace Trustev_DotNet.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// This method asynchronously performs the Http Request to the Trustev API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="entity"></param>
        /// <param name="IsAuthenticationNeeded"></param>
        /// <returns></returns>
        internal static async Task<T> PerformHttpCallAsync<T>(string uri, HttpMethod method, object entity, bool IsAuthenticationNeeded = true)
        {
            HttpClient client = new HttpClient();

            if (IsAuthenticationNeeded)
            {
                client.DefaultRequestHeaders.Add("X-Authorization", Trustev.UserName + " " + await Token.GetTokenAsync());
            }

            HttpResponseMessage response = new HttpResponseMessage();

            string json = "";

            if (entity != null && entity.GetType() != typeof(string))
            {
                json = JsonConvert.SerializeObject(entity);
            }
            else
            {
                json = (string)entity;
            }

            if (method == HttpMethod.Post)
            {
                response = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            }
            else if(method == HttpMethod.Put)
            {
                response = await client.PutAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
            }
            else if (method == HttpMethod.Get)
            {
                response = await client.GetAsync(uri);
            }

            string resultstring = "";

            if (response.IsSuccessStatusCode)
            {
                resultstring = await response.Content.ReadAsStringAsync();
            }
            else
            {
                resultstring = await response.Content.ReadAsStringAsync();

                throw new TrustevHttpException(response.StatusCode, resultstring);
            }

            return JsonConvert.DeserializeObject<T>(resultstring);;
        }

        /// <summary>
        /// This method synchronously performs the Http Request to the Trustev API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="entity"></param>
        /// <param name="IsAuthenticationNeeded"></param>
        /// <returns></returns>
        internal static T PerformHttpCall<T>(string uri, HttpMethod method, object entity, bool IsAuthenticationNeeded = true)
        {
            try
            {
                WebRequest request = WebRequest.Create(uri);

                request.Method = method.ToString();

                request.ContentType = "application/json";

                if (IsAuthenticationNeeded)
                {
                    request.Headers.Add("X-Authorization", string.Format("{0} {1}", Trustev.UserName, Token.GetToken()));
                }

                if (method != HttpMethod.Get)
                {
                    string json = JsonConvert.SerializeObject(entity);

                    byte[] byteArray = Encoding.UTF8.GetBytes(json);

                    request.ContentLength = byteArray.Length;

                    Stream requestDataStream = request.GetRequestStream();

                    requestDataStream.Write(byteArray, 0, byteArray.Length);

                    requestDataStream.Close();
                }

                WebResponse response = request.GetResponse();

                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                Stream responseDataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(responseDataStream);

                string resultstring = reader.ReadToEnd();

                reader.Close();
                responseDataStream.Close();
                response.Close();

                return JsonConvert.DeserializeObject<T>(resultstring);
                
            }
            catch (WebException ex)
            {
                Stream responseDataStream = ex.Response.GetResponseStream();

                StreamReader reader = new StreamReader(responseDataStream);

                string errorMessage = reader.ReadToEnd();

                reader.Close();
                responseDataStream.Close();
                ex.Response.Close();

                throw new TrustevHttpException(((HttpWebResponse)ex.Response).StatusCode, errorMessage);
            }
        }
    }
}
