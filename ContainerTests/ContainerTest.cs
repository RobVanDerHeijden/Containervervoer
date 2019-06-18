using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainervervoerCasus.Models.ContainerTests
{
    [TestClass]
    public class ContainerTest
    {
        private Dock _dock;

        private static List<Container> _containers1;
        private static List<Container> _containers2;


        [TestInitialize]
        public void TestInitialize()
        {
            _dock = new Dock();
            _containers1 = new List<Container>()
            {
                new CooledContainer(18),
                new CooledContainer(18),
                new Container(18),
                new Container(18),
                new ValuableContainer(18),
                new CooledContainer(12),
                new CooledContainer(12),
                new Container(12),
                new Container(12),
                new ValuableContainer(12),
                new CooledContainer(16),
                new CooledContainer(16),
                new Container(16),
                new Container(16),
                new ValuableContainer(16)
            };
            _containers2 = new List<Container>()
            {
                new CooledContainer(18),
                new CooledContainer(18)
            };
            _dock.AllContainers = _containers1;
            
        }

        /* Style Syntax For TestMethods
        [TestMethod()]
        public void MethodName_Scenario_Expectedbehavior() or just Expectedbehaviour
        {
            // Arrange
            // Act
            // Assert
        }*/

        /*[TestMethod]
        public void DockAllContainers_DockHasNoContainersTest_CountAllContainersIsZero()
        {
            // Act
            int amount = _dock.AllContainers.Count;
            // Assert
            Assert.AreEqual(0, amount);
        }*/
        /*[TestMethod]
        public void DockAllContainers_DockHasContainersTest_CountAllContainersIsMoreThanZero()
        {
            // Arrange
            _dock.AllContainers.Add(new Container(15, ContainerType.Regular));
            _dock.AllContainers.Add(new Container(10, ContainerType.Valuable));
            _dock.AllContainers.Add(new Container(5, ContainerType.Cooled));
            // Act
            int amount = _dock.AllContainers.Count;
            // Assert
            Assert.AreNotEqual(0, amount);
        }*/

        /* Requirements */
        // - Het maximum gewicht bovenop een container is 120 ton.
        [TestMethod]
        public void MaximumCarryWeightIs120()
        {
            // Act
            int amount = Container.MaximumCarryWeight;
            // Assert
            Assert.AreEqual(120, amount, "MaximumCarryWeight isn't 120");
        }
        // - Een volle container weegt maximaal 30 ton.
        [TestMethod]
        public void MaximumWeightIs30()
        {
            // Act
            int amount = Container.MaximumWeight;
            // Assert
            Assert.AreEqual(30, amount, "MaximumWeight isn't 30");
        }
        // - Een lege container weegt 4000 kg.
        [TestMethod]
        public void MinimumWeightIs4()
        {
            // Act
            int amount = Container.MinimumWeight;
            // Assert
            Assert.AreEqual(4, amount, "MinimumWeight isn't 4");
        }
        // - Er mag niets bovenop een container met waardevolle lading worden gestapeld;
        [TestMethod]
        public void CantStackOnTopOfValuable()
        {
            // Arange
            ValuableContainer valContainer1 = new ValuableContainer(30);
            //Container regContainer = new Container(); //use this one to see if regulars CAN be added
            Stack stack = new Stack(0, 0, BalansPosition.Left);
            // Act
            stack.AddContainer(valContainer1);
            bool canIStackOnTopValuable = stack.CanContainerBeAddedToStack(); ;
            // Assert
            Assert.IsFalse(canIStackOnTopValuable);
        }
        // wel mogen deze containers zelf op andere containers geplaatst worden.
        [TestMethod]
        public void CanValuableStackedOnTopOfOthers()
        {
            // Arange
            Container regContainer1 = new Container();
            Stack stack = new Stack(0, 0, BalansPosition.Left);
            // Act
            stack.AddContainer(regContainer1);
            bool canIStackOnTopValuable = stack.CanContainerBeAddedToStack(); ;
            // Assert
            Assert.IsTrue(canIStackOnTopValuable);
        }
        // Een container met waardevolle lading moet altijd via de voor- of achterkant te benaderen zijn. Je mag er vanuit gaan dat ook gestapelde containers te benaderen zijn.
        [TestMethod]
        public void IsValuableStackInAThirdRow()
        {
            // Arange
            Stack stack = new Stack(1, 0, BalansPosition.Left);
            // Act
            bool isValuableStackInAThirdRow = stack.IsStackInAValuableRow;
            // Assert
            Assert.IsTrue(isValuableStackInAThirdRow);
        }
        // Alle containers die gekoeld moeten blijven moeten in de eerste rij worden geplaatst vanwege de stroomvoorziening die aan de voorkant van elk schip zit.
        [TestMethod]
        public void IsContainerInCooledRow()
        {
            // Arange
            CooledContainer coolContainer1 = new CooledContainer(30);
            Stack stack = new Stack(0, 0, BalansPosition.Left); // Only Row[0]
            // Act
            stack.AddContainer(coolContainer1);
            bool isContainerInCooledRow = coolContainer1.ContainerType == ContainerType.Cooled &&
                                          stack.HasCooling;
            // Assert
            Assert.IsTrue(isContainerInCooledRow);
        }
        // Om kapseizen te voorkomen moet ten minste 50% van het maximum gewicht van een schip zijn benut.
        [TestMethod]
        public void HasCargoShipHaveEnoughWeightToPreventCapsizing()
        {
            // Arange
            CargoShip cargoShip = new CargoShip(3,1);
            double totalWeightContainers = _dock.AllContainers.Sum(item => item.Weight);
            // Act
            bool cargoHasEnoughWeight = totalWeightContainers >= cargoShip.MaximumCarryWeight / 2;
            // Assert
            Assert.IsTrue(cargoHasEnoughWeight);
        }
        // Het schip moet in evenwicht zijn: het volledige gewicht van de containers voor iedere helft mag niet meer dan 20% verschillen.
        [TestMethod]
        public void IsCargoShipWeightDistributionBalanced()
        {
            // Arange
            CargoShip cargoShip = new CargoShip(3, 1);
            int leftWeight = 100;//cargoShip.WeightLeftSide;
            int rightWeight = 110;//cargoShip.WeightRightSide;
            bool isBallenced;
            // Act
            int difference = cargoShip.ProcentDifferenceSides(leftWeight, rightWeight);
            if (difference > 20 || difference < -20)
            {
                isBallenced = false;
            }
            else
            {
                isBallenced = true;
            }
            // Assert
            Assert.IsTrue(isBallenced);
        }
        // De afmeting van een schip moet instelbaar zijn in de applicatie, waarbij de hoogte en breedte in containers aangegeven kan worden.
        [TestMethod]
        public void CountStacksEqualCargoShipMeasures()
        {
            // Arange
            CargoShip cargoShip = new CargoShip(3, 1);
            List<Stack> stacks = new List<Stack>()
            {
                new Stack(0, 0, BalansPosition.Left),
                new Stack(0, 1, BalansPosition.Middle),
                new Stack(0, 2, BalansPosition.Right)
            };
            cargoShip.Stacks = stacks;
            int cargoShipStacks = cargoShip.Width * cargoShip.Length;//cargoShip.WeightLeftSide;
            int innerStacks = cargoShip.Stacks.Count;//cargoShip.WeightRightSide;
            // Act
            bool amountStacksMatch = cargoShipStacks == innerStacks;
            // Assert
            Assert.IsTrue(amountStacksMatch);
        }


    }
}
