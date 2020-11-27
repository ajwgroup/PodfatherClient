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
    public class CustomerTests
    {
        [TestMethod]
        public void Customer_Deserialization_ShouldHaveExpectedValues()
        {
            var job = JsonConvert.DeserializeObject<Customer>(File.ReadAllText("samplecustomer.json"));
            job.Name.Should().Be("Test Customer");
            job.Address1.Should().Be("1 Test Lane");
            job.Address2.Should().Be("2 Test Lane");
            job.Address3.Should().Be("3 Test Lane");
            job.City.Should().Be("Edinburgh");
            job.Region.Should().Be("East Lothian");
            job.Postcode.Should().Be("EH12 9DQ");
            job.Country.Should().Be("GB");
            job.Phone.Should().Be("0131 553 0400");
            job.Email.Should().Be("email@customer.com");
            job.AccountNumber.Should().Be("01234");
            job.AccountNumber2.Should().Be("56789");
            job.AutoEmail.Should().Be(true);
        }
    }
}
