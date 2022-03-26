using ApplicationAvansSOA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
            // Member 1 as scrum master            
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
            // Member 1 as Product Owner            
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
            Backlog backlog = new Backlog("1. Backlog", "Test code");
            BacklogItem backlogItem = new BacklogItem("Testing code", "Testing all the code");

            // Act
            backlogItem.SetIsDone(true);
            backlog.AddBacklogItem(backlogItem);

            sprint.SetBacklog(backlog);

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
        // TC-S6: Wanneer de sprint gereleased en afgesloten is wordt er een melding gestuurd naar de scrum master en product owner.
        public void TestTCS6()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");
            Backlog backlog = new Backlog("1. Backlog", "Test code");
            BacklogItem backlogItem = new BacklogItem("Testing code", "Testing all the code");

            // Act
            backlogItem.SetIsDone(true);
            backlog.AddBacklogItem(backlogItem);

            sprint.SetBacklog(backlog);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            sprint.GenerateRapport("Rapport 1");
            
            // String doet raar in gitactions pipeline?
            string expectedResult = "Verzend email: Sprint is gesloten. En Pipeline wordt gestart!De source code wordt opgehaald.\nDe packages worden op dit moment geinstalleerd.\nDe software wordt gebuild. Maakt connectie met andere verschillende builds.\nDe code wordt getest met alle beschikbaar testen.\nDe code wordt geanalyseerd door SonarCloud.\nDe code wordt gedeployed op de gewenste omgeving.\nOverige commands worden uitgevoerd. De pipeline is succesvol voltooid!";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-S7: De scrum master kan een sprint review afsluiten door een samenvatting van de review voor de sprint als document up te loaden.
        public void TestTCS7()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");
            Backlog backlog = new Backlog("1. Backlog", "Test code");
            BacklogItem backlogItem = new BacklogItem("Testing code", "Testing all the code");

            // Act
            backlogItem.SetIsDone(true);
            backlog.AddBacklogItem(backlogItem);

            sprint.SetBacklog(backlog);

            sprint.GenerateRapport("Rapport 1");
            SprintStatus expectedResult = SprintStatus.Finished;

            // Assert
            Assert.AreEqual(expectedResult, sprint.GetSprintStatus());
        }

        [TestMethod]
        // TC-S8: Voor een sprint kan er een rapportage worden gegenereerd.
        public void TestTCS8()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");

            // Act
            Rapport newRapport = sprint.GenerateRapport("Rapport 1");
            Rapport expectedResult = new Rapport("Rapport 1", sprint);

            // Assert
            Assert.AreEqual(expectedResult.GetName(), newRapport.GetName());
        }

        [TestMethod]
        // TC-S9: Een sprint moet gekoppeld kunnen worden aan verschillende personen & als iemand gekoppeld wordt binnen een sprint moet
        // er rollen toegewijd kunnen worden.
        public void TestTCS9()
        {
            // Arrange
            Sprint sprint = new Sprint("SprintTest");

            MemberFactory factory = new MemberFactory();

            // Member 1 as Developer            
            IMember userOne = factory.GetMember("developer");

            // Member 2 as Product Owner            
            IMember userTwo = factory.GetMember("product owner");

            // Member 3 as Scrum Master         
            IMember userThree = factory.GetMember("scrum master");

            // Act
            sprint.AddMember(userOne);
            userOne.SetRole("developer");

            sprint.AddMember(userTwo);
            userTwo.SetRole("product owner");

            sprint.AddMember(userThree);
            userThree.SetRole("scrum master");

            int expectedResult = 3;
            string expectedUserOneRole = "developer";
            string expectedUserTwoRole = "product owner";
            string expectedUserThreeRole = "scrum master";

            // Assert
            Assert.AreEqual(expectedResult, sprint.GetMembers().Count);
            Assert.AreEqual(expectedUserOneRole, sprint.GetMembers()[0].GetRole());
            Assert.AreEqual(expectedUserTwoRole, sprint.GetMembers()[1].GetRole());
            Assert.AreEqual(expectedUserThreeRole, sprint.GetMembers()[2].GetRole());
        }
    }
}