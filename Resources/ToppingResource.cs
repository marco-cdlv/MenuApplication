namespace MenuApplication.Mapping
{
    public class ToppingResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PizzaResource Pizza { get; set; }
    }
}