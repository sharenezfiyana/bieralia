namespace Bieralia.Models
{
    public class CartModel
    {
        public string BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookDesc { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
}
