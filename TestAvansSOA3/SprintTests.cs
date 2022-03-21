using ApplicationAvansSOA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAvansSOA3
{
    [TestClass]
    public class SprintTests
    {
        [TestMethod]
        // TC-S4: Als een sprint afgelopen is krijgt de sprint de status �finished�.
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

        [TestMethod]
        // TC-S9: De scrum master kan een sprint review afsluiten door een samenvatting van de review voor de sprint als document up te loaden.
        public void TestTCS9()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");

            // Act
            sprint.GenerateRapport("Rapport 1");
            SprintStatus expectedResult = SprintStatus.Finished;

            // Assert
            Assert.AreEqual(expectedResult, sprint.GetSprintStatus());
        }

        [TestMethod]
        // TC-S10: Voor een sprint kan er een rapportage worden gegenereerd.
        public void TestTCS10()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");

            // Act
            Rapport newRapport = sprint.GenerateRapport("Rapport 1");
            Rapport expectedResult = new Rapport("Rapport 1");

            // Assert
            Assert.AreEqual(expectedResult.GetName(), newRapport.GetName());
        }
    }
}