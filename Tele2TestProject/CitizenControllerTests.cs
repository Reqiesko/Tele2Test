using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleTest;
using TeleTest.Controllers;

namespace Tele2TestProject
{
    public class Tests
    {
        CitizenController citizenController = new CitizenController();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestOfGetAllMethod()
        {
            Task<ActionResult<List<Ñitizen>>> task = citizenController.GetAll(1, "all");
            Assert.AreEqual(TaskStatus.RanToCompletion, task.Status);
        }

        [Test]
        public void TestOfGetCitizenMethod()
        {
            Task<ActionResult<Ñitizen>> task = citizenController.GetCitizen("qyfgqiyhwfoq1");
            var res = task.Result.Result as OkObjectResult;
            Assert.IsNotNull(res.Value);
        }
    }
}