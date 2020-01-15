using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NSBenefits.Controllers;
using NSBenefits.DTOs;
using System.Linq;
using Interfaces;
using Models;
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
        public void When_No_Dependents_Exist_Get_Should_Return_All()
        {
            // Arrange
            var name = "Joe";
            this.employeeServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Employee>
                {
                    new Employee
                    {
                        FirstName = name
                    }
                });

            // Act
            var result = this.employeeController.Get().Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var asIEnum = result.Value as IEnumerable<EmployeeDto>;
            var retrievedFirstName = asIEnum.First().FirstName;
            Assert.AreEqual(name, retrievedFirstName);
        }

        [TestMethod]
        public void When_Dependents_Exist_Get_Should_Return_All()
        {
            var name = "Rosa";
            this.employeeServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Employee>
                {
                    new Employee
                    {
                        Dependents = new List<Dependent>
                        {
                            new Dependent
                            {
                                FirstName = name
                            }
                        }
                    }
                });

            var result = this.employeeController.Get().Result as OkObjectResult;
            Assert.IsNotNull(result);
            var asIEnum = result.Value as IEnumerable<EmployeeDto>;
            var retrievedFirstName = asIEnum.First().Dependents.First().FirstName;
            Assert.AreEqual(name, retrievedFirstName);
        }
    }
}
