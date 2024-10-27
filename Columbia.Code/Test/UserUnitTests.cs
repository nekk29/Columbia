using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using $safesolutionname$.Application.Abstractions;
using $safesolutionname$.Dto.Base;
using $safesolutionname$.Dto.User;

namespace $safesolutionname$.Test
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
