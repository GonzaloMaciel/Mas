using FluentAssertions;
using Mas.Controllers;
using Mas.Dtos;
using Mas.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mas.Tests
{
    public class EmployeeControllerUnitTests
    {
        [Fact]
        public async Task Values_Get_All()
        {
            // Arrange
            var controller = new EmployeeController();

            // Act
            var result = await controller.GetAllEmployees();


            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var employees = okResult.Value.Should().BeAssignableTo<IEnumerable<EmployeeDTO>>().Subject;

            employees.Count().Should().Be(2);
        }

        [Fact]
        public async Task Values_Get_Specific()
        {
            // Arrange
            var controller = new EmployeeController();

            // Act
            var result = await controller.GetEmployeeByID(1);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var person = okResult.Value.Should().BeAssignableTo<EmployeeDTO>().Subject;
            person.Id.Should().Be(1);
        }
    }
}
