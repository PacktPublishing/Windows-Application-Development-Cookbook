/*
    Exemplary file for Chapter 9 - Testing and Submission.
    Recipe: Running a set of tests.
*/

using CH09.Models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace CH09.Tests
{
    [TestClass]
    public class ConsumptionCalculatorTest
    {
        [TestMethod]
        public void CreateInstance_ShouldHaveNoItems()
        {
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            Assert.AreEqual(0, calculator.Consumptions.Count);
        }

        [TestMethod]
        public void AddCorrectData_ShouldBeAdded()
        {
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            calculator.Add(120.0f, 8.9f);
            Assert.AreEqual(1, calculator.Consumptions.Count);
        }

        [TestMethod]
        public void AddNegativeDistance_ShouldBeRejected()
        {
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            calculator.Add(-5.2f, 12.1f);
            Assert.AreEqual(0, calculator.Consumptions.Count);
        }

        [TestMethod]
        public void AddNegativeFuel_ShouldBeRejected()
        {
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            calculator.Add(5.2f, -12.1f);
            Assert.AreEqual(0, calculator.Consumptions.Count);
        }

        [TestMethod]
        public void AddTwoCorrectData_ShouldBeAdded()
        {
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            calculator.Add(120.0f, 8.9f);
            calculator.Add(15.0f, 2.5f);
            Assert.AreEqual(2, calculator.Consumptions.Count);
        }

        [TestMethod]
        public void CalculateAverageWithoutData_ShouldBeZero()
        {
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            calculator.CalculateAverage();
            Assert.AreEqual(0.0f, calculator.Average);
        }

        [TestMethod]
        public void CalculateAverageWithOneData_ShouldBeCorrect()
        {
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            calculator.Add(120.5f, 9.8f);
            calculator.CalculateAverage();
            Assert.AreEqual(8.13f, calculator.Average);
        }

        [TestMethod]
        public void CalculateAverageWithManyData_ShouldBeCorrect()
        {
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            for (int i = 1; i < 1000; i++)
            {
                calculator.Add(120.5f * i, 9.8f * i);
            }
            calculator.CalculateAverage();
            Assert.AreEqual(8.13f, calculator.Average);
        }

        [TestMethod]
        public void RemoveIncorrectItem_ShouldBeHandled()
        {
            Consumption consumption = new Consumption() { Distance = 120.5f, Fuel = 9.8f };
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            calculator.Add(120.5f, 9.8f);
            calculator.Delete(consumption);
            Assert.AreEqual(1, calculator.Consumptions.Count);
        }

        [TestMethod]
        public void RemoveCorrectItem_ShouldBeRemoved()
        {
            ConsumptionCalculator calculator = new ConsumptionCalculator();
            calculator.Add(120.5f, 9.8f);
            calculator.Delete(calculator.Consumptions[0]);
            Assert.AreEqual(0, calculator.Consumptions.Count);
        }
    }
}
