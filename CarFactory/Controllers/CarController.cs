using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using CarFactory_Domain;
using CarFactory_Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarFactory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarFactory _carFactory;
        public CarController(ICarFactory carFactory)
        {
            _carFactory = carFactory;
        }

        [ProducesResponseType(typeof(BuildCarOutputModel), StatusCodes.Status200OK)]
        [HttpPost]
        public object Post([FromBody][Required] BuildCarInputModel carsSpecs)
        {

            var wantedCars = TransformToDomainObjects(carsSpecs);
            //Build cars
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Car> cars = (List<Car>) _carFactory.BuildCars(wantedCars);
            stopwatch.Stop();

            BuildCarOutputModel model = new BuildCarOutputModel();
            model.Cars = cars;
            model.RunTime = stopwatch.ElapsedMilliseconds;

            //Create response and return
            return model;
        }

        public static IEnumerable<CarSpecification> TransformToDomainObjects(BuildCarInputModel carsSpecs)
        {
            //Check and transform specifications to domain objects
            var wantedCars = new List<CarSpecification>();
            foreach (var spec in carsSpecs.Cars)
            {
                for(var i = 0; i < spec.Amount; i++)
                {
                    if(spec.Specification.NumberOfDoors % 2 == 0)
                    {
                        throw new ArgumentException("Must give an odd number of doors");
                    }
                    PaintJob? paint = null;
                    var baseColor = Color.FromName(spec.Specification.Paint.BaseColor);
                    var type = spec.Specification.Paint.type;

                    if (type.Equals("single") || type.Equals("Single")) {
                        paint = new SingleColorPaintJob(baseColor);
                    }
                    else if (type.Equals("stripe") || type.Equals("Stripe")) {
                        paint = new StripedPaintJob(baseColor, Color.FromName(spec.Specification.Paint.StripeColor));
                    } else if (type.Equals("dot") || type.Equals("Dot")) {
                        paint = new DottedPaintJob(baseColor, Color.FromName(spec.Specification.Paint.DotColor));
                    } else {
                        throw new ArgumentException(string.Format("Unknown paint type " + spec.Specification.Paint.type));
                    }
                            
                    var dashboardSpeakers = spec.Specification.FrontWindowSpeakers.Select(s => new CarSpecification.SpeakerSpecification { IsSubwoofer = s.IsSubwoofer });
                    var doorSpeakers = spec.Specification.DoorSpeakers.Select(s => new CarSpecification.SpeakerSpecification { IsSubwoofer = s.IsSubwoofer });
                    var wantedCar = new CarSpecification(paint, spec.Specification.Manufacturer, spec.Specification.NumberOfDoors, doorSpeakers, dashboardSpeakers);
                    wantedCars.Add(wantedCar);
                }
            }
            return wantedCars;
        }
    }

    public class BuildCarInputModel
    {
        public IEnumerable<BuildCarInputModelItem> Cars { get; set; }
    }

    public class BuildCarInputModelItem
    {
        [Required]
        public int Amount { get; set; }
        [Required]
        public CarSpecificationInputModel Specification { get; set; }
    }

    public enum PaintType
    {
        Single,
        Stripe,
        Dot
    }

    public class CarPaintSpecificationInputModel
    {
        public String type { get; set; }
        public string BaseColor { get; set; }
        public string? StripeColor { get; set; }
        public string? DotColor { get; set; }
    }

    public class CarSpecificationInputModel
    {
        public int NumberOfDoors { get; set; }
        public CarPaintSpecificationInputModel Paint { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public SpeakerSpecificationInputModel[] FrontWindowSpeakers { get; set; }
        public SpeakerSpecificationInputModel[] DoorSpeakers { get; set; }
    }

    public class SpeakerSpecificationInputModel
    {
        public bool IsSubwoofer { get; set; }
    }

    public class BuildCarOutputModel
    {
        public long RunTime { get; set; }
        public List<Car> Cars { get; set; }
    }
}