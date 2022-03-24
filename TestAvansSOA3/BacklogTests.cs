﻿using ApplicationAvansSOA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

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
        // TC-BL12: Binnen een backlog item moet de mogelijkheid zijn om meer activiteiten aan te maken.
        public void TestTCBL12()
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
        // TC-BL23: Een lid van het project kan een discussie starten bij een bepaalde backlog item.
        public void TestTCBL23()
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
        // TC-BL24: Een lid van het project kan reacties plaatsen bij een discussie bij een bepaalde backlog item.
        public void TestTCBL24()
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
        // TC-BL25: Een lid van het project kan geen reacties meer plaatsen bij een discussie van een backlogitem als deze discussie gesloten is.
        public void TestTCBL25()
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
        // TC-BL26: Een lid van het project kan geen discussie meer aanpassen bij een backlog item als deze discussie gesloten is.
        public void TestTCBL26()
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

    }

    
}
