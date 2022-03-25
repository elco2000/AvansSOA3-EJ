using ApplicationAvansSOA3;
using ApplicationAvansSOA3.GitActions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestAvansSOA3
{
    [TestClass]
    public class GitActionTests
    {
        [TestMethod]
        // TC-SCM1: Het software configuration management integreert git, waardoor er verschillende version control
        // concepten uitgevoerd kunnen worden.
        public void TCSCM1()
        {
            // Arrange
            Pipeline pipeline = new Pipeline();
            GitAction gitAction = new GitAction("fork", new Fork());

            // Act
            pipeline.AddGitAction(gitAction);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);


            pipeline.GetGitAction().PerformGit();

            string expectedResult = "Git Action: Fork wordt uitgevoerd. Code wordt nu geforkt.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-SCM2: Het software configuration management integreert git, waardoor er verschillende version control
        // concepten uitgevoerd kunnen worden.
        public void TCSCM2()
        {
            // Arrange
            Pipeline pipeline = new Pipeline();
            GitAction gitAction = new GitAction("push", new Push());

            // Act
            pipeline.AddGitAction(gitAction);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);


            pipeline.GetGitAction().PerformGit();

            string expectedResult = "Git Action: Push wordt uitgevoerd. Code wordt nu gepusht.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-SCM3: Het software configuration management integreert git, waardoor er verschillende version control
        // concepten uitgevoerd kunnen worden.
        public void TCSCM3()
        {
            // Arrange
            Pipeline pipeline = new Pipeline();
            GitAction gitAction = new GitAction("pullRequest", new PullRequest());

            // Act
            pipeline.AddGitAction(gitAction);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);


            pipeline.GetGitAction().PerformGit();

            string expectedResult = "Git Action: PullRequest wordt uitgevoerd. Code wordt nu gepusht naar de gewenste branch.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }

        [TestMethod]
        // TC-SCM4: Het software configuration management integreert git, waardoor er verschillende version control
        // concepten uitgevoerd kunnen worden.
        public void TCSCM4()
        {
            // Arrange
            Pipeline pipeline = new Pipeline();
            GitAction gitAction = new GitAction("status", new Status());

            // Act
            pipeline.AddGitAction(gitAction);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);


            pipeline.GetGitAction().PerformGit();

            string expectedResult = "Git Action: Status wordt uitgevoerd. De status van de git is positief.";

            // Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }
    }
}
