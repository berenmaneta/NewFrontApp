using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace NewFrontApp.API_Client
{
    public class GenericWebApiClient<T> : IDisposable where T : class
    {

        HttpClient client = new HttpClient();
        Uri ServiceBaseUri;

        public GenericWebApiClient(Uri ServiceUri)
        {
            if (ServiceUri == null)
            {
                throw new UriFormatException("A valid URI is required.");
            }
            ServiceBaseUri = ServiceUri;
        }

        // GETS ALL RECORDS FROM A GENERIC MODEL 
        public List<T> GetAll()
        {
            //THIS LINE IS HERE TO FIX A CERTIFICATE ERROR
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var response = client.GetAsync(ServiceBaseUri).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<T>>().Result as List<T>;

            }
            else if (response.StatusCode != HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException("Get failed with " + response.StatusCode.ToString());
            }

            return null;
        }

        // GETS ALL RECORDS FROM A GENERIC MODEL 
        public List<T> GetAllByCategory()
        {
            //THIS LINE IS HERE TO FIX A CERTIFICATE ERROR
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var response = client.GetAsync(ServiceBaseUri).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<T>>().Result as List<T>;

            }
            else if (response.StatusCode != HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException("Get failed with " + response.StatusCode.ToString());
            }

            return null;
        }

        // GETS AN ESPECIFIC RECORD FROM A GENERIC MODEL
        public T GetById<I>(I Id)
        {
            if (Id == null)
                return default(T);

            var response = client.GetAsync(ServiceBaseUri.AddSegment(Id.ToString())).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result as T;
            }
            else if (response.StatusCode != HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException("Get failed with " + response.StatusCode.ToString());
            }

            return null;
        }

        // ALTERS AN ESPECIFIC RECORD FROM A GENERIC MODEL
        public void Edit<I>(T t, I Id)
        {
            //THIS LINE IS HERE TO FIX A CERTIFICATE ERROR
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var response = client.PutAsJsonAsync(ServiceBaseUri.AddSegment(Id.ToString()), t).Result;

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException("Edit failed with " + response.StatusCode.ToString());
        }

        // DELETES AN ESPECIFIC RECORD FROM A GENERIC MODEL
        public void Delete<I>(I Id)
        {
            var response = client.DeleteAsync(ServiceBaseUri.AddSegment(Id.ToString())).Result;

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException("Delete failed with " + response.StatusCode.ToString());
        }

        // CREATES A RECORD FOR A GENERIC MODEL PROVIDED
        public void Create(T t)
        {
            //THIS LINE IS HERE TO FIX A CERTIFICATE ERROR
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var response = client.PostAsJsonAsync(ServiceBaseUri, t).Result;

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException("Create failed with " + response.StatusCode.ToString());
        }


        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                client = null;
                ServiceBaseUri = null;
            }
        }

        public void Dispose()
        {
            this.Dispose(false);
            GC.SuppressFinalize(this);
        }

        ~GenericWebApiClient()
        {
            this.Dispose(false);
        }

    }

    static class UriExtensions
    {
        public static Uri AddSegment(this Uri OriginalUri, string Segment)
        {
            UriBuilder ub = new UriBuilder(OriginalUri);
            ub.Path = ub.Path + ((ub.Path.EndsWith("/")) ? "" : "/") + Segment;

            return ub.Uri;
        }
    }
}