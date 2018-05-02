using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTrain.Controllers;

namespace UnitTrain.Tests.Controllers
{
    [TestClass]
    public class StoreControllerTest
    {
        private StoreController controller;
        private ViewResult result;

        [TestInitialize]
        public void SetupContext()
        {
            controller = new StoreController();
            result = controller.Index() as ViewResult;
        }

        [TestMethod]
        public void IndexViewResultNotNull()
        {
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexStringInViewbag()
        {
            Assert.AreEqual("Hello world!", result.ViewBag.Message);
        }
    }
}
