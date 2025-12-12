namespace PlanCare.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = String.Empty;
        public string Registration { get; set; } = String.Empty;
        public DateOnly RegistrationDate { get; set; }
    }
}
