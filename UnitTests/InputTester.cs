using CarFactory.Controllers;
using CarFactory_Domain;
using CarFactory_Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static CarFactory.Controllers.CarController;
using static CarFactory_Factory.CarSpecification;

namespace UnitTests
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void Planborgini_inputTest()
        {
            //   | Planborgini | 3 doors | Pink base with red dots | 10 subwoofers and 20 standard | 15 |
            BuildCarInputModel carsSpecs = new BuildCarInputModel();
            List<BuildCarInputModelItem> cars = new List<BuildCarInputModelItem>();

            BuildCarInputModelItem planborgini = new BuildCarInputModelItem();
            planborgini.Specification = new CarSpecificationInputModel();
            planborgini.Specification.Paint = new CarPaintSpecificationInputModel();
            
            int inputAmount = 15;
            int inputNumberOfDoors = 3;
            Manufacturer inputManufacturer = Manufacturer.Planborghini;
            String inputPaintType = "Dot";
            String inputBaseColor = "Pink";
            String inputDotColor = "Red";

            planborgini.Amount = inputAmount;
            planborgini.Specification.NumberOfDoors = inputNumberOfDoors;
            planborgini.Specification.Manufacturer = inputManufacturer;
            planborgini.Specification.Paint.type = inputPaintType;
            planborgini.Specification.Paint.BaseColor = inputBaseColor;
            planborgini.Specification.Paint.DotColor = inputDotColor;

            SpeakerSpecificationInputModel frontSpeaker = new SpeakerSpecificationInputModel();
            frontSpeaker.IsSubwoofer = true;
            SpeakerSpecificationInputModel[] frontSpeakers = { frontSpeaker };
            planborgini.Specification.FrontWindowSpeakers = frontSpeakers;   
            
            SpeakerSpecificationInputModel doorSpeaker = new SpeakerSpecificationInputModel();
            doorSpeaker.IsSubwoofer = true;
            SpeakerSpecificationInputModel[] doorSpeakers = { doorSpeaker };
            planborgini.Specification.DoorSpeakers = doorSpeakers;

            cars.Add(planborgini);
            carsSpecs.Cars = cars;

            List<CarSpecification> wantedCars = (List<CarSpecification>)TransformToDomainObjects(carsSpecs);
            CarSpecification wantedCar = wantedCars[0];

            Assert.IsNotNull(wantedCars);
            Assert.IsTrue(wantedCars.Count == inputAmount);
            Assert.AreEqual(wantedCar.NumberOfDoors, inputNumberOfDoors);
            Assert.AreEqual(wantedCar.Manufacturer, inputManufacturer);
            Assert.IsNotNull((DottedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((DottedPaintJob)wantedCar.PaintJob).BaseColor, Color.FromName(inputBaseColor));
            Assert.AreEqual(((DottedPaintJob)wantedCar.PaintJob).DotColor, Color.FromName(inputDotColor));
            List<SpeakerSpecification> wantedDoorSpeakers = wantedCar.DoorSpeakers.ToList();
            Assert.AreEqual(wantedDoorSpeakers.Count, 1);
            Assert.IsTrue(wantedDoorSpeakers[0].IsSubwoofer);

            List<SpeakerSpecification> wantedFrontSpeakers = wantedCar.FrontWindowSpeakers.ToList();
            Assert.AreEqual(wantedFrontSpeakers.Count, 1);
            Assert.IsTrue(wantedFrontSpeakers[0].IsSubwoofer);

        }   
        
        [TestMethod]
        public void Planborgini_incorrectNumberOfDoorsTest()
        {
            //   | Planborgini | 3 doors | Pink base with red dots | 10 subwoofers and 20 standard | 15 |
            BuildCarInputModel carsSpecs = new BuildCarInputModel();
            List<BuildCarInputModelItem> cars = new List<BuildCarInputModelItem>();

            BuildCarInputModelItem planborgini = new BuildCarInputModelItem();
            planborgini.Specification = new CarSpecificationInputModel();
            planborgini.Specification.Paint = new CarPaintSpecificationInputModel();
            
            int inputAmount = 15;
            int inputNumberOfDoors = 4;
            Manufacturer inputManufacturer = Manufacturer.Planborghini;
            String inputPaintType = "Dot";
            String inputBaseColor = "Pink";
            String inputDotColor = "Red";

            planborgini.Amount = inputAmount;
            planborgini.Specification.NumberOfDoors = inputNumberOfDoors;
            planborgini.Specification.Manufacturer = inputManufacturer;
            planborgini.Specification.Paint.type = inputPaintType;
            planborgini.Specification.Paint.BaseColor = inputBaseColor;
            planborgini.Specification.Paint.DotColor = inputDotColor;

            SpeakerSpecificationInputModel frontSpeaker = new SpeakerSpecificationInputModel();
            frontSpeaker.IsSubwoofer = true;
            SpeakerSpecificationInputModel[] frontSpeakers = { frontSpeaker };
            planborgini.Specification.FrontWindowSpeakers = frontSpeakers;   
            
            SpeakerSpecificationInputModel doorSpeaker = new SpeakerSpecificationInputModel();
            doorSpeaker.IsSubwoofer = true;
            SpeakerSpecificationInputModel[] doorSpeakers = { doorSpeaker };
            planborgini.Specification.DoorSpeakers = doorSpeakers;

            cars.Add(planborgini);
            carsSpecs.Cars = cars;

            try {
                List<CarSpecification> wantedCars = (List<CarSpecification>)TransformToDomainObjects(carsSpecs);
            }
            catch (ArgumentException e) {
                Assert.AreEqual(e.Message, "Must give an odd number of doors");
            }
        }

        [TestMethod]
        public void PlanfaRomeo_inputTest()
        {
            //   | PlanfaRomeo | 5 doors | Blue base with Orange stripes | 1 subwoofer and 2 standard | 75 |
            BuildCarInputModel carsSpecs = new BuildCarInputModel();
            List<BuildCarInputModelItem> cars = new List<BuildCarInputModelItem>();

            BuildCarInputModelItem planfaRomeo = new BuildCarInputModelItem();
            planfaRomeo.Specification = new CarSpecificationInputModel();
            planfaRomeo.Specification.Paint = new CarPaintSpecificationInputModel();

            int inputAmount =75;
            int inputNumberOfDoors = 5;
            Manufacturer inputManufacturer = Manufacturer.PlanfaRomeo;
            String inputPaintType = "stripe";
            String inputBaseColor = "Blue";
            String inputStripeColor = "Orange";

            planfaRomeo.Amount = inputAmount;
            planfaRomeo.Specification.NumberOfDoors = inputNumberOfDoors;
            planfaRomeo.Specification.Manufacturer = inputManufacturer;
            planfaRomeo.Specification.Paint.type = inputPaintType;
            planfaRomeo.Specification.Paint.BaseColor = inputBaseColor;
            planfaRomeo.Specification.Paint.StripeColor = inputStripeColor;

            SpeakerSpecificationInputModel frontSpeaker = new SpeakerSpecificationInputModel();
            frontSpeaker.IsSubwoofer = true;
            SpeakerSpecificationInputModel[] frontSpeakers = { frontSpeaker };
            planfaRomeo.Specification.FrontWindowSpeakers = frontSpeakers;

            SpeakerSpecificationInputModel doorSpeaker = new SpeakerSpecificationInputModel();
            doorSpeaker.IsSubwoofer = false;
            SpeakerSpecificationInputModel[] doorSpeakers = { doorSpeaker };
            planfaRomeo.Specification.DoorSpeakers = doorSpeakers;

            cars.Add(planfaRomeo);
            carsSpecs.Cars = cars;

            List<CarSpecification> wantedCars = (List<CarSpecification>)TransformToDomainObjects(carsSpecs);
            CarSpecification wantedCar = wantedCars[0];

            Assert.IsNotNull(wantedCars);
            Assert.IsTrue(wantedCars.Count == inputAmount);
            Assert.AreEqual(wantedCar.NumberOfDoors, inputNumberOfDoors);
            Assert.AreEqual(wantedCar.Manufacturer, inputManufacturer);
            Assert.IsNotNull((StripedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).BaseColor, Color.FromName(inputBaseColor));
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).StripeColor, Color.FromName(inputStripeColor));

            List<SpeakerSpecification> wantedDoorSpeakers = wantedCar.DoorSpeakers.ToList();
            Assert.AreEqual(wantedDoorSpeakers.Count, 1);
            Assert.IsFalse(wantedDoorSpeakers[0].IsSubwoofer);

            List<SpeakerSpecification> wantedFrontSpeakers = wantedCar.FrontWindowSpeakers.ToList();
            Assert.AreEqual(wantedFrontSpeakers.Count, 1);
            Assert.IsTrue(wantedFrontSpeakers[0].IsSubwoofer);
        }

        [TestMethod]
        public void Volksday_inputTest()
        {
            //   | Volksday | 5 doors | Red base with black stripes | 4 standard speakers| 20 |
            BuildCarInputModel carsSpecs = new BuildCarInputModel();
            List<BuildCarInputModelItem> cars = new List<BuildCarInputModelItem>();

            BuildCarInputModelItem volksday = new BuildCarInputModelItem();
            volksday.Specification = new CarSpecificationInputModel();
            volksday.Specification.Paint = new CarPaintSpecificationInputModel();

            int inputAmount = 20;
            int inputNumberOfDoors = 5;
            Manufacturer inputManufacturer = Manufacturer.Volksday;
            String inputPaintType = "Stripe";
            String inputBaseColor = "Red";
            String inputStripeColor = "black";

            volksday.Amount = inputAmount;
            volksday.Specification.NumberOfDoors = inputNumberOfDoors;
            volksday.Specification.Manufacturer = inputManufacturer;
            volksday.Specification.Paint.type = inputPaintType;
            volksday.Specification.Paint.BaseColor = inputBaseColor;
            volksday.Specification.Paint.StripeColor = inputStripeColor;

            SpeakerSpecificationInputModel frontSpeaker = new SpeakerSpecificationInputModel();
            frontSpeaker.IsSubwoofer = false;
            SpeakerSpecificationInputModel[] frontSpeakers = { frontSpeaker };
            volksday.Specification.FrontWindowSpeakers = frontSpeakers;

            SpeakerSpecificationInputModel doorSpeaker = new SpeakerSpecificationInputModel();
            doorSpeaker.IsSubwoofer = false;
            SpeakerSpecificationInputModel[] doorSpeakers = { doorSpeaker };
            volksday.Specification.DoorSpeakers = doorSpeakers;

            cars.Add(volksday);
            carsSpecs.Cars = cars;

            List<CarSpecification> wantedCars = (List<CarSpecification>)TransformToDomainObjects(carsSpecs);
            CarSpecification wantedCar = wantedCars[0];

            Assert.IsNotNull(wantedCars);
            Assert.AreEqual(wantedCars.Count, inputAmount);
            Assert.AreEqual(wantedCar.NumberOfDoors, inputNumberOfDoors);
            Assert.AreEqual(wantedCar.Manufacturer, inputManufacturer);
            Assert.IsNotNull((StripedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).BaseColor, Color.FromName(inputBaseColor));
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).StripeColor, Color.FromName(inputStripeColor));

            List<SpeakerSpecification> wantedDoorSpeakers = wantedCar.DoorSpeakers.ToList();
            Assert.AreEqual(wantedDoorSpeakers.Count, 1);
            Assert.IsFalse(wantedDoorSpeakers[0].IsSubwoofer);

            List<SpeakerSpecification> wantedFrontSpeakers = wantedCar.FrontWindowSpeakers.ToList();
            Assert.AreEqual(wantedFrontSpeakers.Count, 1);
            Assert.IsFalse(wantedFrontSpeakers[0].IsSubwoofer);
        }

        [TestMethod]
        public void PlandayMotorWorks_inputTest()
        {
            //  |PlandayMotorWorks|3 doors|Black base with yellow dots|1 subwoofer 2 speakers|40|
            BuildCarInputModel carsSpecs = new BuildCarInputModel();
            List<BuildCarInputModelItem> cars = new List<BuildCarInputModelItem>();

            BuildCarInputModelItem plandayMotorWorks = new BuildCarInputModelItem();
            plandayMotorWorks.Specification = new CarSpecificationInputModel();
            plandayMotorWorks.Specification.Paint = new CarPaintSpecificationInputModel();

            int inputAmount = 20;
            int inputNumberOfDoors = 3;
            Manufacturer inputManufacturer = Manufacturer.PlandayMotorWorks;
            String inputPaintType = "Dot";
            String inputBaseColor = "Red";
            String inputDotColor = "black";

            plandayMotorWorks.Amount = inputAmount;
            plandayMotorWorks.Specification.NumberOfDoors = inputNumberOfDoors;
            plandayMotorWorks.Specification.Manufacturer = inputManufacturer;
            plandayMotorWorks.Specification.Paint.type = inputPaintType;
            plandayMotorWorks.Specification.Paint.BaseColor = inputBaseColor;
            plandayMotorWorks.Specification.Paint.DotColor = inputDotColor;

            SpeakerSpecificationInputModel frontSpeaker = new SpeakerSpecificationInputModel();
            frontSpeaker.IsSubwoofer = true;
            SpeakerSpecificationInputModel[] frontSpeakers = { frontSpeaker };
            plandayMotorWorks.Specification.FrontWindowSpeakers = frontSpeakers;

            SpeakerSpecificationInputModel doorSpeaker = new SpeakerSpecificationInputModel();
            doorSpeaker.IsSubwoofer = true;
            SpeakerSpecificationInputModel[] doorSpeakers = { doorSpeaker };
            plandayMotorWorks.Specification.DoorSpeakers = doorSpeakers;

            cars.Add(plandayMotorWorks);
            carsSpecs.Cars = cars;

            List<CarSpecification> wantedCars = (List<CarSpecification>)TransformToDomainObjects(carsSpecs);
            CarSpecification wantedCar = wantedCars[0];

            Assert.IsNotNull(wantedCars);
            Assert.IsTrue(wantedCars.Count == inputAmount);
            Assert.AreEqual(wantedCar.NumberOfDoors, inputNumberOfDoors);
            Assert.AreEqual(wantedCar.Manufacturer, inputManufacturer);
            Assert.IsNotNull((DottedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((DottedPaintJob)wantedCar.PaintJob).BaseColor, Color.FromName(inputBaseColor));
            Assert.AreEqual(((DottedPaintJob)wantedCar.PaintJob).DotColor, Color.FromName(inputDotColor));

            List<SpeakerSpecification> wantedDoorSpeakers = wantedCar.DoorSpeakers.ToList();
            Assert.AreEqual(wantedDoorSpeakers.Count, 1);
            Assert.IsTrue(wantedDoorSpeakers[0].IsSubwoofer);

            List<SpeakerSpecification> wantedFrontSpeakers = wantedCar.FrontWindowSpeakers.ToList();
            Assert.AreEqual(wantedFrontSpeakers.Count, 1);
            Assert.IsTrue(wantedFrontSpeakers[0].IsSubwoofer);
        }

        [TestMethod]
        public void Plandrover_inputTest()
        {
            //   |Plandrover|5 doors|Green base with gold stripes|4 standard speakers|20|
            BuildCarInputModel carsSpecs = new BuildCarInputModel();
            List<BuildCarInputModelItem> cars = new List<BuildCarInputModelItem>();

            BuildCarInputModelItem plandrover = new BuildCarInputModelItem();
            plandrover.Specification = new CarSpecificationInputModel();
            plandrover.Specification.Paint = new CarPaintSpecificationInputModel();

            int inputAmount = 20;
            int inputNumberOfDoors = 5;
            Manufacturer inputManufacturer = Manufacturer.Plandrover;
            String inputPaintType = "Stripe";
            String inputBaseColor = "Green";
            String inputStripeColor = "gold";

            plandrover.Amount = inputAmount;
            plandrover.Specification.NumberOfDoors = inputNumberOfDoors;
            plandrover.Specification.Manufacturer = inputManufacturer;
            plandrover.Specification.Paint.type = inputPaintType;
            plandrover.Specification.Paint.BaseColor = inputBaseColor;
            plandrover.Specification.Paint.StripeColor = inputStripeColor;

            SpeakerSpecificationInputModel frontSpeaker = new SpeakerSpecificationInputModel();
            frontSpeaker.IsSubwoofer = false;
            SpeakerSpecificationInputModel[] frontSpeakers = { frontSpeaker };
            plandrover.Specification.FrontWindowSpeakers = frontSpeakers;

            SpeakerSpecificationInputModel doorSpeaker = new SpeakerSpecificationInputModel();
            doorSpeaker.IsSubwoofer = false;
            SpeakerSpecificationInputModel[] doorSpeakers = { doorSpeaker };
            plandrover.Specification.DoorSpeakers = doorSpeakers;

            cars.Add(plandrover);
            carsSpecs.Cars = cars;

            List<CarSpecification> wantedCars = (List<CarSpecification>)TransformToDomainObjects(carsSpecs);
            CarSpecification wantedCar = wantedCars[0];

            Assert.IsNotNull(wantedCars);
            Assert.IsTrue(wantedCars.Count == inputAmount);
            Assert.AreEqual(wantedCar.NumberOfDoors, inputNumberOfDoors);
            Assert.AreEqual(wantedCar.Manufacturer, inputManufacturer);
            Assert.IsNotNull((StripedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).BaseColor, Color.FromName(inputBaseColor));
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).StripeColor, Color.FromName(inputStripeColor));

            List<SpeakerSpecification> wantedDoorSpeakers = wantedCar.DoorSpeakers.ToList();
            Assert.AreEqual(wantedDoorSpeakers.Count, 1);
            Assert.IsFalse(wantedDoorSpeakers[0].IsSubwoofer);

            List<SpeakerSpecification> wantedFrontSpeakers = wantedCar.FrontWindowSpeakers.ToList();
            Assert.AreEqual(wantedFrontSpeakers.Count, 1);
            Assert.IsFalse(wantedFrontSpeakers[0].IsSubwoofer);
        }
    }
}

