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
    public class PodTests
    {
        [TestMethod]
        public void Pod_Deserialization_ShouldHaveExpectedValues()
        {
            var pod = JsonConvert.DeserializeObject<Pod>(File.ReadAllText("samplepod.json"));
            pod.Id.Should().Be(1);
            pod.CosmeticId.Should().Be(2);
            pod.Job.Should().Be(3);
            pod.Customer.Should().Be(4);
            pod.Site.Should().Be(5);
            pod.Depot.Should().Be(6);
            pod.Driver.Should().Be(7);
            pod.Run.Should().Be(8);
            pod.Date.Should().Be(Convert.ToDateTime("2019-01-01T00:00:00+00:00"));
            pod.Template.Should().Be(9);
            pod.PodFields.FirstOrDefault().Id.Should().Be(123);
            pod.PodFields.FirstOrDefault().FieldId.Should().Be(234);
            pod.PodFields.FirstOrDefault().Value.Should().Be("Test Value");
            pod.PodItems.PodData.FirstOrDefault().Id.Should().Be(12345);
            pod.PodItems.PodData.FirstOrDefault().PodDataFieldData.FirstOrDefault().FieldName.Should().Be("Field Name");
            pod.PodItems.PodData.FirstOrDefault().PodDataFieldData.FirstOrDefault().FieldValue.Should().Be("Field Value");
        }
    }
}
