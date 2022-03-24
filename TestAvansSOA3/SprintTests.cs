using ApplicationAvansSOA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAvansSOA3
{
    [TestClass]
    public class SprintTests
    {
        [TestMethod]
        // TC-S1: Als iemand gekoppeld wordt binnen een sprint moet er rollen toe gewijzigd kunnen worden, zoals developers, scrum master en
        // product owner op projectniveau
        public void TestTCS1()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");
            // Member 1 as Developer            
            MemberFactory factory = new MemberFactory();
            IMember developer = factory.GetMember("developer");
            


            // Act
            sprint.AddMember(developer);

            developer.SetRole("developer");
            developer.SetName("Piet");

            int expectedResult = 1;
            string expectedRole = "developer";
            string expectedName = "Piet";

            // Assert
            Assert.AreEqual(expectedResult, sprint.GetMembers().Count);
            Assert.IsInstanceOfType(sprint.GetMembers()[0], typeof(IMember));
            Assert.AreEqual(expectedRole, sprint.GetMembers()[0].GetRole());
            Assert.AreEqual(expectedName, sprint.GetMembers()[0].GetName());
        }

        [TestMethod]
        // TC-S2: Als iemand gekoppeld wordt binnen een sprint moet er rollen toe gewijzigd kunnen worden, zoals developers, scrum master en
        // product owner op projectniveau
        public void TestTCS2()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");
            // Member 1 as Developer            
            MemberFactory factory = new MemberFactory();
            IMember scrumMaster = factory.GetMember("scrum master");

            // Act
            sprint.AddMember(scrumMaster);

            scrumMaster.SetRole("scrum master");
            scrumMaster.SetName("Freek");

            int expectedResult = 1;

            string expectedRole = "scrum master";
            string expectedName = "Freek";

            // Assert
            Assert.AreEqual(expectedResult, sprint.GetMembers().Count);
            Assert.IsInstanceOfType(sprint.GetMembers()[0], typeof(IMember));
            Assert.AreEqual(expectedRole, sprint.GetMembers()[0].GetRole());
            Assert.AreEqual(expectedName, sprint.GetMembers()[0].GetName());
        }

        [TestMethod]
        // TC-S3: Als iemand gekoppeld wordt binnen een sprint moet er rollen toe gewijzigd kunnen worden, zoals developers, scrum master en
        // product owner op projectniveau
        public void TestTCS3()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");
            // Member 1 as Developer            
            MemberFactory factory = new MemberFactory();
            IMember productOwner = factory.GetMember("product owner");

            // Act
            sprint.AddMember(productOwner);

            productOwner.SetRole("product owner");
            productOwner.SetName("Julia");

            int expectedResult = 1;

            string expectedRole = "product owner";
            string expectedName = "Julia";

            // Assert
            Assert.AreEqual(expectedResult, sprint.GetMembers().Count);
            Assert.IsInstanceOfType(sprint.GetMembers()[0], typeof(IMember));
            Assert.AreEqual(expectedRole, sprint.GetMembers()[0].GetRole());
            Assert.AreEqual(expectedName, sprint.GetMembers()[0].GetName());
        }


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
            Rapport expectedResult = new Rapport("Rapport 1", sprint);

            // Assert
            Assert.AreEqual(expectedResult.GetName(), newRapport.GetName());
        }
    }
}