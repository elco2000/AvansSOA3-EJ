using ApplicationAvansSOA3;
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
        // TC-BL11: Binnen een backlog item moet de mogelijkheid zijn om meer activiteiten aan te maken.
        public void TestTCBL11()
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
        // TC-BL14: De backlog item kan als done gezien worden, indien alle onderliggende activiteiten voltooid zijn. 
        public void TestTCBL14()
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
        // TC-BL15: De backlog item kan als done gezien worden, indien alle onderliggende activiteiten voltooid zijn. 
        public void TestTCBL15()
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
    }

    
}
