using CarFactory_Assembly;
using CarFactory_Domain;
using CarFactory_Domain.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class NegativeTests
    {
        [TestMethod]
        public void Assembly_NullChassisJobTest()
        {
            CarAssembler carAssembler = new CarAssembler();
            Chassis inputChassis = null;
            Engine inputEngine = new Engine(new EngineBlock(10), "Test");
            Interior inputInterior = new Interior();
            Wheel[] inputWheels = new Wheel[4];

            Car car;
            try {
                car = carAssembler.AssembleCar(inputChassis, inputEngine, inputInterior, inputWheels);
            }
            catch (ArgumentNullException e){
                Assert.AreEqual(e.Message, "Value cannot be null.");
            }
        }

        [TestMethod]
        public void Assembly_NullEngineJobTest()
        {
            CarAssembler carAssembler = new CarAssembler();
            Chassis inputChassis = new Chassis("", true);
            Engine inputEngine = null;
            Interior inputInterior = new Interior();
            Wheel[] inputWheels = new Wheel[4];

            Car car;
            try {
                car = carAssembler.AssembleCar(inputChassis, inputEngine, inputInterior, inputWheels);
            }
            catch (ArgumentNullException e){
                Assert.AreEqual(e.Message, "Value cannot be null.");
            }
        }

        [TestMethod]
        public void Assembly_NullInteriorJobTest()
        {
            CarAssembler carAssembler = new CarAssembler();
            Chassis inputChassis = new Chassis("", true);
            Engine inputEngine = new Engine(new EngineBlock(10), "Test"); ;
            Interior inputInterior = null;
            Wheel[] inputWheels = new Wheel[4];

            Car car;
            try {
                car = carAssembler.AssembleCar(inputChassis, inputEngine, inputInterior, inputWheels);
            }
            catch (ArgumentNullException e){
                Assert.AreEqual(e.Message, "Value cannot be null.");
            }
        }

        [TestMethod]
        public void Assembly_NullWheelsJobTest()
        {
            CarAssembler carAssembler = new CarAssembler();
            Chassis inputChassis = new Chassis("", true);
            Engine inputEngine = new Engine(new EngineBlock(10), "Test"); 
            Interior inputInterior = new Interior();
            Wheel[] inputWheels = null;

            Car car;
            try {
                car = carAssembler.AssembleCar(inputChassis, inputEngine, inputInterior, inputWheels);
            }
            catch (ArgumentNullException e){
                Assert.AreEqual(e.Message, "Value cannot be null.");
            }
        }

        [TestMethod]
        public void Assembly_TooManyWheelsJobTest()
        {
            CarAssembler carAssembler = new CarAssembler();
            Chassis inputChassis = new Chassis("", true);
            Engine inputEngine = new Engine(new EngineBlock(10), "Test"); 
            Interior inputInterior = new Interior();
            Wheel[] inputWheels = new Wheel[5];

            Car car;
            try {
                car = carAssembler.AssembleCar(inputChassis, inputEngine, inputInterior, inputWheels);
            }
            catch (Exception e){
                Assert.AreEqual(e.Message, "Common cars must have 4 wheels");
            }
        }

        [TestMethod]
        public void Assembly_NotEnoughWheelsJobTest()
        {
            CarAssembler carAssembler = new CarAssembler();
            Chassis inputChassis = new Chassis("", true);
            Engine inputEngine = new Engine(new EngineBlock(10), "Test"); 
            Interior inputInterior = new Interior();
            Wheel[] inputWheels = new Wheel[2];

            Car car;
            try {
                car = carAssembler.AssembleCar(inputChassis, inputEngine, inputInterior, inputWheels);
            }
            catch (Exception e){
                Assert.AreEqual(e.Message, "Common cars must have 4 wheels");
            }
        }
    }
}
