using CarFactory_Domain;
using CarFactory_Domain.Engine;
using CarFactory_Paint;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class PainterTests
    {
        [TestMethod]
        public void Painter_SingleColorPaintJobTest()
        {
            var inputBaseColor = Color.Aqua;
            
            var singleColor = new SingleColorPaintJob(inputBaseColor);
            var painter = new Painter();
            var car = new Car(new Chassis("", true), new Engine(new EngineBlock(10),"Test"), new Interior(), new Wheel[4]);
            painter.PaintCar(car, singleColor);
            
            var job = (SingleColorPaintJob)car.PaintJob;
            job.Color.Should().Be(inputBaseColor);
            job.AreInstructionsUnlocked().Should().BeTrue();
        }       
        
        [TestMethod]
        public void Painter_StripedPaintJobTest()
        {
            var inputBaseColor = Color.Aqua;
            var inputStripeColor = Color.Yellow;
           
            var stripedColor = new StripedPaintJob(inputBaseColor, inputStripeColor);
            var painter = new Painter();
            var car = new Car(new Chassis("", true), new Engine(new EngineBlock(10),"Test"), new Interior(), new Wheel[4]);
            painter.PaintCar(car, stripedColor);
            
            var job = (StripedPaintJob)car.PaintJob;
            job.BaseColor.Should().Be(inputBaseColor);
            job.StripeColor.Should().Be(inputStripeColor);
            job.AreInstructionsUnlocked().Should().BeTrue();
        }       
        
        [TestMethod]
        public void Painter_DottedPaintJobTest()
        {
            var inputBaseColor = Color.Yellow;
            var inputDotColor = Color.Aqua;
            
            var singleColor = new DottedPaintJob(inputBaseColor, inputDotColor);
            var painter = new Painter();
            var car = new Car(new Chassis("", true), new Engine(new EngineBlock(10),"Test"), new Interior(), new Wheel[4]);
            painter.PaintCar(car, singleColor);
            
            var job = (DottedPaintJob)car.PaintJob;
            job.BaseColor.Should().Be(inputBaseColor);
            job.DotColor.Should().Be(inputDotColor);
            job.AreInstructionsUnlocked().Should().BeTrue();
        }   
    }
}
