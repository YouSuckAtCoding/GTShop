using System.ComponentModel.DataAnnotations.Schema;

namespace GTShop.Server.Models;

public class Order_Item
{
    public int Id { get; set; }
    public required Order Order_ { get; set; }
    public required Product Product_ { get; set; }
}
