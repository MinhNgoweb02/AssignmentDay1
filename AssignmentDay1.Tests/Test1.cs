using AssignmentDay1;

namespace AssignmentDay1.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void GetCarType_ShouldReturnCar_WhenWheelsAreFour()
        {
            // Arrange
            var carType = new CarType();
            
            // Act
            var result = carType.GetCarType(4);
            
            // Assert
            Assert.AreEqual("Car", result);
        }
    }
}
