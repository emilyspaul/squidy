using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squidy.Common.Data.Entities;
using Squidy.Common.Models.Dtos;
using Squidy.Common.Models.Enums;
using Squidy.Service.Business.Extensions;
using System;

namespace Squidy.Common.Tests.Models.Dtos
{
    [TestClass]
    public class AccountTypeDtoTests
    {
        [TestMethod]
        [DataRow("Test Account Name", "Test Account Description", true)]
        [DataRow("Test Account Name", "Test Account Description", false)]
        [DataRow("", "Test Account Description", true)]
        [DataRow("", "Test Account Description", false)]
        [DataRow("", "", true)]
        [DataRow("", "", false)]
        [DataRow(null, "Test Account Description", true)]
        [DataRow(null, null, true)]
        public void HydrateFromEntity_EmptySubscriptionPlan(string expectedName, string expectedDescription, 
                                                            bool expectedActiveFlag)
        {
            var expectedId = Guid.NewGuid();
            var expectedCreatedDate = DateTime.Now.AddDays(-2);
            var expectedUpdatedDate = DateTime.Now.AddDays(-1);

            var planEntity = new SubscriptionPlan();

            var entity = CreateAccountTypeEntity(expectedId, expectedName, expectedDescription, planEntity,
                                                 expectedActiveFlag, expectedCreatedDate, expectedUpdatedDate);

            var dto = new AccountTypeDto();
            dto.HydrateFromEntity(entity);

            Assert.AreEqual(expectedDescription, dto.Description);
            Assert.AreEqual(expectedActiveFlag, dto.IsActive);
            Assert.AreEqual(expectedName, dto.Name);
            Assert.AreEqual(expectedId, dto.Id);
            Assert.AreEqual(expectedCreatedDate, dto.CreatedDate);
            Assert.AreEqual(expectedUpdatedDate, dto.UpdatedDate);
            Assert.IsNotNull(dto.SubscriptionPlan);
        }

        [TestMethod]
        public void HydrateFromEntity_SubscriptionPlan()
        {
            var expectedCreatedDate = DateTime.Now.AddDays(-2);
            var expectedUpdatedDate = DateTime.Now.AddDays(-1);

            var (planEntity, expectedPlan) = CreateSubscriptionPlan(Guid.NewGuid(), expectedCreatedDate, expectedUpdatedDate);

            var expectedId = Guid.NewGuid();
            var expectedName = "Test Account Type Name";
            var expectedDescription = "Test Account Type Description";
            var expectedActiveFlag = true;

            var entity = CreateAccountTypeEntity(expectedId, expectedName, expectedDescription, planEntity,
                                                 expectedActiveFlag, expectedCreatedDate, expectedUpdatedDate);

            var dto = new AccountTypeDto();
            dto.HydrateFromEntity(entity);

            Assert.AreEqual(expectedDescription, dto.Description);
            Assert.AreEqual(expectedActiveFlag, dto.IsActive);
            Assert.AreEqual(expectedName, dto.Name);
            Assert.AreEqual(expectedId, dto.Id);
            Assert.AreEqual(expectedCreatedDate, dto.CreatedDate);
            Assert.AreEqual(expectedUpdatedDate, dto.UpdatedDate);

            Assert.IsNotNull(dto.SubscriptionPlan);
            Assert.IsTrue(ComparePlanDetails(expectedPlan, dto.SubscriptionPlan));
        }

        private AccountType CreateAccountTypeEntity(Guid id, string name, string description, 
                                                    SubscriptionPlan subscriptionPlan, bool isActive,
                                                    DateTime createdDate, DateTime updatedDate)
        {
            return new AccountType
            {
                Id = id,
                Name = name,
                Description = description,
                SubscriptionPlan = subscriptionPlan,
                IsActive = isActive,
                CreatedDate = createdDate,
                UpdatedDate = updatedDate
            };
        }

        private (SubscriptionPlan, SubscriptionPlanDto) CreateSubscriptionPlan(Guid id, DateTime createdDate, DateTime updatedDate,
            string name = "plan-name", string description = "plan-description", int amount = 10, 
            PlanFrequency frequency = PlanFrequency.None)
        {
            var planEntity = new SubscriptionPlan
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

            var planDto = new SubscriptionPlanDto();
            planDto.HydrateFromEntity(planEntity);

            return (planEntity, planDto);
        }

        private bool ComparePlanDetails(SubscriptionPlanDto expectedPlan, SubscriptionPlanDto actualPlan)
        {
            return (expectedPlan.Id == actualPlan.Id) && (expectedPlan.Amount == actualPlan.Amount)
                    && (expectedPlan.Name == actualPlan.Name) && (expectedPlan.Description == actualPlan.Description)
                    && (expectedPlan.Frequency == actualPlan.Frequency) && (expectedPlan.CreatedDate == actualPlan.CreatedDate)
                    && (expectedPlan.UpdatedDate == actualPlan.UpdatedDate);
        }
    }
}
