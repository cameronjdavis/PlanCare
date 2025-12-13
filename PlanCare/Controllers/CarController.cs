using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlanCare.Model;

namespace PlanCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars([FromQuery(Name = "make")] string make = "") {
            var cars = Car.Cars;
            if (make.Length > 0) {
                cars = cars.Where(c => c.Make.ToLower().Equals(make.ToLower())).ToList();
            }
            return Ok(cars);
        }

        [HttpGet("{rego}")]
        public async Task<ActionResult<DateTime>> GetRegoDate([FromRoute(Name = "rego")] string rego)
        {
            var cars = Car.Cars;
            Car? car = cars.Where(c => c.Registration == rego).FirstOrDefault();
            return car == null ? NotFound() : Ok(car.RegisteredUntil);
        }
    }
}
