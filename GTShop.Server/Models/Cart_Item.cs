using System.ComponentModel.DataAnnotations.Schema;

namespace GTShop.Server.Models;

public class Cart_Item
{
    public int Id { get; set; }
    public Cart Cart_Id { get; set; }
    public Product Product_Id { get; set; }
}
