using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodfatherClient;
using PodfatherClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodfatherClientTests
{
    [TestClass]
    public class IntegrationTestsV1
    {
        ILoggerFactory loggerFactory;

        [TestInitialize]
        public void TestInitialise()
        {
            loggerFactory = new LoggerFactory().AddConsole().AddDebug();
        }

        private ILogger GetLogger()
        {
            return loggerFactory.CreateLogger<IntegrationTestsV1>();
        }

        public string GetAPIUrl()
        {
            return Environment.GetEnvironmentVariable("APIURL");
        }

        public string GetAPIKey()
        {
            return Environment.GetEnvironmentVariable("APIKEY");
        }

        [TestMethod]
        public void CreateSiteAsync_PassObject_ShouldNotThrowException()
        {
            var testJob = new NewSite()
            {
                Name = ("AVIA TECHNIQUE LTD"),
                Phone = (""),
                Postcode = ("RG41 2QJ"),
                Region = ("UNITED KINGDOM"),
                AccountNumber = (null),
                AccountNumber2 = (null),
                Address1 = ("UNIT 3 FISHPONDS ESTATE"),
                Address2 = ("FISHPONDS ROAD"),
                Address3 = ("WOKINGHAM"),
                AutoEmail = (false),
                City = ("BERKSHIRE"),
                Contact = (""),
                Coordinate = null,
                Country = ("GB"),
                Customer = (1286862),
                Email = (""),
                EtaEmailNotifications = (null),
                EtaSmsNotifications = (null)
            };

            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var result = Task.Run(async () => await client.CreateSiteAsync(testJob).ConfigureAwait(false)).Result;
            result.Id.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GetAccountAsync_PassUrlSecret_ReturnObject()
        {
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var account = Task.Run(async () => await client.GetAccountAsync().ConfigureAwait(false)).Result;
            account.Address1.Should().Be("The Headquarters");
        }

        [TestMethod]
        public void GetJobAsync_PassJobId_ReturnObject()
        {
            var jobId = 2769052;
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var job = Task.Run(async () => await client.GetJobAsync(jobId).ConfigureAwait(false)).Result;
            job.Id.Should().Be(jobId);
        }

        [TestMethod]
        public void GetCustomerAsync_PassId_ReturnObject()
        {
            var customerId = 727065;
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var result = Task.Run(async () => await client.GetCustomerAsync(customerId).ConfigureAwait(false)).Result;
            result.Id.Should().Be(customerId);
            result.Address1.Should().Be("Exchange House");
            result.Address2.Should().Be("54-58 Athol Street");
            result.Address3.Should().Be("");
            result.AutoEmail.Should().Be(false);
            result.City.Should().Be("Douglas IM1 1JD");
            result.Country.Should().Be("GB");
            result.Email.Should().Be(null);
            result.Name.Should().Be("A J WALTER LEASING LTD");
            result.Phone.Should().Be(null);
            result.Postcode.Should().Be("");
            result.Region.Should().Be(null);
        }

        [TestMethod]
        public void GetCustomersAsync_PassNothing_ReturnObjects()
        {
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var results = Task.Run(async () => await client.GetCustomersAsync().ConfigureAwait(false)).Result;
            results.Count().Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void CreateCustomerAsync_PassNothing_ReturnObjects()
        {
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var newCustomer = new NewCustomer();
            newCustomer.Address1 = "Exchange House";
            newCustomer.Address2 = "54-58 Athol Street";
            newCustomer.Address3 = "";
            newCustomer.AutoEmail = false;
            newCustomer.City = "Douglas";
            newCustomer.Country = "GB";
            newCustomer.Email = null;
            newCustomer.Name = "DOTNOUSE-UNITTEST";
            newCustomer.Phone = null;
            newCustomer.Postcode = "IM1 1JD";
            newCustomer.Region = null;

            var result = Task.Run(async () => await client.CreateCustomerAsync(newCustomer).ConfigureAwait(false)).Result;
            result.Id.Should().BeGreaterThan(0);
            result.Address1.Should().Be(newCustomer.Address1);
            result.Address2.Should().Be(newCustomer.Address2);
            result.Address3.Should().Be(newCustomer.Address3);
            result.AutoEmail.Should().Be(newCustomer.AutoEmail);
            result.City.Should().Be(newCustomer.City);
            result.Country.Should().Be(newCustomer.Country);
            result.Email.Should().Be(newCustomer.Email);
            result.Name.Should().Be(newCustomer.Name);
            result.Phone.Should().Be(newCustomer.Phone);
            result.Postcode.Should().Be(newCustomer.Postcode);
            result.Region.Should().Be(newCustomer.Region);
        }

        [TestMethod]
        public void GetSiteAsync_PassId_ReturnObject()
        {
            var siteId = 3943512;
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var site = Task.Run(async () => await client.GetSiteAsync(siteId).ConfigureAwait(false)).Result;
            site.Id.Should().Be(siteId);
            site.Name.Should().Be("AVIA TECHNIQUE LTD");
            site.Phone.Should().Be("");
            site.Postcode.Should().Be("");
            site.Region.Should().Be("UNITED KINGDOM");
            site.AccountNumber.Should().Be(null);
            site.AccountNumber2.Should().Be(null);
            site.Active.Should().Be(true);
            site.Address1.Should().Be("UNIT 3 FISHPONDS ESTATE");
            site.Address2.Should().Be("FISHPONDS ROAD");
            site.Address3.Should().Be("WOKINGHAM");
            site.AutoEmail.Should().Be(false);
            site.City.Should().Be("BERKSHIRE RG41 2QJ");
            site.Contact.Should().Be("");
            site.Coordinate.Latitude.Should().Be(null);
            site.Coordinate.Longitude.Should().Be(null);
            site.Country.Should().Be("GB");
            site.Customer.Should().Be(1286862);
            site.Email.Should().Be("");
            site.EtaEmailNotifications.Should().Be(null);
            site.EtaSmsNotifications.Should().Be(null);
        }

        [TestMethod]
        public void GetSitesAsync_PassId_ReturnObject()
        {
            var customerId = 1286862;
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var sites = Task.Run(async () => await client.GetSitesAsync(customerId).ConfigureAwait(false)).Result;
            var site = sites.FirstOrDefault(e => e.Id == 3943512);
            site.Name.Should().Be("AVIA TECHNIQUE LTD");
            site.Phone.Should().Be("");
            site.Postcode.Should().Be("");
            site.Region.Should().Be("UNITED KINGDOM");
            site.AccountNumber.Should().Be(null);
            site.AccountNumber2.Should().Be(null);
            site.Active.Should().Be(true);
            site.Address1.Should().Be("UNIT 3 FISHPONDS ESTATE");
            site.Address2.Should().Be("FISHPONDS ROAD");
            site.Address3.Should().Be("WOKINGHAM");
            site.AutoEmail.Should().Be(false);
            site.City.Should().Be("BERKSHIRE RG41 2QJ");
            site.Contact.Should().Be("");
            site.Coordinate.Latitude.Should().Be(null);
            site.Coordinate.Longitude.Should().Be(null);
            site.Country.Should().Be("GB");
            site.Customer.Should().Be(1286862);
            site.Email.Should().Be("");
            site.EtaEmailNotifications.Should().Be(null);
            site.EtaSmsNotifications.Should().Be(null);
        }


        [TestMethod]
        public void GetCustomersAsync_PassName_ReturnObjectsContaining()
        {
            var customerName = "A J WALTER LEASING LTD";
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var results = Task.Run(async () => await client.GetCustomersAsync(0, customerName).ConfigureAwait(false)).Result;
            var result = results.FirstOrDefault(e => e.Id == 727065);
            result.Id.Should().Be(727065);
            result.Address1.Should().Be("Exchange House");
            result.Address2.Should().Be("54-58 Athol Street");
            result.Address3.Should().Be("");
            result.AutoEmail.Should().Be(false);
            result.City.Should().Be("Douglas IM1 1JD");
            result.Country.Should().Be("GB");
            result.Email.Should().Be(null);
            result.Name.Should().Be("A J WALTER LEASING LTD");
            result.Phone.Should().Be(null);
            result.Postcode.Should().Be("");
            result.Region.Should().Be(null);
        }

        [TestMethod]
        public void GetPodsAsync_PassUrlSecret_ReturnObject()
        {
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var account = Task.Run(async () => await client.GetPodsAsync().ConfigureAwait(false)).Result;
            account.FirstOrDefault().Id.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GetPodByJobIdAsync_PassUrlSecret_ReturnObject()
        {
            var jobId = 511651225;
            var expectedPodId = 293450275;

            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());
            var pod = Task.Run(async () => await client.GetPodByJobIdAsync(jobId).ConfigureAwait(false)).Result;
            pod.Job.Should().Be(jobId);
            pod.CosmeticId.Should().BeGreaterThan(0);
            pod.Id.Should().Be(expectedPodId);
        }

        [TestMethod]
        public void GetPodsPdfAsync_PassUrlSecret_ReturnObject()
        {
            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var pods = Task.Run(async () => await client.GetPodsAsync().ConfigureAwait(false)).Result;
            var cosmeticId = pods.FirstOrDefault(e => e.CosmeticId > 0).CosmeticId;
            var pdf = Task.Run(async () => await client.GetPodsPdfAsync(cosmeticId).ConfigureAwait(false)).Result;
            pdf.GetBytes().Length.Should().BeGreaterThan(0);

        }

        [TestMethod]
        public void CreateJobAsync_PassObject_ShouldNotThrowException()
        {
            var testJob = new NewJob()
            {
                Customer = 832825, // WIND ROSE AVIATION COMPANY LTD
                Depot = 39645, // Test Depot
                Site = 15067072, // WIND ROSE AVIATION COMPANY LTD
                Instructions1 = "Integration Test Please Ignore",
                Template = 1594, // DELIVERY ORDER
                DueBy = DateTime.Now.AddDays(10),
                Items = new List<NewJobItemsData>()
                {
                    new NewJobItemsData()
                    {
                        Name = "IntegrationTest",
                        Quantity = 1
                    }
                }
            };

            var client = new PodfatherClientV1(GetAPIKey());
            client.SetLogger(GetLogger());

            var result = Task.Run(async () => await client.CreateJobAsync(testJob).ConfigureAwait(false)).Result;
            result.Id.Should().BeGreaterThan(0);

            var deleteResult = Task.Run(async () => await client.DeleteJobAsync(result.Id).ConfigureAwait(false)).Result;
            deleteResult.Should().BeTrue();

        }
    }
}
