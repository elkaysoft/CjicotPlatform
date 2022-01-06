using Cjicot.Presentation.Utility;
using Xunit;

namespace Cjicot.Tests
{
    public class UtilityTests
    {
        [Fact]
        //[InlineData("", "")]
        public void Can_EncryptPassword()
        {
            //Arrange
            string expectedValue = "e42cbcd911523ed77ff787b9034f4575e8263b01b0b0e85f9b23a3a0282a5ae4";

            //Act
            string actual = helper.EncryptPassword("Olamilekan");
            
            //Assert
            Assert.Equal(expectedValue, actual);
        }
    }
}
