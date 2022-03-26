using ApplicationAvansSOA3;
using ApplicationAvansSOA3.AdapterNotification;
using ApplicationAvansSOA3.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace TestAvansSOA3
{
    [TestClass]
    public class BacklogTests
    {
        [TestMethod]
        // TC-BL1: De backlog is een geordende lijst met backlog items.
        public void TestTCBL1()
        {
            // Arrange
            Backlog backlog = new Backlog("TitleTest", "Description uitleg.");
            BacklogItem backlogItemOne = new BacklogItem("1. BacklogItem", "Doing some code");
            BacklogItem backlogItemTwo = new BacklogItem("2. BacklogItem", "Doing some testing");

            // Act
            backlog.AddBacklogItem(backlogItemOne);
            backlog.AddBacklogItem(backlogItemTwo);
            string expectedResult = "1. BacklogItem";

            // Assert
            Assert.AreEqual(expectedResult, backlog.getBacklogItems().Values[0].GetTitle());
        }

        [TestMethod]
        // TC-BL2: Maximaal één developer kan gekoppeld zijn aan een backlog item.
        public void TestTCBL2()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");
                
            MemberFactory factory = new MemberFactory();
            IMember developer = factory.GetMember("developer");

            // Act
            developer.SetRole("developer");

            backlogItem.AddMember(developer);

            string expectedResult = "developer";

            // Assert
            Assert.AreEqual(expectedResult, backlogItem.GetMember().GetRole());
        }

        [TestMethod]
        // TC-BL3: Maximaal één developer kan gekoppeld zijn aan een backlog item.
        public void TestTCBL3()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            MemberFactory factory = new MemberFactory();
            IMember developerOne = factory.GetMember("developer");
            IMember developerTwo = factory.GetMember("developer");

            // Act
            developerOne.SetRole("developer");
            developerOne.SetName("Piet");

            developerTwo.SetRole("developer");
            developerTwo.SetName("Freek");

            backlogItem.AddMember(developerOne);
            backlogItem.AddMember(developerTwo);

            string expectedResult = "Piet";

            // Assert
            Assert.AreEqual(expectedResult, backlogItem.GetMember().GetName());
        }

        [TestMethod]
        // TC-BL4: Maximaal één developer kan gekoppeld zijn aan een backlog item.
        public void TestTCBL4()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            MemberFactory factory = new MemberFactory();
            IMember scrumMaster = factory.GetMember("scrum master");

            // Act
            scrumMaster.SetRole("scrum master");

            backlogItem.AddMember(scrumMaster);

            // Assert
            Assert.AreEqual(null, backlogItem.GetMember());
        }

        [TestMethod]
        // TC-BL5: Developer kan verwijderd worden uit een backlog item.
        public void TestTCBL5()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            MemberFactory factory = new MemberFactory();
            IMember developer = factory.GetMember("developer");

            // Act
            developer.SetRole("developer");

            backlogItem.AddMember(developer);
            backlogItem.RemoveMember();


            // Assert
            Assert.AreEqual(null, backlogItem.GetMember());
        }

        [TestMethod]
        //TC-BL6: Meerdere developers kunnen gekoppeld worden aan het activiteit.
        public void TestTCBL6()
        {
            // Arrange
            Activity activity = new Activity("Code Smells remove", "Doing some code");

            MemberFactory factory = new MemberFactory();
            IMember memberOne = factory.GetMember("developer");
            IMember memberTwo = factory.GetMember("developer");

            // Act
            memberOne.SetRole("developer");
            memberTwo.SetRole("developer");

            activity.AddMember(memberOne);
            activity.AddMember(memberTwo);

            int expectedResult = 2;

            // Assert
            Assert.AreEqual(expectedResult, activity.GetMembers().Count);
        }

        [TestMethod]
        // TC-BL7: Meerdere developers kunnen gekoppeld worden aan het activiteit.
        public void TestTCBL7()
        {
            // Arrange
            Activity activity = new Activity("Code Smells remove", "Doing some code");

            MemberFactory factory = new MemberFactory();
            IMember memberOne = factory.GetMember("scrum master");
            IMember memberTwo = factory.GetMember("developer");

            // Act
            memberOne.SetRole("scrum master");
            memberTwo.SetRole("developer");

            activity.AddMember(memberOne);
            activity.AddMember(memberTwo);

            int expectedResult = 1;

            // Assert
            Assert.AreEqual(expectedResult, activity.GetMembers().Count);
        }

        [TestMethod]
        // TC-BL8: Een fase bevat minimaal todo, doing, ready for testing, tested en done.
        public void TestTCBL8()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.BacklogItemDoing();
            DoingState doingState = new DoingState(backlogItem);

            // Assert
            Assert.AreEqual(backlogItem.GetState().GetType(), doingState.GetType());
        }

        [TestMethod]
        // TC-BL9: Een fase bevat minimaal todo, doing, ready for testing, tested en done.
        public void TestTCBL9()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.BacklogItemDoing();
            backlogItem.BacklogItemReadyForTesting();
            ReadyForTestingState readyForTestingState = new ReadyForTestingState(backlogItem);

            // Assert
            Assert.AreEqual(backlogItem.GetState().GetType(), readyForTestingState.GetType());
        }

        [TestMethod]
        // TC-BL10: Een fase bevat minimaal todo, doing, ready for testing, tested en done.
        public void TestTCBL10()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.BacklogItemDoing();
            backlogItem.BacklogItemReadyForTesting();
            backlogItem.BacklogItemTested();
            TestedState testedState = new TestedState(backlogItem);

            // Assert
            Assert.AreEqual(backlogItem.GetState().GetType(), testedState.GetType());
        }

        [TestMethod]
        // TC-BL11: Een fase bevat minimaal todo, doing, ready for testing, tested en done.
        public void TestTCBL11()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            MemberFactory factory = new MemberFactory();
            IMember memberOne = factory.GetMember("developer");

            // Act
            backlogItem.CloseBacklogItem();

            memberOne.SetRole("developer");
            backlogItem.AddMember(memberOne);

            backlogItem.BacklogItemDoing();
            backlogItem.BacklogItemReadyForTesting();
            backlogItem.BacklogItemTested();
            backlogItem.BacklogDone();
            DoneState doneState = new DoneState(backlogItem);

            // Assert
            Assert.AreEqual(doneState.GetType(), backlogItem.GetState().GetType());
        }

        [TestMethod]
        // TC-BL12: Indien testen twee keer gefaald is kan er vanaf ready for testing naar todo gegaan worden.
        public void TestTCBL12()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.BacklogItemDoing();
            backlogItem.BacklogItemReadyForTesting();
            backlogItem.BacklogItemTested();
            backlogItem.BacklogItemReadyForTesting();
            backlogItem.BacklogItemTested();
            backlogItem.BacklogItemReadyForTesting();
            ToDoState toDoState = new ToDoState(backlogItem);

            // Assert
            Assert.AreEqual(toDoState.GetType(), backlogItem.GetState().GetType());
        }

        [TestMethod]
        // TC-BL13: Een notificatie gaat door middel van versturen van een e-mail.
        public void TestTCBL13()
        {
            // Arrange
            Service service = new Service();
            INotificationEmail notification = new Adapter(service);

            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            notification.ConvertInformationToEmail("Test Notification");

            string expectedResult = "Verzend email: Test Notification";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-BL14: Binnen een backlog item moet de mogelijkheid zijn om meer activiteiten aan te maken.
        public void TestTCBL14()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.CreateActivity("Activity One", "Do some bugfixing");
            backlogItem.CreateActivity("Activity Two", "Doing some css");
            int expectedResult = 2;

            // Assert
            Assert.AreEqual(expectedResult, backlogItem.GetActivities().Count);
        }

        [TestMethod]
        // TC-BL15: De backlog item kan als done gezien worden, indien alle onderliggende activiteiten voltooid zijn. 
        public void TestTCBL15()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.CreateActivity("Activity One", "Do some bugfixing");
            backlogItem.CreateActivity("Activity Two", "Doing some css");

            IList activityList = backlogItem.GetActivities();

            foreach (Activity activity in activityList)
            {
                activity.SetIsDone(true);
            }

            backlogItem.SetActivities(activityList);
            backlogItem.CloseBacklogItem();

            bool expectedResult = true;

            // Assert
            Assert.AreEqual(expectedResult, backlogItem.GetIsDone());
        }

        [TestMethod]
        // TC-BL16: De backlog item kan als done gezien worden, indien alle onderliggende activiteiten voltooid zijn. 
        public void TestTCBL16()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.CreateActivity("Activity One", "Do some bugfixing");
            backlogItem.CreateActivity("Activity Two", "Doing some css");

            backlogItem.CloseBacklogItem();

            bool expectedResult = false;

            // Assert
            Assert.AreEqual(expectedResult, backlogItem.GetIsDone());
        }

        [TestMethod]
        // TC-BL17: De testers moeten een notificatie krijgen, zodra een backlog de fase “ready for testing” heeft bereikt.
        public void TestTCBL17()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");
            IMember memberOne = new Developer();

            // Act
            memberOne.SetRole("developer");
            backlogItem.AddMember(memberOne);
            backlogItem.Subscribe(memberOne);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            backlogItem.BacklogItemDoing();
            backlogItem.BacklogItemReadyForTesting();

            string expectedResult = "Verzend email: Backlog item staat klaar in readyfortesting.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-BL18: De scrum master moet een notificatie krijgen, als een backlog item wordt terug geplaatst naar de fase to do.
        public void TestTCBL18()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");
            IMember memberOne = new ScrumMaster();

            // Act
            memberOne.SetRole("scrum master");
            backlogItem.Subscribe(memberOne);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            backlogItem.BacklogItemDoing();
            backlogItem.BacklogItemReadyForTesting();
            backlogItem.BacklogItemTested();
            backlogItem.BacklogItemReadyForTesting();
            backlogItem.BacklogItemTested();
            backlogItem.BacklogItemReadyForTesting();

            string expectedResult = "Verzend email: De backlog item is terug verplaatst naar todo.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-BL19: Alleen de (lead) developer mag de backlog item verplaatsen naar de fase done.
        public void TestTCBL19()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            MemberFactory factory = new MemberFactory();
            IMember memberOne = factory.GetMember("developer");

            // Act
            backlogItem.CloseBacklogItem();

            memberOne.SetRole("developer");
            backlogItem.AddMember(memberOne);

            backlogItem.BacklogItemDoing();
            backlogItem.BacklogItemReadyForTesting();
            backlogItem.BacklogItemTested();
            backlogItem.BacklogDone();
            DoneState doneState = new DoneState(backlogItem);

            // Assert
            Assert.AreEqual(backlogItem.GetState().GetType(), doneState.GetType());
        }

        [TestMethod]
        // TC-BL20: Alleen de (lead) developer mag de backlog item verplaatsen naar de fase done.
        public void TestTCBL20()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            MemberFactory factory = new MemberFactory();
            IMember memberOne = factory.GetMember("developer");

            // Act
            memberOne.SetRole("developer");
            backlogItem.AddMember(memberOne);
            backlogItem.GetMember().SetRole("scrum master");

            backlogItem.BacklogItemDoing();
            backlogItem.BacklogItemReadyForTesting();
            backlogItem.BacklogItemTested();
            backlogItem.BacklogDone();
            TestedState testedState = new TestedState(backlogItem);

            // Assert
            Assert.AreEqual(backlogItem.GetState().GetType(), testedState.GetType());

        }

        [TestMethod]
        // TC-BL21: Een lid van het project kan een discussie starten bij een bepaalde backlog item.
        public void TestTCBL21()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.CreateDiscussion("Discussie 1", "Een discussie over hoe de algoritme werkt.");

            string expectedResult = "Discussie 1";

            // Assert
            Assert.AreEqual(expectedResult, backlogItem.GetDiscussion().GetTitle());
        }

        [TestMethod]
        // TC-BL22: Een lid van het project kan reacties plaatsen bij een discussie bij een bepaalde backlog item.
        public void TestTCBL22()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.CreateDiscussion("Discussie 1", "Een discussie over hoe de algoritme werkt.");

            backlogItem.GetDiscussion().CreateResponse("Het werkt zo:", "Lorum Ipsum");

            int expectedResultLength = 1;

            Discussion compareDiscussion = backlogItem.GetDiscussion();

            // Assert
            Assert.AreEqual(expectedResultLength, compareDiscussion.GetResponses().Count);
        }

        [TestMethod]
        // TC-BL23: Een lid van het project kan geen reacties meer plaatsen bij een discussie van een backlogitem als deze discussie gesloten is.
        public void TestTCBL23()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.CreateDiscussion("Discussie 1", "Een discussie over hoe de algoritme werkt.");

            backlogItem.GetDiscussion().CloseDiscussion();

            backlogItem.GetDiscussion().CreateResponse("Het werkt zo:", "Lorum Ipsum");

            int expectedResultLength = 0;

            Discussion compareDiscussion = backlogItem.GetDiscussion();

            // Assert
            Assert.AreEqual(expectedResultLength, compareDiscussion.GetResponses().Count);
        }

        [TestMethod]
        // TC-BL24: Een lid van het project kan geen discussie meer aanpassen bij een backlog item als deze discussie gesloten is.
        public void TestTCBL24()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.CreateDiscussion("Discussie 1", "Een discussie over hoe de algoritme werkt.");

            backlogItem.GetDiscussion().CloseDiscussion();

            backlogItem.GetDiscussion().SetTitle("Discussie 1.5");
            backlogItem.GetDiscussion().SetDescription("Een discussie over de algemene code.");

            string expectedResultTitle = "Discussie 1";
            string expectedResultDiscription = "Een discussie over hoe de algoritme werkt.";

            // Assert
            Assert.AreEqual(expectedResultTitle, backlogItem.GetDiscussion().GetTitle());
            Assert.AreEqual(expectedResultDiscription, backlogItem.GetDiscussion().GetDescription());
        }

        [TestMethod]
        // TC-BL25: Een lid van het project krijgt een melding als er een reactie is geplaats bij een discussie.
        public void TestTCBL25()
        {
            // Arrange
            BacklogItem backlogItem = new BacklogItem("1. BacklogItem", "Doing some code");

            // Act
            backlogItem.CreateDiscussion("Discussie 1", "Een discussie over hoe de algoritme werkt.");

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            backlogItem.GetDiscussion().CreateResponse("Het werkt zo:", "Lorum Ipsum");

            string expectedResult = "Verzend email: Reactie geplaatst bij: Discussie 1 - Een discussie over hoe de algoritme werkt.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

    }


}
