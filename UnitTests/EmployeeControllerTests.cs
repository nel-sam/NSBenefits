using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using NSBenefits.Controllers;
using System.Linq;
using Interfaces;
using Data;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeService> employeeServiceMock = new Mock<IEmployeeService>();
        private Mock<ILogger<EmployeeController>> loggerMock = new Mock<ILogger<EmployeeController>>();
        private EmployeeController employeeController;

        [TestInitialize]
        public void TestInitialize()
        {
            var controller = new EmployeeController(
                            this.loggerMock.Object,
                            this.employeeServiceMock.Object);

            this.employeeController = controller;
        }

        [TestMethod]
        public void Get_Returns_All_Employees()
        {
            this.employeeServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Employee>
                {
                    new Employee
                    {
                        FirstName = "Joe"
                    }
                });

            var result = this.employeeController.Get();
            Assert.IsNotNull(result.Value);
            Assert.AreEqual("Joe", result.Value.ToList()[0].FirstName);
        }
    }
}
