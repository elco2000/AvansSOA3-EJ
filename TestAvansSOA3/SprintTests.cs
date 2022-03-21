using ApplicationAvansSOA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAvansSOA3
{
    [TestClass]
    public class SprintTests
    {
        [TestMethod]
        // TC-S4: Als een sprint afgelopen is krijgt de sprint de status ‘finished’.
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

        [TestMethod]
        // TC-S5: Een sprint is niet aanpasbaar gedurende de pipeline bezig is.
        public void TestTCS5()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");

            // Act
            sprint.SetIsInPipeline(true);
            sprint.SetName("TestName");
            string expectedResult = "SprintTest";

            // Assert
            Assert.AreEqual(expectedResult, sprint.GetName());
        }


    }
}