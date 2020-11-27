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
    public class JobTests
    {
        [TestMethod]
        public void Job_Deserialization_ShouldHaveExpectedValues()
        {
            var job = JsonConvert.DeserializeObject<Job>(File.ReadAllText("samplejob.json"));
            job.Id.Should().Be(90000);
            job.Deleted.Should().Be(false);
            job.CosmeticId.Should().Be(10293);
            job.Site.Should().Be(76534);
            job.Customer.Should().Be(89354);
            job.Depot.Should().Be(9543);
            job.Run.Should().Be(241);
            job.Instructions1.Should().Be("Use the front entrance.");
            job.Instructions2.Should().Be("Beware of the cat.");
            job.Provisional.Should().Be(false);
            job.OrderRef.Should().Be("Order Reference");
            job.OrderRef2.Should().Be("Order Reference 2");
            job.DueByStart.Should().Be(Convert.ToDateTime("2018-01-01T00:00:00+00:00"));
            job.DueBy.Should().Be(Convert.ToDateTime("2018-01-01T00:00:00+00:00"));
            job.DropTime.Should().Be(5);
            job.Price.Should().Be(10.22);
            job.CreatedAt.Should().Be(Convert.ToDateTime("2018-01-01T00:00:00+00:00"));
            job.ReceivedByHandheld.Should().Be(Convert.ToDateTime("2018-01-01T00:00:00+00:00"));
            job.Template.Should().Be(5);
            job.JobFields.JobFieldsData.FirstOrDefault().Id.Should().Be(123);
            job.JobFields.JobFieldsData.FirstOrDefault().FieldId.Should().Be(234);
            job.JobFields.JobFieldsData.FirstOrDefault().Name.Should().Be("Test Name");
            job.JobFields.JobFieldsData.FirstOrDefault().Value.Should().Be("Test Value");
            job.JobItems.JobItemsData.FirstOrDefault().Id.Should().Be(123);
            job.JobItems.JobItemsData.FirstOrDefault().Name.Should().Be("Box");
            job.JobItems.JobItemsData.FirstOrDefault().MerchGroup.Should().Be("Bags");
            job.JobItems.JobItemsData.FirstOrDefault().ProductCode.Should().Be("PROD001");
            job.JobItems.JobItemsData.FirstOrDefault().Price.Should().Be(10.22);
            job.JobItems.JobItemsData.FirstOrDefault().Weight.Should().Be(11.55);
            job.JobItems.JobItemsData.FirstOrDefault().Quantity.Should().Be(5);
        }

        [TestMethod]
        public void CreatedJob_Deserialization_ShouldHaveExpectedValues()
        {
            var obj = JsonConvert.DeserializeObject<CreatedJob>(File.ReadAllText("samplecreatedjob.json"));
            obj.JobContainer.Job.Id.Should().BeGreaterThan(0);
            obj.JobContainer.Job.Deleted.Should().Be(false);
            obj.JobContainer.Job.CosmeticId.Should().Be(87451);
            obj.JobContainer.Job.Site.Should().Be(15067072);
            obj.JobContainer.Job.Customer.Should().Be(832825);
            obj.JobContainer.Job.Depot.Should().Be(39645);
            obj.JobContainer.Job.Run.Should().Be(0);
            obj.JobContainer.Job.Instructions1.Should().Be("Integration Test Please Ignore");
            obj.JobContainer.Job.Instructions2.Should().Be("");
            obj.JobContainer.Job.Provisional.Should().Be(false);
            obj.JobContainer.Job.OrderRef.Should().Be("");
            obj.JobContainer.Job.OrderRef2.Should().Be("");
            obj.JobContainer.Job.DueByStart.Should().Be(null);
            obj.JobContainer.Job.DueBy.Should().Be(Convert.ToDateTime("2020-12-06T10:32:30+00:00"));
            obj.JobContainer.Job.DropTime.Should().Be(0);
            obj.JobContainer.Job.Price.Should().Be(0.0);
            obj.JobContainer.Job.CreatedAt.Should().Be(Convert.ToDateTime("2020-11-26T10:33:22+00:00"));
            obj.JobContainer.Job.ReceivedByHandheld.Should().Be(null);
            obj.JobContainer.Job.Template.Should().Be(1594);

        }

        [TestMethod]
        public void Job_Deserialization_ShouldHaveExpectedValues2()
        {
            var job = JsonConvert.DeserializeObject<NewJob>(File.ReadAllText("samplenewjob.json"));
            job.Site.Should().Be(76534);
            job.Customer.Should().Be(89354);
            job.Depot.Should().Be(9543);
            job.Template.Should().Be(123);
            job.Run.Should().Be(241);
            job.DueByStart.Should().Be(Convert.ToDateTime("2018-01-01T00:00:00+00:00"));
            job.DueBy.Should().Be(Convert.ToDateTime("2018-01-01T00:00:00+00:00"));
            job.Instructions1.Should().Be("Knock front door");
            job.Instructions2.Should().Be("Knock side door");
            job.Provisional.Should().Be(true);
            job.DropTime.Should().Be(5);
            job.Price.Should().Be(10.22);
            job.Items.FirstOrDefault().Name.Should().Be("Box");
            job.Items.FirstOrDefault().MerchGroup.Should().Be("Bags");
            job.Items.FirstOrDefault().ProductCode.Should().Be("PROD001");
            job.Items.FirstOrDefault().Price.Should().Be(10.22);
            job.Items.FirstOrDefault().Weight.Should().Be(11.55);
            job.Items.FirstOrDefault().Quantity.Should().Be(5);
        }
    }
}
