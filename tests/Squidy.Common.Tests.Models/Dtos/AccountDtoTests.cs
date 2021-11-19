using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squidy.Common.Data.Entities;
using Squidy.Common.Models.Dtos;
using Squidy.Common.Models.Enums;
using Squidy.Service.Business.Extensions;
using System;

namespace Squidy.Common.Tests.Models.Dtos
{
    [TestClass]
    public class AccountDtoTests
    {
        [TestMethod]
        [DataRow("Test Account Title", true)]
        [DataRow("Test Account Title", false)]
        [DataRow("", true)]
        [DataRow("", false)]
        [DataRow(null, true)]
        public void HydrateFromEntity_EmptyReferenceTypes(string expectedTitle, bool expectedExpiredFlag)
        {
            var expectedId = Guid.NewGuid();
            var expectedCreatedDate = DateTime.Now.AddDays(-2);
            var expectedUpdatedDate = DateTime.Now.AddDays(-1);

            var accountTypeEntity = new AccountType();
            var userEntity = new User();

            var entity = CreateAccountEntity(expectedId, expectedTitle, accountTypeEntity, userEntity,
                                             expectedExpiredFlag, expectedCreatedDate, expectedUpdatedDate);

            var dto = new AccountDto();
            dto.HydrateFromEntity(entity);

            Assert.AreEqual(expectedExpiredFlag, dto.IsExpired);
            Assert.AreEqual(expectedTitle, dto.Title);
            Assert.AreEqual(expectedId, dto.Id);
            Assert.AreEqual(expectedCreatedDate, dto.CreatedDate);
            Assert.AreEqual(expectedUpdatedDate, dto.UpdatedDate);
            Assert.IsNotNull(dto.AccountType);
            Assert.IsNotNull(dto.User);
        }

        //[TestMethod]
        //public void HydrateFromEntity_SubscriptionPlan()
        //{
        //    var expectedCreatedDate = DateTime.Now.AddDays(-2);
        //    var expectedUpdatedDate = DateTime.Now.AddDays(-1);

        //    var (planEntity, expectedPlan) = CreateSubscriptionPlan(Guid.NewGuid(), expectedCreatedDate, expectedUpdatedDate);

        //    var expectedId = Guid.NewGuid();
        //    var expectedName = "Test Account Type Name";
        //    var expectedDescription = "Test Account Type Description";
        //    var expectedActiveFlag = true;

        //    var entity = CreateAccountEntity(expectedId, expectedName, expectedDescription, planEntity,
        //                                         expectedActiveFlag, expectedCreatedDate, expectedUpdatedDate);

        //    var dto = new AccountTypeDto();
        //    dto.HydrateFromEntity(entity);

        //    Assert.AreEqual(expectedDescription, dto.Description);
        //    Assert.AreEqual(expectedActiveFlag, dto.IsActive);
        //    Assert.AreEqual(expectedName, dto.Name);
        //    Assert.AreEqual(expectedId, dto.Id);
        //    Assert.AreEqual(expectedCreatedDate, dto.CreatedDate);
        //    Assert.AreEqual(expectedUpdatedDate, dto.UpdatedDate);

        //    Assert.IsNotNull(dto.SubscriptionPlan);
        //    Assert.IsTrue(ComparePlanDetails(expectedPlan, dto.SubscriptionPlan));
        //}

        private Account CreateAccountEntity(Guid id, string title, AccountType accountType, User user,
                                                bool isExpired, DateTime createdDate, DateTime updatedDate)
        {
            return new Account
            {
                Id = id,
                Title = title,
                AccountType = accountType,
                User = user,
                IsExpired = isExpired,
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
