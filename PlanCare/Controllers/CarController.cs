using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlanCare.Model;

namespace PlanCare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars([FromQuery(Name = "make")] string make = "") {
            using StreamReader r = new StreamReader("cars.json");
            string json = r.ReadToEnd();
            var cars = JsonConvert.DeserializeObject<List<Car>>(json) ?? new List<Car>();
            if (make.Length > 0) {
                cars = cars.Where(c => c.Make.ToLower().Equals(make.ToLower())).ToList();
            }
            return Ok(cars);
        }
    }
}
