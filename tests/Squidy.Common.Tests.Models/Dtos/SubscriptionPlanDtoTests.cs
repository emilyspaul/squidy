using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squidy.Common.Data.Entities;
using Squidy.Common.Models.Dtos;
using Squidy.Common.Models.Enums;
using Squidy.Service.Business.Extensions;
using System;

namespace Squidy.Common.Tests.Models.Dtos
{
    [TestClass]
    public class SubscriptionPlanDtoTests
    {
        [TestMethod]
        [DataRow("Test Plan Name", "Test Plan Description", 10)]
        [DataRow("", "Test Plan Description", 10)]
        [DataRow("", "", 10)]
        [DataRow("", "", -1)]
        [DataRow(null, "Test Plan Description", 10)]
        [DataRow(null, null, 10)]
        public void HydrateFromEntity(string expectedName, string expectedDescription, int expectedAmount)
        {
            var expectedId = Guid.NewGuid();
            var expectedFrequency = PlanFrequency.Monthly;
            var expectedCreatedDate = DateTime.Now.AddDays(-2);
            var expectedUpdatedDate = DateTime.Now.AddDays(-1);

            var entity = CreatePlanEntity(expectedId, expectedName, expectedDescription, expectedAmount, 
                                          expectedCreatedDate, expectedUpdatedDate, expectedFrequency);

            var dto = new SubscriptionPlanDto();
            dto.HydrateFromEntity(entity);

            Assert.AreEqual(expectedAmount, dto.Amount);
            Assert.AreEqual(expectedDescription, dto.Description);
            Assert.AreEqual(expectedFrequency, dto.Frequency);
            Assert.AreEqual(expectedName, dto.Name);
            Assert.AreEqual(expectedId, dto.Id);
            Assert.AreEqual(expectedCreatedDate, dto.CreatedDate);
            Assert.AreEqual(expectedUpdatedDate, dto.UpdatedDate);
        }

        [TestMethod]
        public void HydrateFromEntity_NullFrequency()
        {
            var expectedId = Guid.NewGuid();
            var expectedName = "Test Plan Name";
            var expectedDescription = "Test Plan Description";
            var expectedAmount = 10;
            var expectedCreatedDate = DateTime.Now.AddDays(-2);
            var expectedUpdatedDate = DateTime.Now.AddDays(-1);

            var entity = CreatePlanEntity(expectedId, expectedName, expectedDescription, expectedAmount, 
                                          expectedCreatedDate, expectedUpdatedDate);

            var dto = new SubscriptionPlanDto();
            dto.HydrateFromEntity(entity);

            Assert.AreEqual(expectedAmount, dto.Amount);
            Assert.AreEqual(expectedDescription, dto.Description);
            Assert.AreEqual(PlanFrequency.Monthly, dto.Frequency);
            Assert.AreEqual(expectedName, dto.Name);
            Assert.AreEqual(expectedId, dto.Id);
            Assert.AreEqual(expectedCreatedDate, dto.CreatedDate);
            Assert.AreEqual(expectedUpdatedDate, dto.UpdatedDate);
        }

        private static SubscriptionPlan CreatePlanEntity(Guid id, string name, string description, int amount, 
                                                         DateTime createdDate, DateTime updatedDate, 
                                                         PlanFrequency frequency = PlanFrequency.None)
        {
            return new SubscriptionPlan()
            {
                Id = id,
                Amount = amount,
                Description = description,
                Frequency = frequency == PlanFrequency.None ? null : frequency.ToString(),
                Active = true,
                Name = name,
                CreatedDate = createdDate,
                UpdatedDate = updatedDate
            };
        }
    }
}
