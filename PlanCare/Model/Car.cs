using Newtonsoft.Json;

namespace PlanCare.Model
{
    public class Car
    {
        public const string REGO_STATUS_VALID = "valid";
        public const string REGO_STATUS_EXPIRED = "expired";
        public int Id { get; set; }
        public string Make { get; set; } = String.Empty;
        public string Registration { get; set; } = String.Empty;
        public DateTime RegisteredUntil { get; set; }
        public string RegistrationStatus {
            get {
                return RegisteredUntil > DateTime.Now ? REGO_STATUS_VALID : REGO_STATUS_EXPIRED;
            }
        }
        public static List<Car> Cars {
            get {
                using StreamReader r = new StreamReader("cars.json");
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Car>>(json) ?? [];
            }
        }
    }
}
