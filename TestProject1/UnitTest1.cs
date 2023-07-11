using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASP_NET_REACT_CRUD_Project.Models;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDriverCreation()
        {
            // Arrange
            int expectedId = 1;
            string expectedDriverName = "John Doe";
            string expectedTeam = "Red Bull Racing";

            // Act
            Driver driver = new Driver()
            {
                id = expectedId,
                drivername = expectedDriverName,
                team = expectedTeam
            };

            // Assert
            Assert.AreEqual(expectedId, driver.id);
            Assert.AreEqual(expectedDriverName, driver.drivername);
            Assert.AreEqual(expectedTeam, driver.team);
        }

        [TestMethod]
        public void TestDriverValidation_InvalidDriverName()
        {
            // Arrange
            Driver driver = new Driver()
            {
                id = 1,
                drivername = "", // Niepoprawne - pole jest puste
                team = "Mercedes"
            };

            // Act
            var validationContext = new ValidationContext(driver, null, null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(driver, validationContext, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The drivername field is required.", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void TestDriverValidation_InvalidTeam()
        {
            // Arrange
            Driver driver = new Driver()
            {
                id = 1,
                drivername = "Lewis Hamilton",
                team = null // Niepoprawne - pole jest null
            };

            // Act
            var validationContext = new ValidationContext(driver, null, null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(driver, validationContext, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The team field is required.", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void TestDriverCreation_InvalidData()
        {
            // Arrange
            Driver driver = new Driver()
            {
                id = -1, // Niepoprawne - wartoœæ id musi byæ wiêksza lub równa 0
                drivername = "Max Verstappen",
                team = "Red Bull Racing"
            };

            // Act
            var validationContext = new ValidationContext(driver, null, null);
            Validator.ValidateObject(driver, validationContext, true);

            // Assert
            // Oczekuje ValidationException
        }
    }
}
