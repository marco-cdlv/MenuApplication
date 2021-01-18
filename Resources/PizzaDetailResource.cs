namespace MenuApplication.Mapping
{
    public class PizzaDetailResource
    {
        public int PizzaDetailId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public int ToppingQuantity { get; set; }    
    }
}