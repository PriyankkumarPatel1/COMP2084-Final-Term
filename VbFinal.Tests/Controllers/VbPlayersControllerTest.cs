using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VbFinal.Controllers;
using VbFinal.Models;

namespace VbFinal.Tests.Controllers
{
    [TestClass]
    public class VbPlayersControllerTest
    {
        VbPlayersController controller;
        Mock<IMockVbPlayer> mock;
        List<VbPlayer> vbPlayers;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockVbPlayer>();

            vbPlayers = new List<VbPlayer>
            {
                new VbPlayer
                {
                    VbPlayerId = 961,
                    FirstName = "Lori",
                    Lastname = "S",
                    Photo = "https://img.icons8.com/color/384/beach-volleyball.png"
                },
                new VbPlayer
                {
                    VbPlayerId = 962,
                    FirstName = "Zak",
                    Lastname = "N",
                    Photo = "https://img.icons8.com/ultraviolet/384/beach-volleyball.png"
                }
            };

            mock.Setup(m => m.VbPlayers).Returns(vbPlayers.AsQueryable());
            controller = new VbPlayersController(mock.Object);
        }

        // a
        [TestMethod]
        public void IndexViewLoads()
        {
            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }


        // b
        [TestMethod]
        public void IndexValidLoadsVbPlayers()
        {
            // act
            var result = (List<VbPlayer>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(vbPlayers, result);
        }

        // c
        [TestMethod]
        public void EditViewLoadGet()
        {
            //act
            ViewResult result = controller.Edit(961) as ViewResult;

            //Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        // d
        [TestMethod]
        public void EditLoadsVbPlayerValidId()
        {
            //act
            var result = (List<VbPlayer>)((ViewResult)controller.Edit(962)).Model;

            //Assert
            CollectionAssert.AreEqual(vbPlayers, result);
        }

        // e
        [TestMethod]
        public void EditInvalidId()
        {
            //Act
            ViewResult result = controller.Edit(960) as ViewResult;
            // will give an error because there is no service id = 60 in mock data.

            //Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // f
        [TestMethod]
        public void EditNoId()
        {
            //Act
            ViewResult result = controller.Edit(null+1) as ViewResult;
            // will give an error because there is no service id = 60 in mock data.

            //Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // g
        [TestMethod]
        public void EditSaveInvalid()
        {
            //Act
            controller.ModelState.AddModelError("Photo", "error");
            ViewResult result = controller.Edit(vbPlayers.ElementAt(1)) as ViewResult;
            // will give an error because there is no service id = 60 in mock data.

            //Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // h
        [TestMethod]
        public void EditSaveValid()
        {
            //Act
            ViewResult result = controller.Edit(vbPlayers.ElementAt(1)) as ViewResult;
            // will give an error because there is no service id = 60 in mock data.

            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
