using InsuranceTest.API.Business.Implementation;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.DTO.Client;
using InsuranceTest.API.DTO.RiskType;
using InsuranceTest.API.DTO.User;
using Moq;
using System;
using Xunit;

namespace XUnitTestInsuranceTest
{
    public class UserTest
    {

        [Fact]
        public void CanRegister_UserRegister_ReturnTrue()
        {
            var mock = new Mock<IInsuranceBL>();

            //Act
            mock.Setup(m => m.IsInsuranceHighRiskValidated(4, 40)).Returns(true);
            //IInsuranceBL insuranceBL = mock.Object; 
            IInsuranceBL insuranceBL = mock.Object;
            //bool result = mock.Object.IsInsuranceHighRiskValidated(4, 40);
            var result = insuranceBL.IsInsuranceHighRiskValidated(4,60);

            //Assert
            Assert.True(result);
        }
    }
}
