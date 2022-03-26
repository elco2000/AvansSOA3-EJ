using ApplicationAvansSOA3;
using ApplicationAvansSOA3.CompositePipeline;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAvansSOA3
{
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        // TC-DO1: Een geannuleerde release wordt gemeld doormiddel een automatisch bericht naar de product owner en scrum master.
        public void TestTCDO1()
        {
            // Arrange
            Sprint sprint = new Sprint("Test sprint");
            Backlog backlog = new Backlog("1. Backlog Test", "Doing some code");
            BacklogItem backlogItem = new BacklogItem("Testing", "Testing all of the code");

            // Act
            backlog.AddBacklogItem(backlogItem);

            sprint.SetBacklog(backlog);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            sprint.GenerateRapport("Release 1");

            string expectedResult = "Verzend email: Sprint release is geannuleerd.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-DO2: Als een release is goedgekeurd wordt er een pipeline gestart.
        public void TestTCDO2()
        {
            // Arrange
            Sprint sprint = new Sprint("Test sprint");
            Backlog backlog = new Backlog("1. Backlog Test", "Doing some code");
            BacklogItem backlogItem = new BacklogItem("Testing", "Testing all of the code");

            // Act
            backlogItem.SetIsDone(true);
            backlog.AddBacklogItem(backlogItem);

            sprint.SetBacklog(backlog);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            sprint.GenerateRapport("Release 1");

            string expectedResult = "Verzend email: Sprint is gesloten. En Pipeline wordt gestart!De source code wordt opgehaald.\nDe packages worden op dit moment geinstalleerd.\nDe software wordt gebuild. Maakt connectie met andere verschillende builds.\nDe code wordt getest met alle beschikbaar testen.\nDe code wordt geanalyseerd door SonarCloud.\nDe code wordt gedeployed op de gewenste omgeving.\nOverige commands worden uitgevoerd. De pipeline is succesvol voltooid!";

            SprintStatus expectedStatus = SprintStatus.Finished;

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
            Assert.AreEqual(expectedStatus, sprint.GetSprintStatus());
        }

        [TestMethod]
        // TC-DO3: Het DevOps systeem moet de actie sources ondersteunen,
        // zodat gebouwde source code opgehaald kan worden in een context waardoor de hele pipeline kan worden uitgevoerd.
        public void TestTCDO3()
        {
            // Arrange
            Sources sources = new Sources();

            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            sources.ActivatedSources();

            string expectedResult = "De source code wordt opgehaald.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-DO4: Het DevOps systeem moet de actie package ondersteunen, zodat er verschillende packages/libraries
        // geïnstalleerd kunnen worden waar je eigen software afhankelijk van is.
        public void TestTCDO4()
        {
            // Arrange
            Package package = new Package();

            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            package.ActivatedPackage();

            string expectedResult = "De packages worden op dit moment geinstalleerd.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-DO5: Het DevOps systeem moet de actie build ondersteunen, zodat de software kan builden en linken met verschillende builds.
        public void TestTCDO5()
        {
            // Arrange
            Build build = new Build();

            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            build.ActivatedBuild();

            string expectedResult = "De software wordt gebuild. Maakt connectie met andere verschillende builds.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-DO6: Het DevOps systeem moet de actie test ondersteunen, zodat de testen uitgevoerd kunnen worden.
        public void TestTCDO6()
        {
            // Arrange
            Test test = new Test();

            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            test.ActivatedTest();

            string expectedResult = "De code wordt getest met alle beschikbaar testen.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-DO7: Het DevOps systeem moet de actie analyse ondersteunen, zodat de code geanalyseerd kan worden door externe tool.
        public void TestTCDO7()
        {
            // Arrange
            Analyse analyse = new Analyse();

            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            analyse.ActivatedAnalyse();

            string expectedResult = "De code wordt geanalyseerd door SonarCloud.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-DO8: Het DevOps systeem moet de actie deploy ondersteunen, zodat er acties aanwezig zijn voor de deployment.
        public void TestTCDO8()
        {
            // Arrange
            Deploy deploy = new Deploy();

            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            deploy.ActivatedDeploy();

            string expectedResult = "De code wordt gedeployed op de gewenste omgeving.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-DO9: Het DevOps systeem moet de actie utility ondersteunen, waaronder overige commando’s vallen die niet een bepaalde categorie thuis hoort.
        public void TestTCDO9()
        {
            // Arrange
            Utility utility = new Utility();

            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            utility.ActivatedUtility();

            string expectedResult = "Overige commands worden uitgevoerd. De pipeline is succesvol voltooid!";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // Not (Non)Functional tests. Test for coverage.
        public void TestTCDOExtra()
        {
            // Arrange
            Pipeline pipeline = new Pipeline();

            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            pipeline.StartPipeline();

            string expectedResult = "De source code wordt opgehaald.\nDe packages worden op dit moment geinstalleerd.\nDe software wordt gebuild. Maakt connectie met andere verschillende builds.\nDe code wordt getest met alle beschikbaar testen.\nDe code wordt geanalyseerd door SonarCloud.\nDe code wordt gedeployed op de gewenste omgeving.\nOverige commands worden uitgevoerd. De pipeline is succesvol voltooid!";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }
    }
}
