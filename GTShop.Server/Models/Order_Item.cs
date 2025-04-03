using System.ComponentModel.DataAnnotations.Schema;

namespace GTShop.Server.Models;

public class Order_Item
{
    public int Id { get; set; }
    public Order Order_Id { get; set; }
    public Product Product_Id { get; set; }
}
