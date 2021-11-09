using System;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PodfatherClient.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Converters;

namespace PodfatherClient
{
    public class PodfatherClientV1 : IDisposable
    {
        private ILogger logger;
        private Uri serviceUri = new Uri("https://external-api.aws.thepodfather.com");
        private string accessKey = "";

        public PodfatherClientV1(String accessKey, String serviceUri = null)
        {
            this.accessKey = accessKey;
            if (serviceUri != null)
                this.serviceUri = new Uri(serviceUri);
        }

        public void SetLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public void LogInfo(String message)
        {
            logger?.LogDebug(message);
        }

        public void LogDebug(String message)
        {
            logger?.LogDebug(message);
        }

        public void Dispose()
        {
        }

        public async Task<Account> GetAccountAsync()
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync("/v1/account").ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<AccountContainer>(responseJson).Account;
                }
                else
                {
                    LogDebug("GetAccountAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<List<Pod>> GetPodsAsync()
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync("/v1/pods").ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<PodsContainer>(responseJson).Pods;
                }
                else
                {
                    LogDebug("GetPodsAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<List<Pod>> GetPodsAsync(DateTime dateFrom, DateTime dateTo)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"/v1/pods?dateFrom={dateFrom.ToString("yyyy-MM-dd'T'HH:mm:ssZ")}&dateTo={dateTo.ToString("yyyy-MM-dd'T'HH:mm:ssZ")}").ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<PodsContainer>(responseJson).Pods;
                }
                else
                {
                    LogDebug("GetPodsAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<Customer> GetCustomerAsync(long customerId)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format("/v1/customers/{0}", customerId)).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<CustomerContainer>(responseJson).Customer;
                }
                else
                {
                    LogDebug("GetCustomerAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<Site> GetSiteAsync(long siteId)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format("/v1/sites/{0}", siteId)).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<SiteContainer>(responseJson).Site;
                }
                else
                {
                    LogDebug("GetSiteAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<List<Site>> GetSitesAsync(long customerId)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format("/v1/sites?customer={0}", customerId)).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<SitesContainer>(responseJson).Sites;
                }
                else
                {
                    LogDebug("GetSitesAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(int pageNumber = 0, string name = "")
        {
            var nameFilter = "";
            if (!String.IsNullOrEmpty(name))
            {
                nameFilter = $"&name={name}";
            }

            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format($"/v1/customers?page={pageNumber}&active=true{nameFilter}")).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<CustomersContainer>(responseJson).Customers;
                }
                else
                {
                    LogDebug("GetCustomersAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<Pod> GetPodByJobIdAsync(long jobId)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format("/v1/pods?job={0}",jobId)).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<PodsContainer>(responseJson).Pods.FirstOrDefault();
                }
                else
                {
                    LogDebug("GetPodByJobIdAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<Pod> GetPodByJobIdAsync(long jobId, DateTime dateFrom, DateTime dateTo)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format($"/v1/pods?job={jobId}&dateFrom={dateFrom.ToString("yyyy-MM-dd'T'HH:mm:ssZ")}&dateTo={dateTo.ToString("yyyy-MM-dd'T'HH:mm:ssZ")}")).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<PodsContainer>(responseJson).Pods.FirstOrDefault();
                }
                else
                {
                    LogDebug("GetPodByJobIdAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<PodPdf> GetPodsPdfAsync(long podfCosmeticId)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/pdf"));
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format("/v1/podPdf/{0}", podfCosmeticId)).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        var contentStream = await responseMessage.Content.ReadAsStreamAsync();
                        contentStream.CopyTo(memoryStream);
                        return new PodPdf(memoryStream.ToArray());
                    }
                }
                else
                {
                    LogDebug("GetPodsPdfAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<bool> DeleteJobAsync(long jobId)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("/v1/jobs/{0}", jobId)).ConfigureAwait(false);
                return responseMessage.IsSuccessStatusCode;
            }
        }

        public async Task<CreatedJob> CreateJobAsync(NewJob job)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                String json = JsonConvert.SerializeObject(job, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-ddThh:mm:ssZ" });
                HttpResponseMessage responseMessage = await client.PostAsync("/v1/jobs", new StringContentWithoutCharset(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<CreatedJob>(responseJson);
                }
                else
                {
                    LogDebug("CreateJobAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<CreatedRun> CreateRunAsync(NewRun run)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                String json = JsonConvert.SerializeObject(run, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-ddThh:mm:ssZ" });
                HttpResponseMessage responseMessage = await client.PostAsync("/v1/runs", new StringContentWithoutCharset(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<CreatedRun>(responseJson);
                }
                else
                {
                    LogDebug("CreateRunAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<Site> CreateSiteAsync(NewSite newSite)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                String json = JsonConvert.SerializeObject(newSite, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-ddThh:mm:ssZ" });
                HttpResponseMessage responseMessage = await client.PostAsync("/v1/sites", new StringContentWithoutCharset(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<SiteContainer>(responseJson).Site;
                }
                else
                {
                    LogDebug("CreateSiteAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<Customer> CreateCustomerAsync(NewCustomer newCustomer)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                String json = JsonConvert.SerializeObject(newCustomer, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-ddThh:mm:ssZ" });
                HttpResponseMessage responseMessage = await client.PostAsync("/v1/customers", new StringContentWithoutCharset(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<CustomerContainer>(responseJson).Customer;
                }
                else
                {
                    LogDebug("CreateCustomerAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }

        public async Task<Job> GetJobAsync(long jobId)
        {
            using (var client = HttpClientFactory.CreateClient(serviceUri, accessKey))
            {
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format("/v1/jobs/{0}", jobId)).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<Jobs>(responseJson).Job;
                }
                else
                {
                    LogDebug("GetJobAsync|Received response code: " + responseMessage.StatusCode);
                    throw new HttpResponseException(responseMessage);
                }
            }
        }
    }
}
