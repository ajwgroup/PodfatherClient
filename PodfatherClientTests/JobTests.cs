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
            var job = JsonConvert.DeserializeObject<Jobs>(File.ReadAllText("samplejob.json"));
            job.Job.Id.Should().Be(534975555);
            job.Job.Deleted.Should().Be(false);
            job.Job.CosmeticId.Should().Be(87536);
            job.Job.Site.Should().Be(15067072);
            job.Job.Customer.Should().Be(832825);
            job.Job.Depot.Should().Be(39645);
            job.Job.Run.Should().Be(0);
            job.Job.Instructions1.Should().Be("Integration Test Please Ignore");
            job.Job.Instructions2.Should().Be("");
            job.Job.Provisional.Should().Be(false);
            job.Job.OrderRef.Should().Be("");
            job.Job.OrderRef2.Should().Be("");
            job.Job.DueByStart.Should().Be(null);
            job.Job.DueBy.Should().Be(Convert.ToDateTime("2020-12-06T10:32:30+00:00"));
            job.Job.DropTime.Should().Be(0);
            job.Job.Price.Should().Be(0.0);
            job.Job.CreatedAt.Should().Be(Convert.ToDateTime("2020-12-03T09:07:49+00:00"));
            job.Job.ReceivedByHandheld.Should().Be(null);
            job.Job.Template.Should().Be(1594);
        }

        [TestMethod]
        public void CreatedJob_Deserialization_ShouldHaveExpectedValues()
        {
            var obj = JsonConvert.DeserializeObject<CreatedJob>(File.ReadAllText("samplecreatedjob.json"));
            obj.Job.Job.Id.Should().BeGreaterThan(0);
            obj.Job.Job.Deleted.Should().Be(false);
            obj.Job.Job.CosmeticId.Should().Be(87451);
            obj.Job.Job.Site.Should().Be(15067072);
            obj.Job.Job.Customer.Should().Be(832825);
            obj.Job.Job.Depot.Should().Be(39645);
            obj.Job.Job.Run.Should().Be(0);
            obj.Job.Job.Instructions1.Should().Be("Integration Test Please Ignore");
            obj.Job.Job.Instructions2.Should().Be("");
            obj.Job.Job.Provisional.Should().Be(false);
            obj.Job.Job.OrderRef.Should().Be("");
            obj.Job.Job.OrderRef2.Should().Be("");
            obj.Job.Job.DueByStart.Should().Be(null);
            obj.Job.Job.DueBy.Should().Be(Convert.ToDateTime("2020-12-06T10:32:30+00:00"));
            obj.Job.Job.DropTime.Should().Be(0);
            obj.Job.Job.Price.Should().Be(0.0);
            obj.Job.Job.CreatedAt.Should().Be(Convert.ToDateTime("2020-11-26T10:33:22+00:00"));
            obj.Job.Job.ReceivedByHandheld.Should().Be(null);
            obj.Job.Job.Template.Should().Be(1594);

        }

        [TestMethod]
        public void CreatedJobWithFields_Deserialization_ShouldHaveExpectedValues()
        {
            var obj = JsonConvert.DeserializeObject<CreatedJob>(File.ReadAllText("samplecreatedjobwithfields.json"));
            obj.Job.Job.Id.Should().BeGreaterThan(0);
            obj.Job.Job.Deleted.Should().Be(false);
            obj.Job.Job.CosmeticId.Should().Be(87526);
            obj.Job.Job.Site.Should().Be(15067072);
            obj.Job.Job.Customer.Should().Be(832825);
            obj.Job.Job.Depot.Should().Be(39645);
            obj.Job.Job.Run.Should().Be(0);
            obj.Job.Job.Instructions1.Should().Be("Integration Test Please Ignore");
            obj.Job.Job.Instructions2.Should().Be("");
            obj.Job.Job.Provisional.Should().Be(false);
            obj.Job.Job.OrderRef.Should().Be("");
            obj.Job.Job.OrderRef2.Should().Be("");
            obj.Job.Job.DueByStart.Should().Be(null);
            obj.Job.Job.DueBy.Should().Be(Convert.ToDateTime("2020-12-12T04:00:37+00:00"));
            obj.Job.Job.DropTime.Should().Be(0);
            obj.Job.Job.Price.Should().Be(0.0);
            obj.Job.Job.CreatedAt.Should().Be(Convert.ToDateTime("2020-12-02T16:00:38+00:00"));
            obj.Job.Job.ReceivedByHandheld.Should().Be(null);
            obj.Job.Job.Template.Should().Be(1594);
            obj.JobFields.JobFieldsData.FirstOrDefault().FieldId.Should().Be(25506);

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
