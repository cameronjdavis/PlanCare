using Newtonsoft.Json;

namespace PlanCare.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = String.Empty;
        public string Registration { get; set; } = String.Empty;
        public DateTime RegisteredUntil { get; set; }
        public static List<Car> Cars {
            get {
                using StreamReader r = new StreamReader("cars.json");
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Car>>(json) ?? [];
            }
        }
    }
}
