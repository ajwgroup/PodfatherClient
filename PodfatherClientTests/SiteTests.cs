using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PodfatherClient.Models;
using System;
using System.IO;
using System.Linq;

namespace PodfatherClientTests
{
    [TestClass]
    public class SiteTests
    {
        [TestMethod]
        public void Site_Deserialization_ShouldHaveExpectedValues()
        {
            var job = JsonConvert.DeserializeObject<Site>(File.ReadAllText("samplesite.json"));
            job.Id.Should().Be(76534);
            job.Customer.Should().Be(1234);
            job.Name.Should().Be("Test Site");
            job.Address1.Should().Be("1 Test Lane");
            job.Address2.Should().Be("2 Test Lane");
            job.Address3.Should().Be("3 Test Lane");
            job.City.Should().Be("Edinburgh");
            job.Region.Should().Be("East Lothian");
            job.Postcode.Should().Be("EH12 9DQ");
            job.Contact.Should().Be("Jason Smith");
            job.Phone.Should().Be("0131 553 0400");
            job.Email.Should().Be("email@site.com");
            job.AccountNumber.Should().Be("Pf01234");
            job.AccountNumber2.Should().Be("Pf56789");
            job.Country.Should().Be("GB");
            job.Coordinate.Latitude.Should().Be(55.93402);
            job.Coordinate.Longitude.Should().Be(-3.30967);
            job.AutoEmail.Should().Be(true);
            job.EtaEmailNotifications.Should().Be(true);
            job.EtaSmsNotifications.Should().Be(false);
            job.Active.Should().Be(true);
        }
    }
}
