using CarFactory_Domain;
using CarFactory_Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static CarFactory.Controllers.CarController;
using static CarFactory_Factory.CarSpecification;

namespace UnitTests
{
    [TestClass]
    public class InputTester
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

            planborgini.Amount = 15;
            planborgini.Specification.NumberOfDoors = 3;
            planborgini.Specification.Manufacturer = Manufacturer.Planborghini;
            planborgini.Specification.Paint.PaintType = PaintType.Dot;
            planborgini.Specification.Paint.BaseColor = "Pink";
            planborgini.Specification.Paint.DotColor = "Red";

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
            Assert.IsTrue(wantedCars.Count == 15);
            Assert.AreEqual(wantedCar.NumberOfDoors, 3);
            Assert.AreEqual(wantedCar.Manufacturer, Manufacturer.Planborghini);
            Assert.IsNotNull((DottedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((DottedPaintJob)wantedCar.PaintJob).BaseColor, Color.Pink);
            Assert.AreEqual(((DottedPaintJob)wantedCar.PaintJob).DotColor, Color.Red);
            List<SpeakerSpecification> wantedDoorSpeakers = wantedCar.DoorSpeakers.ToList();
            Assert.AreEqual(wantedDoorSpeakers.Count, 1);
            Assert.IsTrue(wantedDoorSpeakers[0].IsSubwoofer);

            List<SpeakerSpecification> wantedFrontSpeakers = wantedCar.FrontWindowSpeakers.ToList();
            Assert.AreEqual(wantedFrontSpeakers.Count, 1);
            Assert.IsTrue(wantedFrontSpeakers[0].IsSubwoofer);
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

            planfaRomeo.Amount = 75;
            planfaRomeo.Specification.NumberOfDoors = 5;
            planfaRomeo.Specification.Manufacturer = Manufacturer.PlanfaRomeo;
            planfaRomeo.Specification.Paint.PaintType = PaintType.Stripe;
            planfaRomeo.Specification.Paint.BaseColor = "Blue";
            planfaRomeo.Specification.Paint.StripeColor = "Orange";

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
            Assert.IsTrue(wantedCars.Count == 75);
            Assert.AreEqual(wantedCar.NumberOfDoors, 5);
            Assert.AreEqual(wantedCar.Manufacturer, Manufacturer.PlanfaRomeo);
            Assert.IsNotNull((StripedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).BaseColor, Color.Blue);
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).StripeColor, Color.Orange);

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

            volksday.Amount = 20;
            volksday.Specification.NumberOfDoors = 5;
            volksday.Specification.Manufacturer = Manufacturer.Volksday;
            volksday.Specification.Paint.PaintType = PaintType.Stripe;
            volksday.Specification.Paint.BaseColor = "Red";
            volksday.Specification.Paint.StripeColor = "black";

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
            Assert.IsTrue(wantedCars.Count == 20);
            Assert.AreEqual(wantedCar.NumberOfDoors, 5);
            Assert.AreEqual(wantedCar.Manufacturer, Manufacturer.Volksday);
            Assert.IsNotNull((StripedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).BaseColor, Color.Red);
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).StripeColor, Color.Black);

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

            plandayMotorWorks.Amount = 40;
            plandayMotorWorks.Specification.NumberOfDoors = 3;
            plandayMotorWorks.Specification.Manufacturer = Manufacturer.PlandayMotorWorks;
            plandayMotorWorks.Specification.Paint.PaintType = PaintType.Dot;
            plandayMotorWorks.Specification.Paint.BaseColor = "Black";
            plandayMotorWorks.Specification.Paint.DotColor = "Yellow";

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
            Assert.IsTrue(wantedCars.Count == 40);
            Assert.AreEqual(wantedCar.NumberOfDoors, 3);
            Assert.AreEqual(wantedCar.Manufacturer, Manufacturer.PlandayMotorWorks);
            Assert.IsNotNull((DottedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((DottedPaintJob)wantedCar.PaintJob).BaseColor, Color.Black);
            Assert.AreEqual(((DottedPaintJob)wantedCar.PaintJob).DotColor, Color.Yellow);

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

            plandrover.Amount = 20;
            plandrover.Specification.NumberOfDoors = 5;
            plandrover.Specification.Manufacturer = Manufacturer.Plandrover;
            plandrover.Specification.Paint.PaintType = PaintType.Stripe;
            plandrover.Specification.Paint.BaseColor = "Green";
            plandrover.Specification.Paint.StripeColor = "Gold";

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
            Assert.IsTrue(wantedCars.Count == 20);
            Assert.AreEqual(wantedCar.NumberOfDoors, 5);
            Assert.AreEqual(wantedCar.Manufacturer, Manufacturer.Plandrover);
            Assert.IsNotNull((StripedPaintJob)wantedCar.PaintJob);
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).BaseColor, Color.Green);
            Assert.AreEqual(((StripedPaintJob)wantedCar.PaintJob).StripeColor, Color.Gold);

            List<SpeakerSpecification> wantedDoorSpeakers = wantedCar.DoorSpeakers.ToList();
            Assert.AreEqual(wantedDoorSpeakers.Count, 1);
            Assert.IsFalse(wantedDoorSpeakers[0].IsSubwoofer);

            List<SpeakerSpecification> wantedFrontSpeakers = wantedCar.FrontWindowSpeakers.ToList();
            Assert.AreEqual(wantedFrontSpeakers.Count, 1);
            Assert.IsFalse(wantedFrontSpeakers[0].IsSubwoofer);
        }
    }
}

