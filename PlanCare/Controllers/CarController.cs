using Microsoft.AspNetCore.Mvc;
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
    }
}
