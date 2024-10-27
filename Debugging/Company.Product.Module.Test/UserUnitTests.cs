using System;
using System.Threading.Tasks;
using Company.Product.Module.Application.Abstractions;
using Company.Product.Module.Dto.Base;
using Company.Product.Module.Dto.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Company.Product.Module.Test
{
    [TestClass]
    public class UserUnitTests
    {
        [TestMethod]
        public async Task LoginUserSuccess()
        {
            var userApplicationMock = new Mock<IUserApplication>();
            var loginDto = new LoginDto
            {
                UserName = "mockUserName",
                Password = "mockPassword",
                RememberMe = true
            };

            userApplicationMock
                .Setup(m => m.Login(loginDto))
                .Returns(async () =>
                {
                    var result = new ResponseDto<LoginResultDto>
                    {
                        Data = new LoginResultDto
                        {

                        }
                    };

                    return await Task.FromResult(result);
                });

            var loginResultDto = await userApplicationMock.Object.Login(loginDto);

            Assert.IsNotNull(loginResultDto?.Data);
        }

        [TestMethod]
        public async Task LoginUserError()
        {
            var error = "Connection error";

            try
            {
                var userApplicationMock = new Mock<IUserApplication>();
                var loginDto = new LoginDto
                {
                    UserName = "mockUserName",
                    Password = "mockPassword",
                    RememberMe = true
                };

                userApplicationMock
                    .Setup(m => m.Login(loginDto))
                    .Returns(async () =>
                    {
                        await Task.CompletedTask;
                        throw new Exception(error);
                    });

                _ = await userApplicationMock.Object.Login(loginDto);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, error);
            }
        }
    }
}
