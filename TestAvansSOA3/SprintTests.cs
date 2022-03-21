using ApplicationAvansSOA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAvansSOA3
{
    [TestClass]
    public class SprintTests
    {
        [TestMethod]
        public void TestTCS4()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");

            // Act
            sprint.CloseSprint();
            SprintStatus expectedResult = SprintStatus.Finished;

            // Assert
            Assert.AreEqual(expectedResult, sprint.GetSprintStatus());
        }
    }
}