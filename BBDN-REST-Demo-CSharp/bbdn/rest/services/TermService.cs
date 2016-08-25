﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualStudio.Services.WebApi; /* for PATCH */
using BBDNRESTDemoCSharp;

namespace BBDNRESTDemoCSharp
{
    public class TermService : IRestService<Term>, IDisposable
    {
        HttpClient client;


        public TermService(Token token)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
        }

        
        public async Task<Term> CreateObject(Term newTerm)
        {
            Term term = new Term();
            var uri = new Uri(Constants.HOSTNAME + Constants.TERM_PATH);

            ///learn/api/public/v1/terms
            ///post /learn/api/public/v1/terms 

            try
            {
                var json = JsonConvert.SerializeObject(newTerm);
                var body = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, body);
                Constants.RESPONSERESULT = "Fail";
                if (response.IsSuccessStatusCode)
                {
                    Constants.RESPONSERESULT = "Create";
                    var content = await response.Content.ReadAsStringAsync();
                    term = JsonConvert.DeserializeObject<Term>(content);
                    Debug.WriteLine(@"Term successfully created.");
                }
                else
                {
                    if (response.ToString().Contains("409"))
                    {
                        Constants.RESPONSERESULT = "Update";
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return term;
        }

        
        public async Task<Term> ReadObject()
        {
            Term term = new Term();

            //var uri = new Uri(Constants.HOSTNAME + Constants.TERM_PATH + "externalId:" + Constants.TERM_ID);
            var uri = new Uri(Constants.HOSTNAME + Constants.TERM_PATH);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    term = JsonConvert.DeserializeObject<Term>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return term;
        }

        
        public async Task<Term> UpdateObject(Term updateTerm)
        {
            Term term = new Term();

            try
            {
                var json = JsonConvert.SerializeObject(updateTerm);
                var body = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await HttpClientExtensions.PatchAsync(client, Constants.HOSTNAME + Constants.TERM_PATH + "/externalId:" + Constants.TERM_ID, body);

                Constants.RESPONSERESULT = "Fail";
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Term successfully updated.");
                    var content = await response.Content.ReadAsStringAsync();
                    term = JsonConvert.DeserializeObject<Term>(content);
                    Constants.RESPONSERESULT = "Update";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return (term);
        }

        public async Task<Term> DeleteObject()
        {
            Term term = new Term();
            var uri = new Uri(Constants.HOSTNAME + Constants.TERM_PATH + "externalId:" + Constants.TERM_ID);

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Term successfully deleted.");
                    var content = await response.Content.ReadAsStringAsync();
                    term = JsonConvert.DeserializeObject<Term>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return (term);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                client.Dispose();

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~TermService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
           Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

