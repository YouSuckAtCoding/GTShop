using System.ComponentModel.DataAnnotations.Schema;

namespace GTShop.Server.Models;

public class Cart
{
    public int Id { get; set; }
    public User User_Id { get; set; }
    public decimal Total { get; set; }
    public DateTime Cart_Date { get; set; }
    public DateTime Cart_Exp_Date { get; set; }
    public List<Cart_Item> Cart_Items { get; set; } = new List<Cart_Item>();
}
