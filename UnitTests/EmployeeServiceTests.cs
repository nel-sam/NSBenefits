using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Services;

namespace UnitTests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private EmployeeService employeeService;
        private Mock<IEmployeeRepo> employeeRepoMock = new Mock<IEmployeeRepo>();

        [TestInitialize]
        public void TestInitialize()
        {
            this.employeeService = new EmployeeService(this.employeeRepoMock.Object);
        }

        [TestMethod]
        public void When_No_Dependents_Exist_Get_Should_Return_All()
        {
            // Arrange
            var name = "Joe";
            this.employeeRepoMock.Setup(x => x.GetAll())
                .Returns(new List<Employee>
                {
                    new Employee
                    {
                        FirstName = name
                    }
                });

            // Act
            var result = this.employeeService.GetAll();

            // Assert
            Assert.AreEqual(name, result.First().FirstName);
        }

        [TestMethod]
        public void When_Dependents_Exist_Get_Should_Return_All()
        {
            var name = "Rosa";
            this.employeeRepoMock.Setup(x => x.GetAll())
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

            var result = this.employeeService.GetAll();

            Assert.AreEqual(name, result.First().Dependents.First().FirstName);
        }
    }
}
