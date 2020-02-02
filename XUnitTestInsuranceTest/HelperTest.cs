using InsuranceTest.API.Helper;
using Xunit;

namespace XUnitTestInsuranceTest
{
    public class HelperTest
    {

        [Fact] 
        public void HighRiskValidation_InsuranceValidation_ReturnTrue()
        {
            InsuranceValidations _insuranceValidation = new InsuranceValidations();

            //Act
            var result = _insuranceValidation.IsInsuranceHighRiskValidated(4, 50);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void HighRiskValidation_InsuranceValidation_ReturnFalse()
        {
            InsuranceValidations _insuranceValidation = new InsuranceValidations();

            //Act
            var result = _insuranceValidation.IsInsuranceHighRiskValidated(4, 60);

            //Assert
            Assert.False(result);
        }
    }
}
