namespace GTShop.Server.Models;

public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public DateTime Order_Date { get; set; }
    public List<Order_Item> Order_Items { get; set; } = [];
}
