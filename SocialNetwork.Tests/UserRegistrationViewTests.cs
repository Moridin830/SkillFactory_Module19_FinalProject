using System;
using NUnit.Framework;
using Moq;

namespace SocialNetwork.Tests
    
{
    [TestFixture]
    public class UserRegistrationViewTests
    {
        [Test]
        public void UserRegistrationMustNotReturnException()
        {
            var testRegistrationData = TestRegistrationData();
            var testUserEntity = TestUserEntity(testRegistrationData);
            var mockUserRepository = new Mock<DAL.Repositories.IUserRepository>();
            mockUserRepository.Setup(r => r.Create(It.IsAny<DAL.Entities.UserEntity>())).Returns(100500);

            var userService = new BLL.Services.UserService(mockUserRepository.Object);
            

            Assert.DoesNotThrow(delegate { userService.Register(testRegistrationData); });
        }

        private DAL.Entities.UserEntity TestUserEntity(BLL.Models.UserRegistrationData userRegistrationData)
        {
            DAL.Entities.UserEntity user = new DAL.Entities.UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            return user;
        }
        private BLL.Models.UserRegistrationData TestRegistrationData()
        {
            var registrationData = new BLL.Models.UserRegistrationData();
            registrationData.FirstName = "firstName";
            registrationData.LastName = "lastName";
            registrationData.Password = "userPassword";
            registrationData.Email = "test@mail.ru";

            return registrationData;
        }
    }
}